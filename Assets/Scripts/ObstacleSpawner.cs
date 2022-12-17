using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private GameObject[] obstaclePrefabs;
	[SerializeField] private Transform obstacleParent;
	private int spawnCount = 1;
	[SerializeField] private float spawnDistance;
	[SerializeField] private int initialSpawnAmount;

	private void Update () {
		if (GameManager.instance.isPlaying) {
			if (transform.position.y > spawnCount * spawnDistance) {
				SpawnObstacle();
			}
		}
	}

	private void SpawnObstacle () {
		int randomIndex = Random.Range(0, obstaclePrefabs.Length);

		Vector3 spawnPosition = Vector3.up * (spawnCount * spawnDistance);
		
		GameObject obstacle = Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity);
		
		obstacle.transform.SetParent(obstacleParent);
		
		spawnCount++;
	}

	public void StartSpawner() {
		for (int i = 0; i < initialSpawnAmount; i++) {
			SpawnObstacle();
		}
	}

	public void ResetSpawner() {
		spawnCount = 1;
		
		for (int i = 0; i < obstacleParent.childCount; i++) {
			Destroy(obstacleParent.GetChild(i).gameObject);
		}
	}

}
