using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HeroCardOnCard : MonoBehaviour
{
   [SerializeField]public HeroCard heroCard;
    CardSkill SkillOfCard;
    Button CardSkillButton;

    public CardType typeOfCard;

    private void Start()
    {
        CardSkillButton = this.GetComponent<Button>();
        SetHeroCard(heroCard);
    }

    public void SetHeroCard(HeroCard newCard)
    {
        heroCard = newCard;
        SkillOfCard = Instantiate(newCard.Skill, this.transform);
        SkillOfCard.SetHeroCardOnCard(this);
        SkillOfCard.SetButton( CardSkillButton);
        this.GetComponent<CardHealth>().SetHealth(heroCard.Force);
        typeOfCard = heroCard.CardType;
    }
 
    public CardType GetCardType()
    {
        return typeOfCard;
    }

    public CardSkill GetSkillCard()
    {
        return SkillOfCard;
    }
}
