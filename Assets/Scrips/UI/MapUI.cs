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

    public void Show(int starCount) //default -1
    {
        if (starCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            lockUI.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
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
}
