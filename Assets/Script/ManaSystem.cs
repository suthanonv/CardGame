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
        mana = turnCount;
        UpdateMana();
    }

    void UpdateMana()
    {
        Text.SetText(mana.ToString());
    }

}
