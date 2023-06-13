using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Devourace : CardSkill
{
    private int manaCost = 3;
    private GameObject thisCard;

    public override float ActiveCardSkillByNumber(float Number)
    {
        if (GameObject.Find("ManaPool").GetComponent<ManaSystem>().mana >= manaCost)
        {
            thisCard.GetComponent<CardHealth>().MultiplyToHealth(Number);
            GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
            return Number;
        }
        else
        {
            return Number;
        }
    }

    public override void SetHeroCardOnCard(HeroCardOnCard Card)
    {
        thisCard = Card.ThisCard;
    }

    public override void ActiveCardSkillByPassive(float CheckNumber)
    {
        base.ActiveCardSkillByPassive(CheckNumber);
    }

    public override void ActiveCardSkillByPlayer()
    {
     
    }


    public override void SetButton(Button buttonToSet)
    {
        
    }


    private void OnDestroy()
    {
       
    }
}
