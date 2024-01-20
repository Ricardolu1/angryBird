using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;
    public List<Sprite> injuredSpriteList;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {   
        
        print((int)(-0.5));
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.relativeVelocity.magnitude);
        if (currentHp < 0)
        {
            Dead();
            
            
            
            return; 
        }
        else
        {
            currentHp -= (int)(collision.relativeVelocity.magnitude * 8);
            int index = (int)(((maxHp - currentHp) / (maxHp / injuredSpriteList.Count + 1.0f))) - 1;
            if (index >= 0 )
            {
                spriteRenderer.sprite = injuredSpriteList[index];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}