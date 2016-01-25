using UnityEngine;
using System.Collections;

public class IdleState : SquareState {
	SquareController _square;

	public IdleState(SquareController square) {
		_square = square;
	}
	
	public void UpdateState() {

	}
	
	public void HandleCollision(Collider2D collision) {

	}

	public bool CanInteract() {
		return false;
	}

	public void Reset() {
		
	}

	public Color color() {
		return Color.white;
	}
}
