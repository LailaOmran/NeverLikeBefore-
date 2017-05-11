using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBehavior : MonoBehaviour {
    public new Camera camera;
    public GameObject player;
    protected bool shaking;
    private ZoomIn zoomIn;
    private ZoomOut zoomOut;
    private Shake shake;
    protected FollowPlayer followPlayer;
    protected const float CAMERA_SIZE_ZOOM_IN = 20.6f;
    protected const float CAMERA_SIZE_ZOOM_OUT = 21.0f;

    void Start()
    {
        followPlayer = camera.GetComponent<FollowPlayer>();
        zoomOut = GetComponent<ZoomOut>();
        shake = GetComponent<Shake>();
        zoomIn = camera.GetComponent<ZoomIn>();
    }

    protected void EnableFollowPlayerBehavior()
    {
        followPlayer.enabled = true;
    }

    protected void DisableFollowPlayerBehavior()
    {
        //zoomIn.enabled = false;
        followPlayer.enabled = false;
    }

    protected void EnableZoomOut()
    {
        zoomOut.enabled = true;
    }

    protected void DisableZoomOut()
    {
        zoomOut.enabled = false;
    }

    protected void EnableZoomIn()
    {
        zoomIn.enabled = true;
    }

    protected void DisableZoomIn()
    {
        zoomIn.enabled = false;
    }

    protected void Shake()
    {
        shaking = true;
        shake.enabled = true;
    }

    protected void Unshake()
    {
        shaking = false;
        shake.enabled = false;
    }

    protected Vector3 SmoothMotion(Vector3 followerPosition, Vector3 targetPosition, ref float xVelocity,
        ref float yVelocity, float smoothTime)
    {
        float newXPosition = Mathf.SmoothDamp(followerPosition.x, targetPosition.x, ref xVelocity, smoothTime);
        float newYPosition = Mathf.SmoothDamp(followerPosition.y, targetPosition.y, ref yVelocity, smoothTime);
        followerPosition = new Vector3(newXPosition, newYPosition, targetPosition.z);
        return followerPosition;
    }
}
