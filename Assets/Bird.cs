using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot
}
public class Bird : MonoBehaviour
{   // �ȴ� ����ǰ �����
    // Start is called before the first frame update


    public BirdState state = BirdState.BeforeShoot; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           
    }
    

    private void OnMouseDown()
    {
        

    }

    private void OnMoun


    
    private void OnMouseUp()
    {
        
    }

}
