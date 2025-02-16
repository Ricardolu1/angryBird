using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameSO : ScriptableObject
{
    public MapSO[] mapArray;
    public int selectedMapID = -1;
    public int selectedLevelID = -1;
}

