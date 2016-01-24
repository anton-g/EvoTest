using UnityEngine;
using System.Collections;

public class CubeStateLoving : CubeState {
	public event TransitionToState NewState;

	CubeController _ctrl;
	CubeController _target;
	bool _loved;

	public CubeStateLoving(CubeController ctrl, CubeController target, bool loved) {
		_ctrl = ctrl;
		_target = target;
		_loved = loved;

		_ctrl.mat.color = Color.magenta;
		_target.mat.color = Color.magenta;
	}

	public void Move () {

	}

	public void HandleCollision (Collider2D collider) {

	}

	public bool CanArgue() {
		return false;
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}
}
