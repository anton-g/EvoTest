using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Evolution {

	public DNA[] population;
	List<DNA> matingPool;
	
	float mutationRate = 0.02f;

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

	public void AddToMatingPool(DNA dna) {
		matingPool.Add(dna);
	}

	public void Reproduce() {
		//TODO improve
		List<DNA> sortedMatingPool = matingPool.OrderByDescending(d => d.fitness).ToList();

		for (int i = 0; i < population.Length; i++) {
			int a = Random.Range (0, sortedMatingPool.Count / 2);
			int b = Random.Range (0, sortedMatingPool.Count / 2);
			DNA partnerA = sortedMatingPool[a];
			DNA partnerB = sortedMatingPool[b];

			DNA child = partnerA.Crossover(partnerB);

			child.Mutate(mutationRate);

			population[i] = child;

			Debug.Log(child);
		}
	}
}
