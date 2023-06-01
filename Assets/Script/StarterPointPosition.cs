using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPointPosition : MonoBehaviour
{
    public static StarterPointPosition instance;


    [SerializeField] List<Transform> CardPointPosition;

    [SerializeField] float FixRaduis;

    [SerializeField] public List<GameObject> CardDraged = new List<GameObject>();

    [Header("Player Card")]
    [SerializeField] public List<Transform> PlayerOneCardPosition = new List<Transform>();
    [SerializeField] public List<Transform> PlayerTwoCardPosition = new List<Transform>();
    [SerializeField] public List<GameObject> PlayerOneCard = new List<GameObject>();
    [SerializeField] public List<GameObject> PlayerTwoCard = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

  


    public Transform GetTransform(Transform point)
    {
        Transform currentTransform = null;
        float lowestRaduis = 10000;

        Transform checkPlayerAttakc = isPlayerAttakc(point);

        if(checkPlayerAttakc != null)
        {
            return checkPlayerAttakc;
        }

        foreach (Transform i in CardPointPosition)
        {
           if(Vector2.Distance(i.transform.position,point.transform.position) < lowestRaduis && Vector2.Distance(i.transform.position, point.transform.position) != 0)
            {
                lowestRaduis = Vector2.Distance(i.transform.position, point.transform.position);
                currentTransform = i;
            }
        }

        if(lowestRaduis <= FixRaduis  && lowestRaduis != 0)
        {
            return currentTransform;
        }
        return null;
    }

    public int GetArrayNum(Transform card)
    {
        int count = 0;
        foreach (Transform i in CardPointPosition)
        {
            if (i.transform.position == card.position)
            {
                return count;
            }
            count++;
        }

        return 100;
    }


    public Transform isPlayerAttakc(Transform checkPosition)
    {
        Transform currentTransform = null;
        float lowestRaduis = 10000;
        if (TurnManage.instance.CurrentPLayerTurn == PlayerTurn.Player1)
        {
            foreach (Transform i in PlayerTwoCardPosition)
            {
                if (Vector2.Distance(i.transform.position, checkPosition.transform.position) < lowestRaduis)
                {
                    currentTransform = i;
                    lowestRaduis = Vector2.Distance(i.transform.position, checkPosition.transform.position);
                }
            }
            if (lowestRaduis <= FixRaduis)
            {
                return currentTransform;
            }
        }
        else
        {
            foreach(Transform i in PlayerOneCardPosition)
            {
                if (Vector2.Distance(i.transform.position, checkPosition.transform.position) < lowestRaduis)
                {
                    currentTransform = i;
                    lowestRaduis = Vector2.Distance(i.transform.position, checkPosition.transform.position);
                }
            }
            if (lowestRaduis <= FixRaduis)
            {
                return currentTransform;
            }
        }
        return null;
    }

    public bool CheckIsPositionEqualToPlayerAttackPoint(Transform point)
    {
        if(TurnManage.instance.CurrentPLayerTurn == PlayerTurn.Player1)
        {
            foreach(Transform i in PlayerTwoCardPosition)
            {
                if(i.position == point.position)
                {
                    return true;
                }
            }
        }
        else
        {
            foreach (Transform i in PlayerOneCardPosition)
            {
                if (i.position == point.position)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public GameObject GetPlayerCardOBject(Transform point)
    {
        int count = 0;
        if (TurnManage.instance.CurrentPLayerTurn == PlayerTurn.Player1)
        {
            foreach (Transform i in PlayerTwoCardPosition)
            {
                if (i.position == point.position)
                {
                    return PlayerTwoCard[count];
                }
                count++;
            }
        }
        else
        {
            foreach (Transform i in PlayerOneCardPosition)
            {
                if (i.position == point.position)
                {
                    return PlayerOneCard[count];
                }
                count++;
            }
        }
        return null;
    }
  

}
