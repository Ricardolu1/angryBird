using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackBird : Bird
{
    public float boomRadius = 2.5f;
    protected override void FullTimeSkill()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, boomRadius);
        foreach (Collider2D collider in collider2Ds)
        {
            Destructiable des = collider.GetComponent<Destructiable>();
            if (des != null)
            {   
                des.TakeDamage(int.MaxValue);
                
            }
        }
        state = BirdState.WaitToDie;
        LoadNextBird();
    }
}
