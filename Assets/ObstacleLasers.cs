using System.Collections;
using UnityEngine;

public class ObstacleLasers : MonoBehaviour {
	[SerializeField] private GameObject[] lasers;
	[SerializeField] private float laserOffset;

	private void Start() {
		StartCoroutine("TriggerLasers");
	}

	private IEnumerator TriggerLasers () {
		while (true) {
			yield return new WaitForSeconds(3f);
			for (int i = 0; i < lasers.Length; i++) {
				lasers[i].GetComponent<BoxCollider2D>().enabled = true;
				lasers[i].GetComponent<Animator>().SetBool("LaserOff", false);
				SpriteRenderer sr = lasers[i].GetComponent<SpriteRenderer>();
				Color color = sr.color;
				color.a = 1;
				sr.color = color;
			}

			yield return new WaitForSeconds(2f);
			for (int i = 0; i < lasers.Length; i++) {
				// StartCoroutine("TriggerLaser", i);
				yield return new WaitForSeconds(laserOffset * i);

				lasers[i].GetComponent<Animator>().SetBool("LaserOff", true);
			}
		}
	}

	// private IEnumerator TriggerLaser (int laser) {
		

		
	// }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			Destroy(other.gameObject);
			GameManager.instance.GameOver();
		}
	}
}
