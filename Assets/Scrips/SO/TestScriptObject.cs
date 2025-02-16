using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu()]
public class TestScriptObject : ScriptableObject
{
    // Start is called before the first frame update
    public new string name;
    public int level;
    public int[] levelData;
}
