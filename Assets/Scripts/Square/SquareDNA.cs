using UnityEngine;
using System.Collections;

public enum SquareGene {
	Green = 0,
	Speed,
	Width,
	Height,
	Red,
	Blue,
}

public class SquareDNA {
	byte[] genes;
	
	int mostAdvancedTrait;

	int minGeneValue = 0;
	int maxGeneValue = 99;

	int geneCount = 6;

	public float fitness;

	public SquareDNA() {
		mostAdvancedTrait = 4;

		genes = new byte[geneCount];

		for (int i = 0; i < mostAdvancedTrait; i++) {
			genes[i] = (byte)Random.Range(minGeneValue, maxGeneValue);
		}

		CalcFitness();
	}

	public SquareDNA Crossover(SquareDNA partner) {
		SquareDNA child = new SquareDNA();

		child.mostAdvancedTrait = Mathf.Max(mostAdvancedTrait, partner.mostAdvancedTrait);

		for (int i = 0; i < genes.Length; i++) {
			int coinFlip = Random.Range(0, 2);
			child.genes[i] = coinFlip == 0 ? genes[i] : partner.genes[i];
		}
		
		return child;
	}

	public void Mutate(float mutationRate) {
		int maxMutation = (int)Mathf.Min(mostAdvancedTrait * 1.4f, geneCount - 1);
		for (int i = 0; i <= maxMutation; i++) {
			if (Random.value < mutationRate) {
				genes[i] = (byte)Random.Range(minGeneValue, maxGeneValue);

				if (i > mostAdvancedTrait) {
					mostAdvancedTrait = i;
				}
			}
		}
	}

	public void CalcFitness() {
		int f = 0;
		f += GetGene(SquareGene.Speed);
		f += GetGene(SquareGene.Red);
		f += GetGene(SquareGene.Green);
		f += GetGene(SquareGene.Blue);
		f += Mathf.Max(GetGene(SquareGene.Width), GetGene(SquareGene.Height)) - Mathf.Min(GetGene(SquareGene.Width), GetGene(SquareGene.Height));

		fitness = Mathf.Min(f, 1);
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
