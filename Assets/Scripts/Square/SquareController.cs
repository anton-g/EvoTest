using UnityEngine;
using System.Collections;

public class SquareController : MonoBehaviour {

	[HideInInspector] public Rect cameraRect;
	
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public MoveState moveState;
	[HideInInspector] public TalkState talkState;
	[HideInInspector] public LoveState loveState;

	private SquareState _currentState;
	[HideInInspector] public SquareState currentState {
		get {
			return _currentState;
		}
		set {
			_currentState = value;
			_currentState.Reset();
		}
	}

	[HideInInspector] public SquareController interactionSquare;

	[HideInInspector] public SquareDNA dna;
	[HideInInspector] public float speed;
	private Material mat;

	void Awake() {
		mat = GetComponent<Renderer>().material;

		idleState = new IdleState(this);
		moveState = new MoveState(this);
		talkState = new TalkState(this);
		loveState = new LoveState(this);

		currentState = moveState;
	}

	void Start() {
		speed = dna.GetGene(SquareGene.Speed) / 10;

		float red = Mathf.Clamp(dna.GetGene(SquareGene.Red) / 100.0f, 0.2f, 1.0f);
		float green = Mathf.Clamp(dna.GetGene(SquareGene.Green) / 100.0f, 0.2f, 1.0f);
		float blue = Mathf.Clamp(dna.GetGene(SquareGene.Blue) / 100.0f, 0.2f, 1.0f);
		mat.color = new Color(red, green, blue);

		float width = dna.GetGene(SquareGene.Width) / 500.0f;
		float height = dna.GetGene(SquareGene.Height) / 500.0f;
		transform.localScale += new Vector3(width, height, 0.0f);
	}

	void Update() {
		if (dna != null) {
			currentState.UpdateState();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		currentState.HandleCollision(collider);
	}

	public void SetDNA(SquareDNA DNA) {
		dna = DNA;
	}
}
