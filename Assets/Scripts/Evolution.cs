using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Evolution : MonoBehaviour {

	public DNA[] population;
	List<DNA> matingPool;
	
	float mutationRate = 0.04f;

	int generations = 1;

	public Evolution(int size) {
		population = new DNA[size];
		matingPool = new List<DNA>();

		CreateInitialPopulation();
	}

	void CreateInitialPopulation() {
		for (int i = 0; i < population.Length; i++) {
			population[i] = new DNA();
		}
	}

	public void Reproduce(List<DNA> matingPool) {
		for (int i = 0; i < population.Length / 2; i++) {
			int a = Random.Range (0, matingPool.Count);
			int b = Random.Range (0, matingPool.Count);
			DNA partnerA = matingPool[a];
			DNA partnerB = matingPool[b];

			DNA child = partnerA.Crossover(partnerB);

			child.Mutate(mutationRate);

			Debug.Log(i + ": " + child);

			population[i] = child;
		}

		generations++;
		Debug.Log("Generation: " + generations);
	}
}
