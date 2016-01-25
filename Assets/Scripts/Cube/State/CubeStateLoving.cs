using UnityEngine;
using System.Collections;

public class CubeStateLoving {
	public event TransitionToState NewState;

	CubeController _ctrl;
	CubeController _target;
	bool _loved;

	float timeCounter = 0.0f;
	float spinSpeed = 4.0f;
	float spinWidth = 0.5f;
	float spinHeight = 0.5f;
	Vector3 spinPos;
	/*
	public CubeStateLoving(CubeController ctrl, CubeController target, bool loved) {
		_ctrl = ctrl;
		if (target) {
			_target = target;
		}
		_loved = loved;

		_ctrl.mat.color = Color.magenta;
		_target.mat.color = Color.magenta;

		spinPos = _ctrl.transform.position;

		spinSpeed = (_ctrl.dna.GetGene(Gene.Speed) + _target.dna.GetGene(Gene.Speed)) / 25.0f;
	}

	public void Move () {
		timeCounter += Time.deltaTime * spinSpeed;

		float x = _loved ? spinPos.x + Mathf.Cos(timeCounter) * spinWidth : spinPos.x + Mathf.Sin(timeCounter) * spinHeight;
		float y = _loved ? spinPos.y + Mathf.Sin(timeCounter) * spinWidth : spinPos.y + Mathf.Cos(timeCounter) * spinHeight;
		float z = 0.0f;

		_ctrl.transform.position = new Vector3(x,y,z);
	}

	public void HandleCollision (Collider2D collider) {
		if (_target == null) {
			return;
		}
		if (collider.gameObject == _target.gameObject) {
			_ctrl.dna.IncreaseFitness(FitnessBonus.Love);
		}
	}

	public bool CanArgue() {
		return false;
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}

	public void Reset() {
		_ctrl = null;
		_target = null;
	}*/
}
