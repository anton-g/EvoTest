using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	public GameObject cube;

	Rect cameraRect;
	
	int populationSize = 10;

	List<CubeController> population;

	void Awake() {
		population = new List<CubeController>();
	}

	void Start() {
		GetCameraSize();

		InitPop();

		//Invoke("SurvivalOfTheFittest", 10.0f);
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

	void InitPop() {
		for (int i = 0; i < populationSize; i++) {
			SpawnCube(i);
		}
	}

	void SpawnCube(int i) {
		Vector3 randomPos = new Vector3(Random.Range(cameraRect.x, cameraRect.xMax), Random.Range (cameraRect.yMax, cameraRect.y), 0.0f);
		GameObject individual = Instantiate(cube, randomPos, Quaternion.identity) as GameObject;
		CubeController bp = individual.GetComponent<CubeController>();
		bp.cameraRect = cameraRect;
		bp.SetDNA(new DNA());
		population.Add(bp);
	}

	void SurvivalOfTheFittest() {
		population = population.OrderByDescending(c => c.dna.fitness).ToList();

		for (int i = 0; i < population.Count; i++) {
			Debug.Log(i + ": " + population[i]);
		}

		for (int i = 0; i < population.Count; i++) {
			if (i > population.Count / 2) {
				Debug.Log("test");
				Destroy(population[i].gameObject);
				Debug.Log("test2");
			} else {
				Debug.Log("test3");
				Debug.Log(i);
				Debug.Log(population[i]);
				population[i].TransitionToState(new CubeStateMoving(population[i]));
				Debug.Log("test4");
			}
		}
	}

	/*
	Evolution evolution;
	List<CubeController> cubes = new List<CubeController>();

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

		StartCoroutine("SpawnInitialPopulation");
		InvokeRepeating("NextGeneration", 10.0f, 10.0f);
	}

	void NextGeneration() {
		foreach (var cube in cubes) {
			cube.dna.CalcFitness();
		}

		List<DNA> matingPool = cubes.Select(c => c.dna).OrderByDescending(d => d.fitness).Take(populationSize / 2).ToList();

		//evolution.Reproduce(matingPool);

		GameObject[] cubes2 = GameObject.FindGameObjectsWithTag("Cube");
		
		GameObject[] cs = cubes2.OrderBy(a => a.GetComponent<CubeController>().dna.fitness).Take(50).ToArray();
		
		for (int i = 0; i < cs.Length; i++) {
			Destroy(cs[i]);
		}

		StartCoroutine("SpawnNewPopulation");
	}

	IEnumerator SpawnNewPopulation() {
		for (int i = 0; i < populationSize / 2; i++) {
			SpawnCube(i);
			yield return null;
		}
	}

	IEnumerator SpawnInitialPopulation() {
		for (int i = 0; i < populationSize; i++) {
			SpawnCube(i);
			yield return null;
		}
	}*/
}