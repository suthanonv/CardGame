using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPointPosition : MonoBehaviour
{
    public static StarterPointPosition instance;


    [SerializeField] List<Transform> CardPointPosition;

    [SerializeField] float FixRaduis;

    [SerializeField] public List<GameObject> CardDraged = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }


    public Transform GetTransform(Transform point)
    {
        Transform currentTransform = null;
        float lowestRaduis = 10000;
        foreach(Transform i in CardPointPosition)
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
                Debug.Log(count.ToString());
                return count;
            }
            count++;
        }

        return 100;
    }


}
