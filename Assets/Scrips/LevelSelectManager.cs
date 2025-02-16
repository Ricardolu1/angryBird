using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager Instance { get; private set; }
    public GameSO gameSO;
    public MapLevelUI mapLevelUI;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mapLevelUI.ShowMapList(gameSO.mapArray);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSlectedMapID(int mapID)
    {
        gameSO.selectedMapID = mapID;
        print(mapID);
    }
    public int[] GetSelectedMap()
    {
        return gameSO.mapArray[gameSO.selectedMapID - 1].starNumberOfLevel;
    }

    public void SetSelectedLevel(int levelID)
    {
        gameSO.selectedLevelID = levelID;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
