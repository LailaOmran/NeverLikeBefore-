using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : CameraBehavior {

    void Update()
    {
        /*
        * Zoom out to fit screen.   
        */
        StartCoroutine("ZoomOutToFitScreen");
    }
    IEnumerator ZoomOutToFitScreen()
    {
        while (camera.orthographicSize < CAMERA_SIZE_ZOOM_OUT)
        {
            yield return new WaitForSeconds(0.1f);
            camera.orthographicSize += 0.005f;
        }
    }

}
