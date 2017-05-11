using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BoxCollider2D GameBoundaries;

    public Rect GetSceneBoundaries()
    {
        
        var boundingBox = GameBoundaries.bounds;
        var sceneBound = new Rect(boundingBox.min.x, boundingBox.min.y, boundingBox.size.x, boundingBox.size.y);
        return sceneBound;
    }





}
