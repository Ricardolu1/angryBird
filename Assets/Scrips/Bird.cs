using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot,
    WaitToDie
}

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    public BirdState state = BirdState.BeforeShoot;
    private bool isMouseDown = false;
    public float maxDistance = 2.45f;
    public int flySpeed;
    protected Rigidbody2D rgd;
    public bool isFlying = false;
    public bool isHaveUsedSkill = false;
    private Collider2D colliderObj;

    void Start()
    {
        flySpeed = 24;
        rgd = GetComponent<Rigidbody2D>();
        rgd.bodyType = RigidbodyType2D.Static;
        colliderObj = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                WaitControl();
                break;
            case BirdState.BeforeShoot:
                MouseControl();
                break;
            case BirdState.AfterShoot:
                StopControl();
                SkillControl();
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }
    }

    private void WaitControl()
    {
        colliderObj = GetComponent<Collider2D>();
    }

    private void SkillControl()
    {
        if (isHaveUsedSkill) return;

        if (isFlying == false && Input.GetMouseButtonDown(0))
        {
            isHaveUsedSkill = true;
            FlyingSkill();
        }
        if (Input.GetMouseButtonDown(0))
        {
            isHaveUsedSkill = true;
            FullTimeSkill();
        }
    }
    protected virtual void FlyingSkill()
    {

    }
    protected virtual void FullTimeSkill()
    {
        isHaveUsedSkill = true;
    }
    private void OnMouseDown()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject()==false)
        {
            isMouseDown = true;
            SlingShot.Instance.StartDraw(transform);
            AudioManager.Instance.PlayBirdSelect(transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject()==false )
        {
            isMouseDown = false;
            SlingShot.Instance.EndDraw();
            Fly();
        }
    }

    private void MouseControl()
    {
        if (isMouseDown)
        {
            transform.position = getMounsePositon();
        }
    }

    private Vector3 getMounsePositon()
    {
        Vector3 centerPoint = SlingShot.Instance.GetCenterPointPosition();
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        Vector3 mouseDistance = mp - centerPoint;

        float distance = mouseDistance.magnitude;
        if (distance > maxDistance)
        {
            mp = mouseDistance.normalized * maxDistance + centerPoint;
        }

        return mp;
    }

    private void Fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = (SlingShot.Instance.GetCenterPointPosition() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShoot;

        AudioManager.Instance.PlayBirdFlying(transform.position);
    }

    public void GoState(Vector3 position)
    {
        state = BirdState.BeforeShoot;
        transform.position = position;
    }

    private void StopControl()
    {
        if (rgd.velocity.magnitude < 0.3f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1.0f);
        }
    }

    protected void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == BirdState.AfterShoot)
        {
            isFlying = true;
        }
        if (state == BirdState.AfterShoot && collision.relativeVelocity.magnitude > 5)
        {
            AudioManager.Instance.PlayBirdCollison(transform.position);
        }

    }

}