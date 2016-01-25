using UnityEngine;
using System.Collections;

public class EvolutionManager : MonoBehaviour {

	public GameObject square;

	Rect cameraRect;
	
	void Start () {
		GetCameraSize();

		for (int i = 0; i < 10; i++) {
			SpawnSquare();
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("t");
			GameObject[] o = GameObject.FindGameObjectsWithTag("Square");

			for (int i = 0; i < o.Length; i++) {
				Destroy(o[i]);
			}
		}
	}

	void GetCameraSize() {
		Camera camera = Camera.main;
		var bottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
		var topRight = camera.ScreenToWorldPoint(new Vector3(
			camera.pixelWidth, camera.pixelHeight, 0.0f));
		
		cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);
	}

	void SpawnSquare() {
		Vector3 randomPos = new Vector3(Random.Range(cameraRect.x, cameraRect.xMax), Random.Range (cameraRect.yMax, cameraRect.y), 0.0f);
		GameObject individual = Instantiate(square, randomPos, Quaternion.identity) as GameObject;
		SquareController sq = individual.GetComponent<SquareController>();
		sq.cameraRect = cameraRect;
		//bp.SetDNA(new DNA());
		//population.Add(bp);
	}
}
