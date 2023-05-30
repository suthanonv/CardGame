using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardDrag : MonoBehaviour , IBeginDragHandler, IEndDragHandler,IDragHandler
{
   [SerializeField] Transform StartPoint;

    GameObject MergedCard;

    public static event HandleNumberCalculation OnMerge;

    public delegate void HandleNumberCalculation(int Num1, int Num2);

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
            MergedCard = check.gameObject;
            this.transform.position = StartPoint.transform.position;
           
        }
    }





}
