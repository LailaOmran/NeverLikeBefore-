using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionChecking : MonoBehaviour {
	[HideInInspector]
	public Collider2D colliderOfPivot;
	[HideInInspector]
	public bool canCollect = false;
	public string tagOfPivot = "Pivot";

	private void OnTriggerEnter2D (Collider2D colliderOfPivot) {
		this.colliderOfPivot = colliderOfPivot;

		if (colliderOfPivot.gameObject.tag == tagOfPivot)
			canCollect = true;
	}


	/*private void OnTriggerExit2D (Collider2D colliderOfPivot) {
		if (colliderOfPivot.gameObject.tag == tagOfPivot)
			canCollect = false;
	}*/

}
