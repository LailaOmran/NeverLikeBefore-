using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : PlayerBehaviors {
	#region Fields
	public CollisionOnGround isCollidedOnGround;
	public int numOfTrajectoryPoints = 5;
	public bool startThrowingAnim;

	private Collecting collecting;
	private List<GameObject> trajectoryPoints = new List<GameObject>();
	private float keyHoldTime = 0;
	private float dx;
	private float dy;
	private int count = 0;
	private bool isPressed;
	private Vector2 initialVelocity = Vector2.zero;
	private Rigidbody2D collectedObjectBody2d;
	#endregion

	protected override void Awake () {
		base.Awake ();
		collecting = this.GetComponent<Collecting> ();
	}

	private void Start () {
		startThrowingAnim = false;
	}


	private void Update () {
		bool z = inputState.GetButtonValue (buttons[0]);

		//When the rock is being thrown
		if (z /*&& collecting.wasCollected*/) {
			isPressed = true;
			CalculateThrowingEquations ();
			//DrawThrowingTrajectory ();
		}

		//After the rock has been thrown
		else if (!z && isPressed) {
			startThrowingAnim = true;
			ThrowTheObject ();
		}
	}
		
	private void CalculateThrowingEquations () {
		//calculate key hold time
		keyHoldTime = Mathf.Clamp(inputState.GetButtonHoldTime (buttons[0]), 1, 10);

		//calculate initialVelocity of throwing
		initialVelocity = new Vector2 (5*keyHoldTime, 5*keyHoldTime);

		//calculate distance 
		dx = initialVelocity.x * Time.deltaTime;
		dy = initialVelocity.y * Time.deltaTime - (0.5f *10* Mathf.Pow(Time.deltaTime, 2));

	}

	private void DrawThrowingTrajectory() {
		//trajectoryPoints[count].transform.position = new Vector3(
		//	collecting.collectedObject.transform.localScale.x +trajectoryPoints[count].transform.position.x + dx,
		//	collecting.collectedObject.transform.localScale.y +trajectoryPoints[count].transform.position.y + dy, 0);
		//trajectoryPoints [count].GetComponent<SpriteRenderer> ().enabled = true;
		//count++;
		//if (count == numOfTrajectoryPoints)
		//	count = 0;
	}

	public void ThrowTheObject () {
		//collecting.collectedObject.gameObject.transform.SetParent (null);

		if (collectedObjectBody2d == null)
		//	collectedObjectBody2d = collecting.collectedObject.transform.gameObject.AddComponent<Rigidbody2D> ();

		collectedObjectBody2d.gravityScale = 10;
		collectedObjectBody2d.mass = 1;
		collectedObjectBody2d.freezeRotation = true;
		//collecting.collectedObject.GetComponent<Collider2D> ().isTrigger = false;

		collectedObjectBody2d.position = new Vector2 (collectedObjectBody2d.position.x + (float)dx, 
			collectedObjectBody2d.position.y + (float)dy);

		if (isCollidedOnGround.done)
			isPressed = false;
	}
}
