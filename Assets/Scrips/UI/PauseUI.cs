using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    // Start is called before the first frame update
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        anim.SetBool("IsShow", true);
    }
    public void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        anim.SetBool("IsShow", false);
    }
    public void OnRestartButtonClick()
    {
        //todo
    }
    public void OnLevlListButtonClick()
    {
        //todo
    }




}
