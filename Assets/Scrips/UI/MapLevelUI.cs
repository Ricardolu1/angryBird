using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelUI : MonoBehaviour
{
    public GameObject mapListGO;
    public GameObject levelGridGO;
    public List<MapUI> mapUIList;
    public GameObject LevelPrefabTemplate;


    public void ShowMapList(MapSO[] mapArray)
    {
        mapListGO.SetActive(true);
        levelGridGO.SetActive(false);
        UpdateMapUIList(mapArray);
    }

    private void UpdateMapUIList(MapSO[] mapArray)
    {
        for (int i = 0; i < mapArray.Length; i++)
        {
            mapUIList[i].Show(mapArray[i].starNumberOfMap, this, i + 1);
        }
    }

    public void OnMapButtonClick(int mapID)
    {
        print("addeee==" + mapID);
        LevelSelectManager.Instance.SetSlectedMapID(mapID);
        ShowLevelGrid();
    }
    private void ShowLevelGrid()
    {
        mapListGO.SetActive(false);
        levelGridGO.SetActive(true);
        int[] starNumberOfLevel = LevelSelectManager.Instance.GetSelectedMap();
        for (int i = 0; i < starNumberOfLevel.Length; i++)
        {
            GameObject go = GameObject.Instantiate(LevelPrefabTemplate);
            go.GetComponent<RectTransform>().SetParent(levelGridGO.transform);
            go.GetComponent<LevelUI>().Show(starNumberOfLevel[i], i + 1, this);
        }
    }

    public void OnLevelBtnClick(int levelID){
        LevelSelectManager.Instance.SetSelectedLevel(levelID);
    }
}