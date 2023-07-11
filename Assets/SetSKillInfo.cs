using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetSKillInfo : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI Skill_Info;

    public void SetInfo(string Info)
    {
        Skill_Info.SetText(Info);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

}
