using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
	public static GameManager instance;

	[Header("References")]
	[SerializeField] private Transform gameElementsParent;
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private GameObject fogObject;
	[SerializeField] private Transform obstaclesParent;

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

		fogObject.transform.position = fogSpawnPoint.position;

		foreach (Transform child in obstaclesParent) {
			Destroy(child.gameObject);
		}
	}

	public void PlayGame () {
		isMenu = false;
	}
}
