using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

	public float speed;

	private void Update () {
		if (!GameManager.instance.isPlaying) return;

		Debug.Log("Playing");
		
		transform.position += Vector3.up * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			Destroy(other.gameObject);
			Debug.Log("Player Destroyed!");
			GameManager.instance.isPlaying = false;
		}
	}

}
