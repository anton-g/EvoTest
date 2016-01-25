using UnityEngine;
using System.Collections;

public class CubeStateScared {
	public event TransitionToState NewState;

	CubeController _ctrl;
	CubeController _target;
	/*
	public CubeStateScared(CubeController ctrl, CubeController target) {
		_ctrl = ctrl;
		if (_target) {
			_target = target;
		}

		_ctrl.mat.color = Color.blue;
	}

	public void Move() {
		if (_target == null) {
			OnNewState(new CubeStateMoving(_ctrl));
		}

		Vector3 directionToTarget = _target.transform.position - _ctrl.transform.position;
		directionToTarget = directionToTarget.normalized;

		Vector3 moveDirection = directionToTarget * -1;

		_ctrl.transform.Translate(moveDirection * _ctrl.speed * Time.deltaTime);
	}

	public void HandleCollision(Collider2D collider) {
		//Do nothing
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}

	public bool CanArgue() {
		return false;
	}

	public void Reset() {
		_ctrl = null;
		_target = null;
	}*/
}
