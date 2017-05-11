using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suffocating: PlayerBehaviors {
	private RunningAndSneaking runningScript;
	private Collecting collectingScript;
	private float minSpeed;
	private float maxSpeed;
	public bool startSuffocationAnim;
	public bool startDyingAnim;


	private void Start () {
		runningScript = this.GetComponent<RunningAndSneaking> ();
		collectingScript = this.GetComponent<Collecting> ();
		minSpeed = runningScript.speed * runningScript.fraction;
		maxSpeed = runningScript.speed;
	}


	private void OnTriggerStay2D (Collider2D col2d) {
		if (col2d.gameObject.tag == "Smoke" && collectingScript.isSuffocated) {
			runningScript.speed = minSpeed;
			startSuffocationAnim = true;
			StartCoroutine (PlayerDying());
		}
	}


	private void OnTriggerExit2D (Collider2D col2d) {
		if (col2d.gameObject.tag == "Smoke") {
			runningScript.speed = maxSpeed;
		}		
	}


	IEnumerator PlayerDying() {
		yield return new WaitForSeconds(4);
		startDyingAnim = true;
	}
}
