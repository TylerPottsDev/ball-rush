using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

	public float speed;

	private void Update () {
		if (!GameManager.instance.isPlaying) return;
		
		transform.position += Vector3.up * speed * Time.deltaTime;
	}

}
