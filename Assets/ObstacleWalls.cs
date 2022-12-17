using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWalls : MonoBehaviour {

	[SerializeField] private Transform[] sets;
	[SerializeField] private float maxDistance;

	private void Start () {
		foreach (Transform set in sets) {
			set.position = new Vector3(Random.Range(-maxDistance, maxDistance), set.position.y, set.position.z);
		}
	}
}
