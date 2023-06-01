using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIEffectManage : MonoBehaviour
{
    [SerializeField] Image ReturnButtonCardHolder;

    private void Start()
    {
        ReturnScript.instance.enableCardReturnMode.AddListener(ChangeStatOfReturnButtonCard);
    }

    public void ChangeStatOfReturnButtonCard(bool check)
    {
        if(check == true)
        {
            ReturnButtonCardHolder.color = Color.green;
        }
        else
        {
            ReturnButtonCardHolder.color = Color.red;
        }
    }

}
