using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject cube;

	Rect cameraRect;

	Evolution evolution;
	List<CubeController> cubes = new List<CubeController>();

	int populationSize = 100;

	void Awake() {
		evolution = new Evolution(populationSize);
	}

	void Start () {
		Camera camera = Camera.main;
		var bottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
		var topRight = camera.ScreenToWorldPoint(new Vector3(
			camera.pixelWidth, camera.pixelHeight, 0.0f));
		
		cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);

		StartCoroutine("SpawnNewPopulation");
	}

	void DeleteAll() {
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

		Debug.Log(cubes.Length);
		for (int i = 0; i < cubes.Length; i++) {
			Destroy(cubes[i]);
		}
	}

	IEnumerator SpawnNewPopulation() {
		for (int i = 0; i < populationSize / 2; i++) {
			for (int j = 0; j < 2; j++) {
				Vector3 randomPos = new Vector3(Random.Range(cameraRect.x, cameraRect.xMax), Random.Range (cameraRect.yMax, cameraRect.y), 0.0f);
				GameObject individual = Instantiate(cube, randomPos, Quaternion.identity) as GameObject;
				CubeController bp = individual.GetComponent<CubeController>();
				bp.cameraRect = cameraRect;
				cubes.Add(bp);
				bp.SetDNA(evolution.population[i]);
				Debug.Log(evolution.population[i]);
			}
			yield return null;
		}
	}
}
