using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    [SerializeField]private float num1;
    [SerializeField]private float num2;
    [SerializeField] public GameObject card1;
    [SerializeField] public GameObject card2;
    [SerializeField] private GameObject CalculationMenu;

    private void OnEnable()
    {
        CardDrag.OnMerge += StoreNumber;
    }

    private void OnDisable()
    {
        CardDrag.OnMerge -= StoreNumber;
    }

    void StoreNumber(GameObject Card1, GameObject Card2)
    {
        if (Card1.GetComponent<CardNum>().CardID != Card2.GetComponent<CardNum>().CardID)
        {
            num1 = Card1.GetComponent<CardNum>().Number;
            num2 = Card2.GetComponent<CardNum>().Number;
            card1 = Card1;
            card2 = Card2;
            CalculationMenu.SetActive(true);
        }
        else
        {
            num1 = 0;
            num2 = 0;
            card1 = null;
            card2 = null;
        }
    }

    public void MergePlus()
    {
        float result = num1 + num2;
        math.round(result);
        Merged(result);
    }

    public void MergeMinus()
    {
        float result = num1 - num2;
        math.round(result);
        Merged(result);
    }

    public void MergeMultipy()
    {
        float result = num1 * num2;
        math.round(result);
        Merged(result);
    }

    public void MergeDivide()
    {
        if ( num2 != 0)
        {
            float result = num1 / num2;
            math.round(result);
            Merged(result);
        }
        else
        {
            Debug.Log("Error");
            CalculationMenu.SetActive(false);
        }
        
    }

    public void Merged(float result)
    {
        card1.GetComponent<CardDrag>().DisableCard();
        card2.GetComponent<CardNum>().ChangeNumber(result);
        CalculationMenu.SetActive(false);
    }
}
