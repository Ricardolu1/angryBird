using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    public GameObject failPig;
    private int startCount;
    public StarUI starUI1;
    public StarUI starUI2;
    public StarUI starUI3;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Show(int startCount)
    {
        anim.SetBool("IsShow",true);
        print("gameOVerioisisisis");
        this.startCount = startCount;
    }

    private void Start()
    {
    }

    public void ShowStar()
    {
        if (startCount == 0)
        {
            failPig.SetActive(true);
        }
        if (startCount >= 1)
        {
            starUI1.Show();
        }
        if (startCount >= 2)
        {
            starUI2.Show();
            print("show222222");
        }
        if (startCount >= 3)
        {
            starUI3.Show();
        }
        print("startCount" + startCount);
    }
    public void OnRestarBtnClick()
    {
        GameManager.Instance.RestarLevel();
    }
    public void OnLevelListBtnClick()
    {
        GameManager.Instance.LevelList();
    }
}
