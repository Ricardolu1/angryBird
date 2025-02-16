using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject lockGo;
    public GameObject unlockGo;
    public TextMeshProUGUI levelNumberText;
    public GameObject start0Go;
    public GameObject start1Go;
    public GameObject start2Go;
    public GameObject start3Go;
    MapLevelUI mapLevelUI;
    int mapLevelID;

    private void HideStar()
    {
        start0Go.SetActive(false);
        start1Go.SetActive(false);
        start2Go.SetActive(false);
        start3Go.SetActive(false);
    }
    public void Show(int starCount, int mapLevelID, MapLevelUI mapLevelUI)
    { //default -1
        this.mapLevelUI = mapLevelUI;
        this.mapLevelID = mapLevelID;
        levelNumberText.text = mapLevelID.ToString();
        HideStar();
        if (starCount < 1)
        {
            lockGo.SetActive(true);
            unlockGo.SetActive(false);
        }
        else
        {
            lockGo.SetActive(false);
            unlockGo.SetActive(true);
            if (starCount == 0)
            {
                start0Go.SetActive(true);
            }
            else
            {
                if (starCount == 1)
                {
                    start1Go.SetActive(true);
                }
                else if (starCount == 2)
                {
                    start2Go.SetActive(true);
                }
                else if (starCount == 3)
                {
                    start3Go.SetActive(true);
                }
            }
        }

    }

    public void OnClick()
    {
        mapLevelUI.OnLevelBtnClick(mapLevelID);
    }
}
