using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealth : MonoBehaviour
{
    public float Health;

    public void SetHealth(float newHealth)
    {
        Health = newHealth;
    }

    public void GetAttacked(float NumToAtk)
    {
        if(Health == NumToAtk)
        {
            TurnManage.instance.SkipTurn();
        }
                
    }

}
