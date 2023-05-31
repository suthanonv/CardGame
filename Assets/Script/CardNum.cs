using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class CardNum : MonoBehaviour
{
    public float Number;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] public int CardID;
    private void OnEnable()
    {
        RandomNumber();
    }

    void RandomNumber()
    {
        Number = UnityEngine.Random.Range(1, 10);
        math.round(Number);
        text.SetText(Number.ToString());
    }

    public void ChangeNumber(float NumToChangeTo)
    {
        Number = NumToChangeTo;
        text.SetText(Number.ToString());
    }
}
