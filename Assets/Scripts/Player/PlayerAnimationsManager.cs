using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : PlayerBehaviors
{
    //private DuckingAndCrawling ducking;
    private Animator anim;
    private Collecting collecting;
    //private Throwing throwing;
    private Suffocating suffocating;
    private bool startJumpAnim = false;

    protected override void Awake()
    {
        base.Awake();
        //ducking = this.GetComponent<DuckingAndCrawling> ();
        collecting = this.GetComponent<Collecting>();
        //throwing = this.GetComponent<Throwing>();
        suffocating = this.GetComponent<Suffocating>();
        anim = this.GetComponent<Animator>();
    }


    private void Update()
    {
        //idle
        if (collisionState.isStanding && !startJumpAnim)
            ChangeAnimationState(0);

        /*   //jumpingDown
           if (absVelY > 0 && absVelX > 0 && !collisionState.isStanding)
               ChangeAnimationState(4);
         */


        //running
        if (absVelX > 1 && collisionState.isStanding)
            ChangeAnimationState(1);

        //jumping
        if (/*absVelY > 0*/inputState.GetButtonValue (buttons [1]))
            ChangeAnimationState(3);


        //sneaking
        if (inputState.GetButtonValue(buttons[0]))
            ChangeAnimationState(2);




        //        //collecting
        //        if (collecting.startCollectingAnim) {
        //            ChangeAnimationState (9);
        //            if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1f) {
        //                collecting.startCollectingAnim = false;
        //            }
        //        }
        //
        //        //throwing
        //        if (throwing.startThrowingAnim) {
        //            ChangeAnimationState (10);
        //            if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1f)
        //                throwing.startThrowingAnim = false;
        //        }
        //
        //        //suffocating
        //        if (suffocating.startSuffocationAnim) {
        //            if (absVelX > 1)
        //                ChangeAnimationState (2);
        //            else
        //                ChangeAnimationState (11);
        //        }
        //
        //        //dying
        //        if (suffocating.startDyingAnim)
        //            ChangeAnimationState (12);
        //
        //        //ducking
        //        /*if (ducking.isDucking)
        //            ChangeAnimationState (4);
        //        
        //        //suffocating
        //        if (isSuffocating)
        //            ChangeAnimationState (5);*/
    }


    private void ChangeAnimationState(int animState)
    {
        anim.SetInteger("AnimState", animState);
    }

}