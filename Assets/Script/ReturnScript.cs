using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnScript : MonoBehaviour
{
    public List<ReturnObject> OrginNum = new List<ReturnObject>();


}

[System.Serializable]
public class ReturnObject
{
    public GameObject Object1;
    public GameObject Object2;
    public int Object1Value;
    public int Object2Value;


}

