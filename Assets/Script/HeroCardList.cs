using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class HeroCardList : MonoBehaviour
{
    public static event HandleP1DeckCreation OnConfirmSelectionP1;
    public delegate void HandleP1DeckCreation(HeroCard heroCard);

    public static event HandleP2DeckCreation OnConfirmSelectionP2;
    public delegate void HandleP2DeckCreation(HeroCard heroCard);

    public static event HandleDiselectedCardWhenConfirm OnConfirm;
    public delegate void HandleDiselectedCardWhenConfirm();

    [SerializeField] public List<HeroCard> HeroCards = new List<HeroCard>();
    [SerializeField] public int MaximumCardSelected = 4;

    public static bool isCardSelectedMax = false;

    public static bool player1Selection = true;

    private void OnEnable()
    {
        SetHeroInfo.OnCardSelected += AddSelectedCard;
        SetHeroInfo.OnCardDiselected += RemoveSelectedCard;
    }

    private void OnDisable()
    {
        SetHeroInfo.OnCardSelected -= AddSelectedCard;
        SetHeroInfo.OnCardDiselected -= RemoveSelectedCard;
    }

    private void Update()
    {
        if(MaximumCardSelected == HeroCards.Count)
        {
            isCardSelectedMax = true;
        }
        else
        {
            isCardSelectedMax = false;
        }
    }

    void AddSelectedCard(HeroCard heroCard)
    {
        HeroCards.Add(heroCard);
    }

    void RemoveSelectedCard(HeroCard heroCard)
    {
        HeroCards.Remove(heroCard);
    }

    public void ConfirmSelection()
    {
        if (player1Selection == true)
        {
            for (int i = 0; i < MaximumCardSelected; i++)
            {
                OnConfirmSelectionP1?.Invoke(HeroCards[i]);
                OnConfirm?.Invoke();
                player1Selection = false;
            }
            HeroCards.Clear();
        }
        else
        {
            for (int i = 0; i < MaximumCardSelected; i++)
            {
                OnConfirmSelectionP2?.Invoke(HeroCards[i]);
                OnConfirm?.Invoke();
            }
            HeroCards.Clear();
            GameObject.Find("CardSelectMenu").SetActive(false);
        }
    }
}
