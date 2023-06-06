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

    [SerializeField] public List<int> ReturnNum = new List<int>();

    private void OnEnable()
    {
        RandomNumber();
    }

    void RandomNumber()
    {
        Number = UnityEngine.Random.Range(1, 10);
        math.round(Number);
    }

    public void ChangeNumber(float NumToChangeTo)
    {
        Number = NumToChangeTo;
        text.SetText(Number.ToString());
    }

    public void SetSaveReturnID(int Num)
    {
        ReturnNum.Add(Num);
    }

    public void Return()
    {
       
     ReturnScript.instance.LoadNumber(ReturnNum[ReturnNum.Count - 1]);
     ReturnNum.Remove(ReturnNum[ReturnNum.Count - 1]);

        if(ReturnNum.Count <= 0)
        {
            this.GetComponent<CardDrag>().EnableCardReturnButton(false);
        }
    }


  public  bool CanMearge;
    public void FaceUpCardTrue(bool isFaceUp)
    {
        CanMearge = isFaceUp;
        if (isFaceUp)
        {
            text.SetText(Number.ToString());
        }
        else
        {
            text.SetText("");
        }
    }
    }
