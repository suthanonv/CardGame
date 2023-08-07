using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn
{
    Player1,Player2
}


public class TurnManage : MonoBehaviour
{
    public static int turnCount = 1;

    public static TurnManage instance;

    public PlayerTurn CurrentPLayerTurn = PlayerTurn.Player1;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        TurnOffAllCard();
        LoadNewTurn();
    }


    void TurnOffAllCard()
    {
        foreach (GameObject i in StarterPointPosition.instance.CardDraged)
        {
            i.GetComponent<CardNum>().FaceUpCardTrue(false);
        }
    }



    void LoadNewTurn()
    {
        int CurrentCount = 0;
        int CardToOpen = turnCount + 1;
        foreach (GameObject i in StarterPointPosition.instance.CardDraged)
        {
            if (CurrentCount < CardToOpen)
            {
                while(i.GetComponent<CardNum>().ReturnNum.Count > 0)
                {
                    i.GetComponent<CardNum>().Return();
                }
                i.GetComponent<CardNum>().FaceUpCardTrue(true);

                CurrentCount++;
                GameObject.Find("ManaPool").GetComponent<ManaSystem>().LoadMana(turnCount);
            }
        }
    }

    public void SkipTurn()
    {
        turnCount++;
        if (turnCount < 10)
        {
            LoadNewTurn();
        }
        ChangePlayerTurn();
        CheckEndGame();
    }

    void CheckEndGame()
    {
        if(!StarterPointPosition.instance.PlayerOneCard[0].GetComponent<CardHealth>().isActiveAndEnabled && !StarterPointPosition.instance.PlayerOneCard[1].GetComponent<CardHealth>().isActiveAndEnabled)
        {
            Debug.Log("PlayerTwo Win");
        }
        else if(!StarterPointPosition.instance.PlayerTwoCard[0].GetComponent<CardHealth>().isActiveAndEnabled && !StarterPointPosition.instance.PlayerTwoCard[1].GetComponent<CardHealth>().isActiveAndEnabled)
        {
            Debug.Log("PlayerOne Win");
        }
    }


    public void ChangePlayerTurn()
    {
        GameObject.Find("ManaPool").GetComponent<ManaSystem>().LoadMana(turnCount);
        if (turnCount >= 10)
        {
            foreach (GameObject i in StarterPointPosition.instance.CardDraged)
            {
                while(i.GetComponent<CardNum>().ReturnNum.Count > 0)
                {
                    i.GetComponent<CardNum>().Return();
                }
                i.GetComponent<CardNum>().FaceUpCardTrue(true);   
            }   
        }
        if(CurrentPLayerTurn == PlayerTurn.Player1)
        {
            CurrentPLayerTurn = PlayerTurn.Player2;
        }
        else
        {
            CurrentPLayerTurn = PlayerTurn.Player1;
        }
    }
}
