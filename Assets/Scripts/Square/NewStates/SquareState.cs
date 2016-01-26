using UnityEngine;
using System.Collections;

public interface SquareState {
	void UpdateState();
	void HandleCollision(Collider2D collision);
	bool CanInteract();
	void Reset();
}
