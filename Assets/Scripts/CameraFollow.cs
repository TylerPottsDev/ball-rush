using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private float smoothSpeed = 0.125f;
	[SerializeField] private float cameraYOffset;
	private Transform _target;

	private void Start () {
		_target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void LateUpdate () {
		if (!_target) return;

		Vector3 desiredPosition = new Vector3(transform.position.x, _target.position.y + cameraYOffset, transform.position.z);

		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		
		transform.position = smoothedPosition;
	}
}
