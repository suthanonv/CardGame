using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minus : CardSkill
{
    private int manaCost = 2;
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
            teamMateCard.GetComponent<CardHealth>().SubtractFromHealth(900);
        }
    }


    public override void SetButton(Button buttonToSet)
    {
        buttonToSet.onClick.AddListener(ActiveCardSkillByPlayer);
    }


    private void OnDestroy()
    {
       
    }
}
