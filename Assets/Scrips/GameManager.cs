using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }
    public Bird[] birdList;
    private int index = -1;
    private int pigTotalCount;
    private int pigDeadCount;
    
    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
        
    }
    
    void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsSortMode.None).Length ;
        LoadNextBird();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextBird()
    {
        index++;
        if (index >= birdList.Length)
        {
            GameEnd();
        }
        else
        {
            birdList[index].GoState(SlingShot.Instance.GetCenterPointPosition());
        }
    }

    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount >= pigTotalCount)
        {
            GameEnd();
        }
    }
    private void GameEnd()
    {
        print("game End End");
    }
} 