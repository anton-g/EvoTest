using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class EvolutionManager : MonoBehaviour {

	/* UI */
	public Text genText;

	public GameObject square;

	Rect cameraRect;
	List<SquareDNA> population;
	List<SquareDNA> matingPool;

	int popSize = 50;

	float mutationRate = 0.01f;

	int generation = 1;

	bool genReady = false;
	
	void Start () {
		GetCameraSize();
		population = new List<SquareDNA>();
		matingPool = new List<SquareDNA>();

		StartCoroutine("SpawnPop");
	}

	void Update() {
		if (/*Input.GetKeyDown(KeyCode.Space) && */genReady) {
			generation++;
		
			StartCoroutine("DestroyAll");
		}
	}

	//Step 3 reproduce
	void Reproduce() {
		List<SquareDNA> newPopulation = new List<SquareDNA>();

		for (int i = 0; i < popSize; i++) {
			int a = Random.Range(0, matingPool.Count());
			int b = Random.Range(0, matingPool.Count());
			SquareDNA partnerA = matingPool[a];
			SquareDNA partnerB = matingPool[b];
			//Step 3a: Crossover
			SquareDNA child = partnerA.Crossover(partnerB);
			//Step 3b: Mutation
			child.Mutate(mutationRate);

			newPopulation.Add(child);
		}
		population = newPopulation;

		StartCoroutine("SpawnGen");
	}

	IEnumerator DestroyAll() {
		genReady = false;

		//TODO optimize
		GameObject[] o = GameObject.FindGameObjectsWithTag("Square");
		
		for (int i = 0; i < o.Length; i++) {
			Destroy(o[i]);

			yield return null;
		}

		genText.text = "Gen: " + generation;

		matingPool.Clear();

		//Step 2b build matingpool
		for (int i = 0; i < popSize; i++) {
			population[i].CalcFitness();
			int n = (int)population[i].fitness;
			for (int j = 0; j < n; j++) {
				matingPool.Add(population[i]);
			}
		}

		population.Clear();

		Reproduce();
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

	//Step 4 spawn new generation
	IEnumerator SpawnGen() {
		for (int i = 0; i < popSize; i++) {
			SpawnSquare(population[i]);
			yield return null;
		}

		genReady = true;
	}

	//Step 1 initialize pop
	IEnumerator SpawnPop() {
		for (int i = 0; i < popSize; i++) {
			SpawnSquare(new SquareDNA());
			yield return null;
		}

		genReady = true;
	}

	void SpawnSquare(SquareDNA dna) {
		Vector3 randomPos = new Vector3(Random.Range(cameraRect.x, cameraRect.xMax), Random.Range (cameraRect.yMax, cameraRect.y), 0.0f);
		GameObject individual = Instantiate(square, randomPos, Quaternion.identity) as GameObject;
		SquareController sq = individual.GetComponent<SquareController>();
		if (sq == null) {
			Destroy(individual);
			return;
		}
		sq.cameraRect = cameraRect;
		population.Add(dna);
		sq.SetDNA(dna);
		//Debug.Log(dna);
	}
}
