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
    private FollowTarget cameraTarget;
    public GameOverUI gameOverUI;



    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }

    IEnumerator DelayedAction(float delay)
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(delay);

        // 调用带参数的函数
         Time.timeScale = 0;
    }
    void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsSortMode.None).Length;
        cameraTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();
        print("asdasdasd" + cameraTarget);
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
            GameOver();
        }
        else
        {
            birdList[index].GoState(SlingShot.Instance.GetCenterPointPosition());
            cameraTarget.SetTarget(birdList[index].transform);
        }
    }

    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount >= pigTotalCount)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        int startCount = 0;
        float pigDeadPercent = pigDeadCount * 1f / pigTotalCount;
        if (pigDeadPercent >= 0.99f)
        {
            startCount = 3;
        }
        else if (pigDeadPercent >= 0.66f)
        {
            startCount = 2;
        }
        else if (pigDeadPercent >= 0.33f)
        {
            startCount = 1;
        }
        gameOverUI.Show(startCount);
        StartCoroutine(DelayedAction(1f));
        print("game End End");
    }

    public void RestarLevel (){
        // todo
    }

    public void LevelList(){
        // todo
    }

    //加载界面  //关卡选择  //游戏场景
}