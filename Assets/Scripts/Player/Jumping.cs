using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : PlayerBehaviors
{
    public float jumpingSpeed = 20;
    private bool space;
    private float holdTime;


    private void Update()
    {
        space = inputState.GetButtonValue(buttons[0]);
        holdTime = inputState.GetButtonHoldTime(buttons[0]);

        if (collisionState.isStanding)
        {
            if (space && holdTime < 0.1f)
            {
                Jump();
            }
        }
    }


    protected virtual void Jump()
    {
        body2d.velocity = new Vector2(body2d.velocity.x, jumpingSpeed);
        Debug.Log(body2d.velocity);

    }
}
