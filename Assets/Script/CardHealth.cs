using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardHealth : MonoBehaviour
{
    public float Health;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Force;
    public TextMeshProUGUI Skill;
    public HeroCard heroCard;

    private void Awake()
    {
        heroCard = this.gameObject.GetComponent<HeroCardOnCard>().heroCard;
    }

    private void Start()
    {
        Name.SetText(heroCard.Name);
        Force.SetText(heroCard.Force.ToString());
        Skill.SetText(heroCard.SkillCost.ToString());
    }

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
