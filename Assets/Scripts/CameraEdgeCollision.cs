using UnityEngine;

public class CameraEdgeCollision : MonoBehaviour {
	private void Awake() {
		AddColliderOnCamera();
	}

	public void AddColliderOnCamera() {
		if (Camera.main == null) {
			Debug.LogError("No camera found make sure you have tagged your camera with 'MainCamera'");
			return;
		}

		Camera cam = Camera.main;

		if (!cam.orthographic) {
			Debug.LogError("Make sure your camera is set to orthographic");
			return;
		}

		// Get or Add Edge Collider 2D component
		var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();

		// Making camera bounds
		var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
		var leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
		var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
		var rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

		// var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };
		var edgePoints = new[] { leftTop, leftBottom, rightBottom, rightTop };

		// Adding edge points
		edgeCollider.points = edgePoints;
	}
}