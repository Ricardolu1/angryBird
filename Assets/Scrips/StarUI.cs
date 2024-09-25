using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class StarUI : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Show()
    {
        anim.SetTrigger("IsShow");
    }
  
}
