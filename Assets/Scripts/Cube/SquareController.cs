using UnityEngine;
using System.Collections;

public class SquareController : MonoBehaviour {

	[HideInInspector] public Rect cameraRect;
	
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public MoveState moveState;
	[HideInInspector] public TalkState talkState;

	private SquareState _currentState;
	[HideInInspector] public SquareState currentState {
		get {
			return _currentState;
		}
		set {
			_currentState = value;
			_currentState.Reset();
			mat.color = _currentState.color();
		}
	}

	[HideInInspector] public SquareController interactionSquare;

	[HideInInspector] public float speed;
	private Material mat;

	void Awake() {
		mat = GetComponent<Renderer>().material;

		idleState = new IdleState(this);
		moveState = new MoveState(this);
		talkState = new TalkState(this);

		currentState = moveState;
	}

	void Start() {
		speed = 3.0f;
	}

	void Update() {
		currentState.UpdateState();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		currentState.HandleCollision(collider);
	}
}
