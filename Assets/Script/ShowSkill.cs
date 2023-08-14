using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkill : MonoBehaviour
{
    private HeroCard herocard;
    [SerializeField] public GameObject Skill_Info;

    public void GetSkill()
    {
        if (this.gameObject.GetComponent<SetHeroInfo>() == null)
        {
            herocard = this.GetComponent<HeroCardOnCard>().HeroCard;
        }
        else
        {
            herocard = this.GetComponent<SetHeroInfo>().heroCard;
            Debug.Log(herocard.name.ToString());
        }
    }

    public void ShowSkillInfo()
    {
        Skill_Info.SetActive(true);
        Skill_Info.GetComponent<SetSKillInfo>().SetInfo(herocard.Skill_Info);
    }
}
