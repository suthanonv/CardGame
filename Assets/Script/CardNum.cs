using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class CardNum : MonoBehaviour
{
    private int Number;
    [SerializeField] private TextMeshProUGUI text;
    private void OnEnable()
    {
        RandomNumber();
    }

    private void Update()
    {
        text.SetText(Number.ToString());
    }

    void RandomNumber()
    {
        Number = UnityEngine.Random.Range(1, 10);
    }
}
