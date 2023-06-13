using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        Force.SetText(newHealth.ToString());
    }

    public void AddToHealth(float healthToAdd)
    {
        Health += healthToAdd;
        Force.SetText(Health.ToString());
    }

    public void MultiplyToHealth(float healthToMultiply)
    {
        float NewHealth = Health * healthToMultiply;
        Health = NewHealth;
        Force.SetText(Health.ToString());
    }

    public void GetAttacked(float NumToAtk)
    {
        if (Health == NumToAtk)
        {
            Debug.Log("dead");
            TurnManage.instance.SkipTurn();
        }
        else
        {
            Debug.Log("attack failed");
        }

    }

}
