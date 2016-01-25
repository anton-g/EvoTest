using UnityEngine;
using System.Collections;

public enum SquareGene {
	Green = 0,
	Speed,
	Width,
	Height,
	Red = 10,
	Blue = 15
}

public class SquareDNA {
	byte[] genes;
	
	int mostAdvancedTrait = 10;

	int minGeneValue = 0;
	int maxGeneValue = 99;

	public float fitness;

	public SquareDNA() {
		genes = new byte[64];

		for (int i = 0; i < mostAdvancedTrait; i++) {
			genes[i] = (byte)Random.Range(minGeneValue, maxGeneValue);
		}

		CalcFitness();
	}

	public SquareDNA Crossover(SquareDNA partner) {
		SquareDNA child = new SquareDNA();
		
		for (int i = 0; i < genes.Length; i++) {
			int coinFlip = Random.Range(0, 2);
			child.genes[i] = coinFlip == 0 ? genes[i] : partner.genes[i];
		}
		
		return child;
	}

	public void Mutate(float mutationRate) {
		int maxMutation = (int)Mathf.Min(mostAdvancedTrait * 1.2f, 99);
		for (int i = 0; i < maxMutation; i++) {
			if (Random.Range(0.0f, 1.0f) < mutationRate) {
				mostAdvancedTrait = i;
				genes[i] = (byte)Random.Range(minGeneValue, maxGeneValue);
			}
		}
	}

	public void CalcFitness() {
		int f = 0;
		f += GetGene(SquareGene.Speed);
		f += GetGene(SquareGene.Blue);
		f += GetGene(SquareGene.Red);

		fitness = f;
	}

	public byte GetGene(SquareGene gene) {
		return genes[(int)gene];
	}

	public override string ToString ()
	{
		string r = "[DNA] ";
		for (int i = 0; i < genes.Length; i++) {
			r += genes[i] + " ";
		}
		return string.Format (r);
	}
}
