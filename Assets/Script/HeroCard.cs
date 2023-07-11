using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    NeedNumberToActiveSkill,PassiveSkill,NeedPlayerInput
}


[CreateAssetMenu]
public class HeroCard : ScriptableObject
{

    public string Name;

    public int SummonCost;

    public float Force;

    public int SkillCost;
    public CardType CardType;
    public CardSkill Skill;
    public string Skill_Info;

}
