using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coalesce : CardSkill
{
    private int manaCost = 3;
    private GameObject teamMateCard;

    public override float ActiveCardSkillByNumber(float Number)
    {
        return Number;
    }

    public override void SetHeroCardOnCard(HeroCardOnCard Card)
    {
        teamMateCard = Card.TeamMateCard;
    }

    public override void ActiveCardSkillByPassive(float CheckNumber)
    {
        base.ActiveCardSkillByPassive(CheckNumber);
    }

    public override void ActiveCardSkillByPlayer()
    {
        if (GameObject.Find("ManaPool").GetComponent<ManaSystem>().mana >= manaCost)
        {
            GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
            teamMateCard.GetComponent<CardHealth>().AddToHealth(91);
        }
    }


    public override void SetButton(Button buttonToSet)
    {
        Debug.Log(buttonToSet.gameObject.name);
        buttonToSet.onClick.AddListener(ActiveCardSkillByPlayer);
    }


    private void OnDestroy()
    {
       
    }
    
}
