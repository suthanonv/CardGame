using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private PlayerTurn CurrentTurn;

    private void Update()
    {
        CurrentTurn = TurnManage.instance.CurrentPLayerTurn;
        
        text.SetText(CurrentTurn.ToString());
    }
}
