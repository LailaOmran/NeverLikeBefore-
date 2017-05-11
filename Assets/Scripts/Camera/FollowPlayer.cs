using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : CameraBehavior
{
    private PlayerDirection playerDirection;
    private CollisionState collisionState;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float xOffset = 20f;
    private float yOffset = 3f;
    private float smoothTime = 0.75f;
    private float speed = 3f;

    void Start()
    {
        playerDirection = player.GetComponent<PlayerDirection>();
        collisionState = player.GetComponent<CollisionState>();

    }

    void Update()
    {
        SetPositionInFrontPlayer();
    }

    private void SetPositionInFrontPlayer()
    {
        /*
         * Position the camera in front of the player.
         */
        var direction = (int) playerDirection.inputState.direction;
        var pos = player.transform.position;
        pos.x = pos.x + (xOffset * direction);
        pos.y = camera.transform.position.y;
        pos.z = -10;
        transform.position = SmoothMotion(transform.position, pos, ref xVelocity, ref yVelocity, smoothTime);
    }
}
