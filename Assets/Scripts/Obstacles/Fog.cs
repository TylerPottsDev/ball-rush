using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

	[SerializeField] private float maxSpeed;
	private float _speed = 0f;

	private void Update () {
		if (!GameManager.instance.isPlaying) return;

		if (_speed < maxSpeed) {
			_speed += 0.1f * Time.deltaTime;
		}

		transform.position += Vector3.up * _speed * Time.deltaTime;
	}

	public void ResetSpeed (){
		_speed = 0f;
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			Destroy(other.gameObject);
			GameManager.instance.GameOver();
		}
	}

}
