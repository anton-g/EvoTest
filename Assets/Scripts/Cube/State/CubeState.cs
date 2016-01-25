using UnityEngine;
using System.Collections;

public delegate void TransitionToState(CubeState state);

public abstract class CubeState : MonoBehaviour {	
	public event TransitionToState NewState;

	public abstract void Move ();
	public abstract void HandleCollision (Collider2D collider);
	public abstract bool CanArgue();
}
