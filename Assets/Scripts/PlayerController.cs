using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("References")]
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private LineRenderer lr;

	[Header("Stats")]
	[SerializeField] private float power;
	[SerializeField] private float maxPower;
	[SerializeField] private float dragDistance;

	private Vector2 _dragPos;
	private bool _dragging = false;
	[HideInInspector] public bool attacking;
	
	private void Update () {
		if (GameManager.instance.isMenu) return;
		
		if (Input.GetMouseButtonDown(0)) StartDrag();
		if (Input.GetMouseButton(0) && _dragging) Drag();
		if (Input.GetMouseButtonUp(0) && _dragging) ReleaseDrag();

		if (attacking && rb.velocity.magnitude < 10f) attacking = false;
	}

	private bool TouchingPlayer () {
		return (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1f);
	}

	private void StartDrag () {
		if (TouchingPlayer()) {
			Time.timeScale = 0.5f;
			_dragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_dragging = true;
			lr.enabled = true;
			lr.positionCount = 2;

			if (!GameManager.instance.isPlaying) {
				GameManager.instance.isPlaying = true;
			}
		}
	}

	private void Drag () {
		var _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var _direction = ((Vector3)_mousePos - transform.position).normalized;

		var _playerPos = (Vector2)transform.position;

		lr.SetPosition(0, _playerPos);
		lr.SetPosition(1, _playerPos + ((Vector2)_direction * dragDistance));
	}

	private void ReleaseDrag () {
		Time.timeScale = 1f;
		Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction = (releasePos - _dragPos).normalized;
		
		float _power = Mathf.Clamp(Vector2.Distance(releasePos, _dragPos) * power, 0, maxPower);

		rb.AddForce(direction * _power, ForceMode2D.Impulse);

		attacking = true;

		_dragging = false;
		lr.positionCount = 0;
		lr.enabled = false;
	}
}
