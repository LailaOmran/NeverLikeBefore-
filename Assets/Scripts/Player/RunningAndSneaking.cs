using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAndSneaking :PlayerBehaviors {
	public float speed = 5;
	public float fraction = 0.5f;

	private void Update() {
		bool right = inputState.GetButtonValue(buttons[0]);
		bool left = inputState.GetButtonValue (buttons[1]);
		bool ctrl = inputState.GetButtonValue (buttons[2]);
		if (right || left) {
			
			float velX = speed;

			if (ctrl && fraction < 1)
				velX *= fraction;
			
			velX = velX * (float)inputState.direction;
			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		} 
		else
			body2d.velocity = new Vector2 (0, body2d.velocity.y);
	}
}
