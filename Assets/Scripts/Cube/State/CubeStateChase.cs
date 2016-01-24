using UnityEngine;
using System.Collections;

public class CubeStateChase : CubeState {
	public event TransitionToState NewState;

	CubeController _ctrl;
	CubeController _target;

	float _waitTime = 0.5f;
	float _chaseTime = 0.0f;
	float _maxChaseTime = 5.0f;

	public CubeStateChase(CubeController ctrl, CubeController target) {
		_ctrl = ctrl;
		_target = target;

		_ctrl.mat.color = Color.red;
	}

	public void Move () {
		_ctrl.lineRend.SetVertexCount(2);
		_ctrl.lineRend.SetPosition(0, _ctrl.transform.position);
		_ctrl.lineRend.SetPosition(1, _target.transform.position);

		if (_waitTime > 0.0f) {
			_waitTime -= Time.deltaTime;
		} else if (_chaseTime > _maxChaseTime) {
			_target.TransitionToState(new CubeStateMoving(_target));
			OnNewState(new CubeStateMoving(_ctrl));
		} else {
			if (_target) {
				_ctrl.transform.position = Vector3.MoveTowards(_ctrl.transform.position, _target.transform.position, _ctrl.speed * Time.deltaTime);
				_chaseTime += Time.deltaTime;
			}
		}
	}

	public void HandleCollision (Collider2D collider) {
		//TODO fix
		if (collider.gameObject.GetComponent<CubeController>() == _target) {
			_target.Die();
			OnNewState(new CubeStateMoving(_ctrl));
		}
	}

	void OnNewState(CubeState newState) {
		_ctrl.lineRend.SetVertexCount(0);
		if (NewState != null) {
			NewState(newState);
		}
	}

	public bool CanArgue() {
		return false;
	}
}
