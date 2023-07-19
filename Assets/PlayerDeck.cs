using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    [SerializeField] public List<HeroCard> Player1_Deck = new List<HeroCard>();

    [SerializeField] public List<HeroCard> Player2_Deck = new List<HeroCard>();

    private void OnEnable()
    {
        HeroCardList.OnConfirmSelectionP1 += AddToP1Deck;
        HeroCardList.OnConfirmSelectionP2 += AddToP2Deck;
    }

    private void OnDisable()
    {
        HeroCardList.OnConfirmSelectionP1 -= AddToP1Deck;
        HeroCardList.OnConfirmSelectionP2 -= AddToP2Deck;
    }

    void AddToP1Deck(HeroCard heroCard)
    {
        Player1_Deck.Add(heroCard);
    }

    void AddToP2Deck(HeroCard heroCard)
    {
        Player2_Deck.Add(heroCard);
    }
}
