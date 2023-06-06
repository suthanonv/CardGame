using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pythagoras : CardSkill
{
 

    public override float ActiveCardSkillByNumber(float Number)
    {
        return Number * Number;
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
     
    }


    public override void SetButton(Button buttonToSet)
    {
        
    }


    private void OnDestroy()
    {
       
    }
}
