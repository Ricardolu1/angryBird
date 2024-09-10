using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Destructiable : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;
    public List<Sprite> injuredSpriteList;
    public SpriteRenderer spriteRenderer;
    
    

    private GameObject boomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        print((int)(-0.5));
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
        boomPrefab = Resources.Load<GameObject>("boom1");
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

            if (index != -1 && index < injuredSpriteList.Count)
            {
                
                // print("aaa"+ GetComponent<GameObject>());
                // print("asdas" + spriteRenderer.sprite);
                // print("更改参数后:" + index);
                // print("更改参数后:asd" + index);
                // print("更改参数后:asda" + index);
                // print("更改参数后:asd" + index);
                // print("更改参数后:ddd" + (maxHp - currentHp));
                spriteRenderer.sprite = injuredSpriteList[index];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void Dead()
    {
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}