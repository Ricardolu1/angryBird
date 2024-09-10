using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Properties;
using UnityEngine;

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
    public float maxDistance = 2.4f;
    public int flySpeed;
    private Rigidbody2D rgb;

    void Start()
    {
        flySpeed = 16;
        rgb = GetComponent<Rigidbody2D>();
        rgb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MouseControl();
                break;
            case BirdState.AfterShoot:
                StopControl();
                break;
            case BirdState.WaitToDie:
                LoadNextBird();
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        if (state == BirdState.BeforeShoot)
        {
            isMouseDown = true;
            SlingShot.Instance.StartDraw(transform);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot)
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
        rgb.bodyType = RigidbodyType2D.Dynamic;
        rgb.velocity = (SlingShot.Instance.GetCenterPointPosition() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShoot;
    }

    public void GoState(Vector3 position)
    {
        state = BirdState.BeforeShoot;
        transform.position = position;
    }

    private void StopControl()
    {
        if (rgb.velocity.magnitude < 0.1f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1.0f);
        }
    }

    private void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }
}