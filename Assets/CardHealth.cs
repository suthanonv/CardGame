using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealth : MonoBehaviour
{
    public float Health;


    public void GetAttacked(float NumToAtk)
    {
        if(Health == NumToAtk)
        {
            TurnManage.instance.SkipTurn();
        }
                
    }

}
