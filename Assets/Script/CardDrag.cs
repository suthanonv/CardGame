using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardDrag : MonoBehaviour , IBeginDragHandler, IEndDragHandler,IDragHandler
{
   [SerializeField] Transform StartPoint;

    GameObject MergedCard;

    Button buttonScript;

    public static event HandleNumberCalculation OnMerge;

    public delegate void HandleNumberCalculation(GameObject Card1, GameObject Card2);

    void Start()
    {
        buttonScript = this.GetComponent<Button>();
        ReturnScript.instance.enableCardReturnMode.AddListener(EnableCardReturnButton);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Transform check = StarterPointPosition.instance.GetTransform(this.transform);
        if(check == null)
        {
            this.transform.position = StartPoint.transform.position;

        }
        else if(!StarterPointPosition.instance.CheckIsPositionEqualToPlayerAttackPoint(check))
        {
            OnMerge?.Invoke(this.GameObject(), 
                StarterPointPosition.instance.CardDraged[StarterPointPosition.instance.GetArrayNum(check)]);
            this.transform.position = StartPoint.transform.position;

        }
        else
        {
            StarterPointPosition.instance.GetPlayerCardOBject(check).GetComponent<CardHealth>().GetAttacked(this.GetComponent<CardNum>().Number);
            TurnManage.instance.SkipTurn();
        }

        this.transform.position = StartPoint.transform.position;
    }

    public void DisableCard()
    {
        this.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void EnableCard()
    {
        this.GetComponent<Image>().enabled = true;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
    }


    public void EnableCardReturnButton(bool check)
    {
        if (this.GetComponent<CardNum>().ReturnNum.Count > 0)
        {
            buttonScript.enabled = check;
        }
        else
        {
            buttonScript.enabled = false;
        }
    }

    }
    

