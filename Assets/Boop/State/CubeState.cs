using UnityEngine;
using System.Collections;

public delegate void TransitionToState(CubeState state);

public interface CubeState {	
	event TransitionToState NewState;

	void Move ();
	void HandleCollision (Collider2D collider);
	bool CanArgue();
}
