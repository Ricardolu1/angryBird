using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouseBird : Bird
{
    protected override void FlyingSkill()
    {
        Vector2 velocity = rgd.velocity;
        velocity.x = -velocity.x;
        rgd.velocity = velocity;

        Vector3 scale = transform.localScale;
        scale.x = -transform.localScale.x;
        transform.localScale = scale;
    }
}
