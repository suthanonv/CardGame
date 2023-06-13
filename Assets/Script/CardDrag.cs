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
        
        if(check == null && StarterPointPosition.instance.GetMeCard(this.transform) == null)
        {
            Debug.Log(StarterPointPosition.instance.GetMeCard(this.transform));
            this.transform.position = StartPoint.transform.position;

            Debug.Log("No Case");
        }
        else if(StarterPointPosition.instance.GetMeCard(this.transform) != null)
        {
            HeroCardOnCard HeroCard = StarterPointPosition.instance.GetMeCard(this.transform).GetComponent<HeroCardOnCard>();

            Debug.Log("Active Skill");
            if (HeroCard.GetCardType() == CardType.NeedNumberToActiveSkill)
            {
                ReturnScript.instance.SaveOrginNum(this.gameObject, this.gameObject);
                this.GetComponent<CardNum>().ChangeNumber(HeroCard.GetSkillCard().ActiveCardSkillByNumber(this.GetComponent<CardNum>().Number));
            }
        }
        else if(!StarterPointPosition.instance.CheckIsPositionEqualToPlayerAttackPoint(check))
        {
            Debug.Log("Merge");
            OnMerge?.Invoke(this.GameObject(), 
                StarterPointPosition.instance.CardDraged[StarterPointPosition.instance.GetArrayNum(check)]);
            this.transform.position = StartPoint.transform.position;

        }
        else
        {
            Debug.Log("Attack");
            StarterPointPosition.instance.GetPlayerCardOBject(check).GetComponent<CardHealth>().GetAttacked(this.GetComponent<CardNum>().Number);
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
    

