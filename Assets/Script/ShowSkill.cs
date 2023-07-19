using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkill : MonoBehaviour
{
    private HeroCard herocard;
    [SerializeField] public GameObject Skill_Info;

    private void Start()
    {
        if (this.gameObject.GetComponent<SetHeroInfo>() == null)
        {
            herocard = this.GetComponent<HeroCardOnCard>().heroCard;
        }
        else
        {
            herocard = this.GetComponent<SetHeroInfo>().heroCard;
        }
    }

    public void ShowSkillInfo()
    {
        Skill_Info.SetActive(true);
        Skill_Info.GetComponent<SetSKillInfo>().SetInfo(herocard.Skill_Info);
    }
}
