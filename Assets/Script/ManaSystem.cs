using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaSystem : MonoBehaviour
{

    public TextMeshProUGUI Text;

    public int mana;

    public void LoadMana(int turnCount)
    {
        mana = (turnCount += 1);
        UpdateMana();
    }

    void UpdateMana()
    {
        Text.SetText(mana.ToString());
    }

    public void AddToMana(int manaToAdd)
    {
        mana += manaToAdd;
        UpdateMana();
    }

    public void ConsumeMana(int ManaCost)
    {
        mana -= ManaCost;
        UpdateMana();
    }

}
