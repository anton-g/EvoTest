using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	Vector3 _oldPos;
	Vector3 _panOrigin;
	float _panSpeed = 35.0f;

	void Update () {
		Camera cam = Camera.main;
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		cam.orthographicSize = cam.orthographicSize + scroll;
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1.0f, 25.0f);
		
		if(Input.GetMouseButtonDown(0)) {
			_oldPos = transform.position;
			_panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}
		
		if(Input.GetMouseButton(0)) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - _panOrigin;
			transform.position = _oldPos + -pos * _panSpeed;
		}
	}
}
