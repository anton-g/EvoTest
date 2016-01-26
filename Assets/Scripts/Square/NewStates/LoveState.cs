using UnityEngine;
using System.Collections;

public class LoveState : SquareState {
	SquareController _square;

	float timeCounter = 0.0f;
	float spinSpeed = 5.0f;
	float spinWidth;
	float spinHeight;
	Vector3 spinPos;

	public LoveState(SquareController square) {
		_square = square;

		//spinSpeed = (_ctrl.dna.GetGene(Gene.Speed) + _target.dna.GetGene(Gene.Speed)) / 25.0f;
		spinSpeed = 0.5f;
	}
	
	public void UpdateState() {
		if (spinPos == Vector3.zero) {
			spinPos = (_square.transform.position + _square.interactionSquare.transform.position) / 2;
			spinWidth = Vector3.Distance(_square.transform.position, _square.interactionSquare.transform.position) / 2;
			spinHeight = spinWidth;
		}

		timeCounter += Time.deltaTime * spinSpeed;

		float x = spinPos.x + Mathf.Cos(timeCounter) * spinWidth;
		float y = spinPos.y + Mathf.Sin(timeCounter) * spinHeight;
		float z = 0.0f;
		
		_square.transform.position = new Vector3(x,y,z);
	}
	
	public void HandleCollision(Collider2D collision) {
		
	}
	
	public bool CanInteract() {
		return false;
	}
	
	public void Reset() {
		
	}
}
