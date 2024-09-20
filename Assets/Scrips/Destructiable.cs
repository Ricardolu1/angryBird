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
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
        boomPrefab = Resources.Load<GameObject>("boom1");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("damage============" + damage + "======" + gameObject.name);
        if (currentHp <= 0)
        {
            Dead();
            return;
        }

        // 确保damage是非负数
        if (damage < 0)
        {
            Debug.LogWarning("Damage cannot be negative.");
            return;
        }

        currentHp -= damage;

        // 确保 currentHp 不小于 0
        if (currentHp < 0)
        {
            currentHp = 0;
        }

        UpdateInjuredState();

    }


    private void UpdateInjuredState()
    {
        if (maxHp > 0 && injuredSpriteList.Count > 0)
        {

            if (currentHp == 0)
            {
                Dead();
                return;
            }

            // 计算健康比例
            float healthRatio = (float)currentHp / maxHp;

            // 计算索引值
            int index = Mathf.Clamp((int)((1 - healthRatio) * injuredSpriteList.Count), 0, injuredSpriteList.Count - 1);

            // 更新受伤状态
            if (index >= 0 && index < injuredSpriteList.Count)
            {
                Sprite beforeSprite = spriteRenderer.sprite;
                spriteRenderer.sprite = injuredSpriteList[index];

                if (beforeSprite != spriteRenderer.sprite)
                {
                    PlayAudioCollision();
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage((int)(collision.relativeVelocity.magnitude * 8));
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void PlayAudioCollision()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);
    }
    protected virtual void PlayAudioDestroyed()
    {
        AudioManager.Instance.PlayWoodDestroyed(transform.position);
    }

    public virtual void Dead()
    {
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        PlayAudioDestroyed();
        Destroy(gameObject);
    }
}