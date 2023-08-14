using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetHeroInfo : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Force;
    public TextMeshProUGUI Skill;
    public Image image;
    public HeroCard heroCard;

    private bool isSelected = false;

    public static event HandleHeroCardInfo OnCardSelected;
    public delegate void HandleHeroCardInfo(HeroCard heroCard);

    public static event HandleRemoveHeroCard OnCardDiselected;
    public delegate void HandleRemoveHeroCard(HeroCard heroCard);

    private void OnEnable()
    {
        HeroCardList.OnConfirm += DiselectedCard;
    }

    private void OnDisable()
    {
        HeroCardList.OnConfirm -= DiselectedCard;
    }

    private void Start()
    {
        image = this.GetComponent<Image>();
        Name.SetText(heroCard.Name);
        Force.SetText(heroCard.Force.ToString());
        Skill.SetText(heroCard.SkillCost.ToString());
        image.sprite = heroCard.HeroArt;

    }

    public void Selected()
    { 
        if (isSelected == false && HeroCardList.isCardSelectedMax == false)
        {
            if (HeroCardList.player1Selection == true)
            {
                this.GetComponent<Image>().color = Color.green;   
            }
            else if(HeroCardList.player1Selection == false)
            {
                this.GetComponent<Image>().color = Color.red;
            }
            OnCardSelected?.Invoke(heroCard);
            isSelected = true;
        }else if (isSelected == true)
        {
            this.GetComponent<Image>().color = Color.white;
            OnCardDiselected?.Invoke(heroCard);
            isSelected = false;
        }
    }

    void DiselectedCard()
    {
        this.GetComponent<Image>().color = Color.white;
        isSelected = false;
    }
    
}
