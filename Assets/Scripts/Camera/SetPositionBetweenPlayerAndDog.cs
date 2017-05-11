using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionBetweenPlayerAndDog : CameraBehavior
{
    public GameObject Dog;
    private bool isDogPresent;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float smoothTime = 0.75f;

    void Start()
    {
        isDogPresent = false;
    }

    void Update()
    {
        if (isDogPresent)
        {
            SetCameraBetweenPlayerAndDog(player.transform.position, Dog);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            isDogPresent = true;
        }
    }

    private void SetCameraBetweenPlayerAndDog(Vector3 position, GameObject dog)
    {
        /*
         * Disable the follow playerbehavior of the camera. 
         */

        /*
         * Get average position between player and dog.
         */
        var averagePos = (dog.transform.position + position) / 2;
        averagePos.z = -1;
        //camera.transform.position = averagePos;

        camera.transform.position = SmoothMotion(camera.transform.position,
            averagePos, ref xVelocity, ref yVelocity, smoothTime);
    }
}
