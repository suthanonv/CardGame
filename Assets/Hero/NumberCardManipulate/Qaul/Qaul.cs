using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Qaul : CardSkill
{

    private int manaCost = 1;

    public override float ActiveCardSkillByNumber(float Number)
    {
        if (GameObject.Find("ManaPool").GetComponent<ManaSystem>().mana >= manaCost)
        {
            GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
            return Random.Range(1, 10);
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
