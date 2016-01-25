using UnityEngine;
using System.Collections;

public class CubeStateMoving : CubeState {
	public event TransitionToState NewState;

	private Vector3 targetPosition;

	private CubeController _ctrl;
	private float _speed;

	void Awake() {
		_ctrl = GetComponent<CubeController>();
	}

	void Start() {
		_ctrl.mat.color = _ctrl.origColor;
		targetPosition = _ctrl.transform.position;
	}

	public CubeStateMoving(CubeController ctrl) {
	}

	public override void Move() {
		float distanceToTarget = Vector3.Distance(_ctrl.transform.position, targetPosition);
		if (distanceToTarget < 0.1f) {
			float randomX = Random.Range(_ctrl.cameraRect.x, _ctrl.cameraRect.xMax);
			float randomY = Random.Range(_ctrl.cameraRect.yMax, _ctrl.cameraRect.y);
			targetPosition = new Vector3(randomX, randomY, 0.0f);
		}

		Vector3 directionToTarget = targetPosition - transform.position;
		directionToTarget = directionToTarget.normalized;
		
		transform.Translate(directionToTarget * _ctrl.speed * Time.deltaTime);
	}
	
	public override void HandleCollision(Collider2D collider) {
		if (collider.gameObject.GetComponent<CubeController>()) {
			CubeController enemy = collider.gameObject.GetComponent<CubeController>();

			Debug.Log("collision");

			if (enemy.state.CanArgue() && Random.Range(0.0f, 1.0f) < 0.4f) {

//				enemy.TransitionToState(new CubeStateArgue(enemy, _ctrl, true));
			}
		}
	}

	void OnNewState(CubeState newState) {
		if (NewState != null) {
			NewState(newState);
		}
	}

	public override bool CanArgue() {
		return true;
	}
}