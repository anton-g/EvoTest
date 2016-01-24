using UnityEngine;
using System.Collections;

public class CubeStateMoving : CubeState {
	public event TransitionToState NewState;

	private Vector3 targetPosition;

	private CubeController _ctrl;
	private float _speed;

	public CubeStateMoving(CubeController ctrl) {
		_ctrl = ctrl;

		_ctrl.mat.color = _ctrl.origColor;

		targetPosition = _ctrl.transform.position;
	}

	public void Move() {
		float distanceToTarget = Vector3.Distance(_ctrl.transform.position, targetPosition);
		if (distanceToTarget < 0.1f) {
			float randomX = Random.Range(_ctrl.cameraRect.x, _ctrl.cameraRect.xMax);
			float randomY = Random.Range(_ctrl.cameraRect.yMax, _ctrl.cameraRect.y);
			targetPosition = new Vector3(randomX, randomY, 0.0f);
		}

		Vector3 directionToTarget = targetPosition - _ctrl.transform.position;
		directionToTarget = directionToTarget.normalized;
		
		_ctrl.transform.Translate(directionToTarget * _ctrl.speed * Time.deltaTime);
	}
	
	public void HandleCollision(Collider2D collider) {
		if (collider.gameObject.GetComponent<CubeController>()) {
			CubeController enemy = collider.gameObject.GetComponent<CubeController>();

			if (enemy.state.CanArgue() && Random.Range(0.0f, 1.0f) < 0.4f) {
				OnNewState(new CubeStateArgue(_ctrl, enemy, false));
			}
		}
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}

	public bool CanArgue() {
		return true;
	}
}