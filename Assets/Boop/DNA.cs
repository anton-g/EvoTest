using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Gene {
	Speed = 0,
	Width = 1,
	Height = 2,
	Anger = 3,
	Fertility = 4,

	Color = 5
}
//SICKNESS

public enum FitnessBonus {
	Kill = 25,
}

public class DNA {
	byte[] genes = new byte[10];

	public float fitness;

	int initialGenes = 5;

	float minGeneValue = 0;
	float maxGeneValue = 99;

	List<FitnessBonus> bonuses = new List<FitnessBonus>();

	public DNA() {
		for (int i = 0; i < genes.Length; i++) {
			genes[i] = i < initialGenes ? (byte)Random.Range(minGeneValue, maxGeneValue) : (byte)0;
		}
	}

	public byte GetGene(Gene gene) {
		return genes[(int)gene];
	}

	public void CalcFitness() {
		int newFitness = 0;
		//Snabbhet ökar fitness
		newFitness += GetGene(Gene.Speed);
		//Skillnad mellan höjd och bredd minskar fitness
		newFitness -= Mathf.Max(GetGene(Gene.Height), GetGene(Gene.Width)) - Mathf.Min(GetGene(Gene.Height), GetGene(Gene.Width));
		//Fertilitet ökar fitness
		newFitness += GetGene(Gene.Fertility);

		for (int i = 0; i < bonuses.Count; i++) {
			newFitness += bonuses[i];
		}

		fitness = newFitness;
	}

	public DNA Crossover(DNA partner) {
		DNA child = new DNA();

		for (int i = 0; i < genes.Length; i++) {
			int coinFlip = Random.Range(0, 2);
			child.genes[i] = coinFlip == 0 ? genes[i] : partner.genes[i];
		}

		return child;
	}

	public void Mutate(float mutationRate) {
		for (int i = 0; i < genes.Length; i++) {
			if (Random.Range(0.0f, 1.0f) < mutationRate) {
				genes[i] = (byte)Random.Range(minGeneValue, maxGeneValue);
			}
		}
	}

	public void IncreaseFitness(FitnessBonus bonus) {
		bonuses.Add(bonus);
	}

	public override string ToString ()
	{
		string o = "[DNA] ";
		for (int i = 0; i < genes.Length; i++) {
			o += " " + genes[i].ToString();
		}
		return o;
	}
}
