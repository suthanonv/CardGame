using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kritas : CardSkill
{
    private int manaCost = 2;
    public override float ActiveCardSkillByNumber(float Number)
    {        if (GameObject.Find("ManaPool").GetComponent<ManaSystem>().mana >= manaCost)
        {
            GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
            Number = 0;
            return Number;
        }
        else
        {
            return Number;
        }
        
    }

    public override void SetHeroCardOnCard(HeroCardOnCard Card)
    {
        
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
