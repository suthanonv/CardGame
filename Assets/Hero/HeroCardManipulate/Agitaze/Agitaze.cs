using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agitaze : CardSkill
{
    private int manaCost = 3;
    public override float ActiveCardSkillByNumber(float Number)
    {
        return Number;
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
        if (GameObject.Find("ManaPool").GetComponent<ManaSystem>().mana >= manaCost)
        {
            if (TurnManage.instance.CurrentPLayerTurn == PlayerTurn.Player1)
            {
                List<GameObject> Preplayer2Card = StarterPointPosition.instance.PlayerTwoCard;
                GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
                Preplayer2Card[Random.Range(0, Preplayer2Card.Count)].GetComponent<CardHealth>().SetHealth(-200);
            }
            else
            {
                List<GameObject> Preplayer1Card = StarterPointPosition.instance.PlayerOneCard;
                GameObject.Find("ManaPool").GetComponent<ManaSystem>().ConsumeMana(manaCost);
                Preplayer1Card[Random.Range(0, Preplayer1Card.Count)].GetComponent<CardHealth>().SetHealth(-200);
            }            
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
