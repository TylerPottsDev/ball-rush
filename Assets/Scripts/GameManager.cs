using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
	public static GameManager instance;

	[Header("References")]
	[SerializeField] private Transform gameElementsParent;
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private GameObject fogObject;
	[SerializeField] private ObstacleSpawner spawner;
	[SerializeField] private GameObject deathScreen;
	[SerializeField] private CameraFollow cameraFollow;

	[Header("Spawn Points")]
	[SerializeField] private Transform playerSpawnPoint;
	[SerializeField] private Transform fogSpawnPoint;

	[HideInInspector] public bool isPlaying = false;
	[HideInInspector] public bool isMenu = true;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void ResetLevel () {
		GameObject player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
		player.transform.SetParent(gameElementsParent);

		cameraFollow._target = player.transform;

		Camera.main.transform.position = new Vector3(0, playerSpawnPoint.position.y, Camera.main.transform.position.z);

		fogObject.transform.position = fogSpawnPoint.position;

		fogObject.GetComponent<Fog>().ResetSpeed();

		spawner.ResetSpawner();
	}

	public void GameOver () {
		deathScreen.SetActive(true);
		isPlaying = false;
		ResetLevel();
	}

	public void PlayGame () {
		isMenu = false;
		spawner.StartSpawner();
	}

	public void OpenMenu () {
		isMenu = true;
	}
}
