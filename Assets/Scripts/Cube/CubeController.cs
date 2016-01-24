using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	[HideInInspector]
	public DNA dna;
	[HideInInspector]
	public CubeState state;
	[HideInInspector]
	public LineRenderer lineRend;
	
	[HideInInspector]
	public Material mat;
	[HideInInspector]
	public Color origColor;
	[HideInInspector]
	public Rect cameraRect;

	[HideInInspector]
	public float speed = 0.0f;

	Color[] colors = new Color[] {
		Color.white,
		Color.grey,
		Color.cyan,
		Color.yellow,
		new Color(130 / 255, 255 / 255, 182 / 255),
		new Color(138 / 255, 105 / 255, 169 / 255)
	};

	void Awake() {
		mat = GetComponent<MeshRenderer>().material;
		lineRend = GetComponent<LineRenderer>();
	}
	
	void Start () {
		this.TransitionToState(new CubeStateMoving(this));
	}
	
	void Update () {
		if (state != null) {
			state.Move();
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraRect.x, cameraRect.xMax), Mathf.Clamp(transform.position.y, cameraRect.y, cameraRect.yMax));
		}
	}

	public void SetDNA(DNA newDNA) {
		dna = newDNA;
		dna.CalcFitness();
		
		speed = dna.GetGene(Gene.Speed) % 5.0f;
		float width = (dna.GetGene(Gene.Width) / 100.0f) % 0.25f;
		float height = (dna.GetGene(Gene.Height) / 100.0f) % 0.25f;
		transform.localScale += new Vector3(width, height, 0.0f);
		
		origColor = colors[dna.GetGene(Gene.Color)];
		mat.color = origColor;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (state != null) {
			state.HandleCollision(collider);
		}
	}

	public void Die() {
		Destroy(gameObject);
	}

	public void TransitionToState(CubeState newState) {
		newState.NewState += TransitionToState;
		state = newState;
	}
}
