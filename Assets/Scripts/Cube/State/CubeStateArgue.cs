using UnityEngine;
using System.Collections;

public class CubeStateArgue {

	public event TransitionToState NewState;
	
	CubeController _ctrl;
	public CubeController _target;

	float _time;
	bool _passive = false;
	/*
	public CubeStateArgue(CubeController ctrl, CubeController target, bool passive) {
		_ctrl = ctrl;
		if (target) {
			_target = target;
		}
		_time = 3.0f;

		_ctrl.mat.color = Color.gray;

		_passive = passive;
		if (!passive) {
			SetTargetState(new CubeStateArgue(target, ctrl, true));
		}
	}

	public void Move() {
		if (_passive) {
			return;
		}

		//Litet problem med att den bara tar hänsyn till 1 som argue nu
		float fightChance = .2f * Mathf.Max((_ctrl.dna.GetGene(Gene.Anger) - 50.0f) / 10.0f, 0.0f);
		float loveChance = .05f * Mathf.Max((_ctrl.dna.GetGene(Gene.Fertility) - 50.0f) / 5.0f, 0.0f);

		if (_target == null) {
			NothingHappens();
		}

		_time -= Time.deltaTime;
		if (_time <= 0) {
			//Compare lots of traits to make decision

			if (Random.value < fightChance) {
				if (_ctrl.speed > 0 && _target.speed > 0) {
//					SetTargetState(new CubeStateScared(_target, _ctrl));
//					OnNewState(new CubeStateChase(_ctrl, _target));
				} else {
					_target.Die();
//					OnNewState(new CubeStateMoving(_ctrl));
				}
			} else if (Random.value < loveChance) {
				bool loved = Random.value < 0.51;
//				SetTargetState(new CubeStateLoving(_target, _ctrl, loved));
//				OnNewState(new CubeStateLoving(_ctrl, _target, !loved));
			} else {
				NothingHappens();
			}
		}
	}

	public void HandleCollision(Collider2D collider) {
		//Do nothing
	}

	public bool CanArgue() {
		return false;
	}

	void NothingHappens() {
		OnNewState(new CubeStateMoving(_ctrl));
		if (_target == null) {
			return;
		}
		SetTargetState(new CubeStateMoving(_target));
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}

	void SetTargetState(CubeState state) {
		if (_target) {
			_target.TransitionToState(state);
		}
	}

	public void Reset() {
		_ctrl = null;
		_target = null;
	}*/
}
