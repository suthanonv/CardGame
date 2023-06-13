using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hepast : CardSkill
{
    private int manaCost = 4;
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
            teamMateCard.GetComponent<CardHealth>().MultiplyToHealth(3);
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
