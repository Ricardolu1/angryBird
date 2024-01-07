using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot
}
public class Bird : MonoBehaviour
{
    // Start is called before the first frame update

    public BirdState state = BirdState.BeforeShoot;

    private bool isMouseDown = false;

    private float maxDistance = 2.4f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                break;
            case BirdState.BeforeShoot:
                MouseControl();
                break;
            case BirdState.AfterShoot:
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
        Vector3 mouseDistance = mp -  centerPoint;


        float distance = mouseDistance.magnitude;
        if (distance > maxDistance)
        {
            mp = mouseDistance.normalized * maxDistance + centerPoint;
        }

        return mp;
    }
}
