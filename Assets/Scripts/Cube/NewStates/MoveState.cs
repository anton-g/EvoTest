using UnityEngine;
using System.Collections;

public class MoveState : SquareState {
	SquareController _square;

	Vector3 target;

	public MoveState(SquareController square) {
		_square = square;

		target = _square.transform.position;
	}

	public void UpdateState() {
		Move();
	}

	public void HandleCollision(Collider2D collider) {
		SquareController square = collider.gameObject.GetComponent<SquareController>();
		if (square && square.currentState.CanInteract() && Random.value < 0.20f) {
			ToTalkState(square);
		}
	}

	void Move() {
		float distanceToTarget = Vector3.Distance(_square.transform.position, target);
		if (distanceToTarget < 0.1f) {
			float randomX = Random.Range(_square.cameraRect.x, _square.cameraRect.xMax);
			float randomY = Random.Range(_square.cameraRect.yMax, _square.cameraRect.y);
			target = new Vector3(randomX, randomY, 0.0f);
		}
		
		Vector3 directionToTarget = target - _square.transform.position;
		directionToTarget = directionToTarget.normalized;
		
		_square.transform.Translate(directionToTarget * _square.speed * Time.deltaTime);
	}

	void ToIdleState() {
		_square.currentState = _square.idleState;
	}

	void ToTalkState(SquareController interactionSquare) {
		_square.interactionSquare = interactionSquare;
		_square.currentState = _square.talkState;

		interactionSquare.interactionSquare = _square;
		interactionSquare.currentState = interactionSquare.talkState;
	}

	public bool CanInteract() {
		return true;
	}

	public void Reset() {

	}

	public Color color() {
		return Color.white;
	}
}
