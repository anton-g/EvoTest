using UnityEngine;
using System.Collections;

public class TalkState : SquareState {
	SquareController _square;

	float talkTime;
	float currentTalkTime;

	public TalkState(SquareController square) {
		_square = square;

		talkTime = 3.0f;
		currentTalkTime = 0.0f;
	}

	public void UpdateState() {
		if (currentTalkTime < talkTime) {
			currentTalkTime += Time.deltaTime;
		} else {
			if (Random.value < 0.20f) {
				ToLoveState();
			}
		}
	}
	
	public void HandleCollision(Collider2D collision) {

	}

	public bool CanInteract() {
		return false;
	}

	public void Reset() {
		currentTalkTime = 0.0f;
	}

	void ToMoveState() {
		_square.interactionSquare.interactionSquare = null;
		_square.interactionSquare.currentState = _square.interactionSquare.moveState;

		_square.interactionSquare = null;
		_square.currentState = _square.moveState;
	}

	void ToLoveState() {
		_square.currentState = _square.loveState;
		_square.interactionSquare.currentState = _square.interactionSquare.loveState;
	}

	public Color color() {
		return Color.green;
	}
}
