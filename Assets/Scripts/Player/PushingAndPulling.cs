using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAndPulling : MonoBehaviour {
	public Buttons[] btn;
	public float factor;
	private Rigidbody2D obstacleBody2d;
	private InputState inputState;
	private FixedJoint2D joint2d;
	private bool isReadyToPush = false;

	private void Awake () {
		inputState = GameObject.FindGameObjectWithTag ("Player").GetComponent<InputState> ();
		obstacleBody2d = this.GetComponent<Rigidbody2D> ();
		joint2d = this.GetComponent<FixedJoint2D> ();
		joint2d.enabled = false;
	}

	private void Update () {
		bool right = inputState.GetButtonValue (btn [0]);
		bool left = inputState.GetButtonValue (btn [1]);
		bool x = inputState.GetButtonValue (btn [2]);

		if (isReadyToPush) {
			if (right || left) {
				if (x) {
					this.obstacleBody2d.bodyType = RigidbodyType2D.Dynamic;
					PushOrPull (factor);
				} else {
					this.obstacleBody2d.bodyType = RigidbodyType2D.Static;
					Leave ();
				}
			}
		}
	}
	private void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			isReadyToPush = true;
		}
	}

	private void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			isReadyToPush = false;
		}
	}


	private void PushOrPull(float factor) {
		joint2d.enabled = true;
		Vector2 pushForce = new Vector2(obstacleBody2d.mass * obstacleBody2d.gravityScale * (float)inputState.direction * factor, 0);
		obstacleBody2d.AddForce (pushForce, ForceMode2D.Force);
	}


	private void Leave(){
		joint2d.enabled = false;
	}
}
