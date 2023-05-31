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

    public static event HandleNumberCalculation OnMerge;

    public delegate void HandleNumberCalculation(GameObject Card1, GameObject Card2);

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
        else
        {
            OnMerge?.Invoke(this.GameObject(), 
                StarterPointPosition.instance.CardDraged[StarterPointPosition.instance.GetArrayNum(check)]);
            this.transform.position = StartPoint.transform.position;

        }
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
    
}
