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
        }

    }




    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot)
        {
            isMouseDown = false;
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
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        return mp;
    }
}
