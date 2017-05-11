using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuckingAndCrawling : PlayerBehaviors
{
    private CapsuleCollider2D collider2d;
    private Vector2 colliderOffset;
    public float colliderOffsetY;
    public float scale = 0.5f;
    public bool isDucking;


    protected override void Awake()
    {
        base.Awake();
        collider2d = this.GetComponent<CapsuleCollider2D>();
        colliderOffset = this.collider2d.offset;
    }


    private void Update()
    {
        bool down = inputState.GetButtonValue(buttons[0]);
        if (down && !isDucking && collisionState.isStanding)
            Duck(true);
        else if (!down && isDucking)
            Duck(false);
    }


    protected virtual void Duck(bool isDucking)
    {
        this.isDucking = isDucking;

        Vector2 size = collider2d.size;
        float constant;
        float newOffsetY;

        if (isDucking)
        {
            this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.x);
            constant = scale;
            newOffsetY = collider2d.offset.y - (size.y / 2 * colliderOffsetY);
        }
        else
        {
            this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            constant = 1 / scale;
            newOffsetY = colliderOffset.y;
        }
        size *= constant;
        collider2d.size = size;
        collider2d.offset = new Vector2(collider2d.offset.x, newOffsetY);
    }
}
