using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingurge : CardSkill
{
    private int manaCost;
    private int turnCheck;
    private bool isSkillUsed = true;
    private int StoredNumber;
    
    public override void SetHeroCardOnCard(HeroCardOnCard Card)
    {

    }


    public override void ActiveCardSkillByPassive(float CheckNumber)
    {
        base.ActiveCardSkillByPassive(CheckNumber);
    }

    public override float ActiveCardSkillByNumber(float Number)
    {
        if (Number % 2 == 0)
        {
            manaCost = (int)Number / 2;
            turnCheck = TurnManage.turnCount;
            isSkillUsed = false;
            StoredNumber = (int)Number;
            GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
            return Number;
        }
        else
        {
            return Number;
        }
        
    }

    public void Update()
    {
        if (isSkillUsed == false)
        {
            if (TurnManage.turnCount == turnCheck + 1)
            {
                isSkillUsed = true;
                GameObject.Find("ManaPool").GetComponent<ManaSystem>().AddToMana(StoredNumber);
            }
        }
    }


    public override void ActiveCardSkillByPlayer()
    {

    }

    public override void SetButton(Button buttonToSet)
    {
       
    }
    
}
