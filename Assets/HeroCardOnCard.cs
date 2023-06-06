using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HeroCardOnCard : MonoBehaviour
{
    HeroCard heroCard;
    CardSkill SkillOfCard;
    [SerializeField] Button CardSkillButton;
    public UnityEvent<float> CardActiveByNum;
    public CardType typeOfCard;
    
    public void SetHeroCard(HeroCard newCard)
    {
        heroCard = newCard;
        SkillOfCard = Instantiate(newCard.Skill, this.transform);
        SkillOfCard.SetHeroCardOnCard(this);
        SkillOfCard.SetButton( CardSkillButton);
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
