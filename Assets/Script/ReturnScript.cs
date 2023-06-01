using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ReturnScript : MonoBehaviour
{
     List<ReturnObject> OrginNum = new List<ReturnObject>();

    public static ReturnScript instance;
    
    int count = 0;

    public UnityEvent<bool> enableCardReturnMode;

    void Awake()
    {
        instance = this;
    }


    bool isReturnModeOn = false;

    private void Start()
    {
        StartCoroutine(enableCardToFalse());
    }

    IEnumerator enableCardToFalse()
    {
        yield return new WaitForSeconds(0.1f);
        enableCardReturnMode.Invoke(false);
    }

    public void CardReturnButton()
    {
        if(isReturnModeOn == true)
        {
            isReturnModeOn = false;
        }
        else
        {
            isReturnModeOn = true;
        }
        enableCardReturnMode.Invoke(isReturnModeOn);
    }





    public void SaveOrginNum(GameObject SaveCard1,GameObject SaveCard2)
    {
        ReturnObject ObjectSaved = new ReturnObject();
        ObjectSaved.Object1 = SaveCard1;
        ObjectSaved.Object2 = SaveCard2;
        ObjectSaved.Object1Value = SaveCard1.GetComponent<CardNum>().Number;
        ObjectSaved.Object2Value = SaveCard2.GetComponent<CardNum>().Number;
        OrginNum.Add(ObjectSaved);
        ObjectSaved.Object2.GetComponent<CardNum>().SetSaveReturnID(count);
        enableCardReturnMode.Invoke(isReturnModeOn);
        count++;
    }
    public void LoadNumber(int num)
    {
        OrginNum[num].Object1.GetComponent<CardNum>().ChangeNumber(OrginNum[num].Object1Value);
        OrginNum[num].Object2.GetComponent<CardNum>().ChangeNumber(OrginNum[num].Object2Value);
        OrginNum[num].Object1.GetComponent<CardDrag>().EnableCard();
    }


}

[System.Serializable]
public class ReturnObject
{
    public GameObject Object1;
    public GameObject Object2;
    public float Object1Value;
    public float Object2Value;


}

