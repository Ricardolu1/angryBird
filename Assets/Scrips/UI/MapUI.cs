using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{

    public GameObject lockUI;
    public GameObject starUI;
    public TextMeshProUGUI starCountTextUI;
    private MapLevelUI mapLevelUI;
    private int mapID;

    public void Show(int starCount, MapLevelUI mapLevelUI, int mapID) //default -1
    {
        this.mapLevelUI = mapLevelUI;
        this.mapID = mapID;
        if (starCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            lockUI.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            starUI.SetActive(false);
        }
        else
        {
            GetComponent<Button>().enabled = true;
            lockUI.SetActive(false);
            starUI.SetActive(true);
            starCountTextUI.text = starCount.ToString();
        }
    }
    public void OnClick()
    {
        print("cccc");
        mapLevelUI.OnMapButtonClick(mapID);
    }
}
