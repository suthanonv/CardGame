using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class HeroCardOnCard : MonoBehaviour
{
    public static event HandleRespawn OnRespawn;
    public delegate void HandleRespawn(HeroCard heroCard, string player);

    public static event HandleOnGameStart OnStart;
    public delegate void HandleOnGameStart();
    
   [SerializeField]public HeroCard HeroCard;
    CardSkill SkillOfCard;
    Button CardSkillButton;
    [SerializeField] public GameObject TeamMateCard;
    [SerializeField] public GameObject ThisCard;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Deck;

    private PlayerDeck playerDeck;

    public CardType typeOfCard;

    public void OnEnable()
    {
        CardHealth.OnDeath += Death;
        
    }

    public void OnDisable()
    {
        CardHealth.OnDeath -= Death;
    }

    private void Start()
    {
        playerDeck = Deck.GetComponent<PlayerDeck>();
        ThisCard = this.gameObject;
        CardSkillButton = this.GetComponent<Button>();
    }

    public void SetHeroCard(HeroCard newCard)
    {
        HeroCard = newCard;
        Debug.Log("Start To Set" + HeroCard.Name);
        OnRespawn?.Invoke(HeroCard, Player.name);
        SkillOfCard = Instantiate(newCard.Skill, this.transform);
        SkillOfCard.SetHeroCardOnCard(this);
        SkillOfCard.SetButton( CardSkillButton);
        this.GetComponent<CardHealth>().SetHealth(HeroCard.Force);
        typeOfCard = HeroCard.CardType;
        Invoke("startSet", 0.1f);
    }
    [SerializeField]ShowSkill skillToShow;
    void startSet()
    {
        skillToShow = this.GetComponent<ShowSkill>();
        skillToShow.GetSkill();
        this.GetComponent<CardHealth>().OnGameStart();
    }

    void Death()
    {
        HeroCard = null;
    }

  public  void Respawn()
    {
       
        if (Player.name == "Player1" && playerDeck.Player1_Deck.Count > 0)
        {
            enableACard();
            HeroCard = playerDeck.Player1_Deck[Random.Range(0, playerDeck.Player1_Deck.Count)];
            playerDeck.Player1_Deck.Remove(HeroCard);
            Debug.Log("Player1Deck Count" + playerDeck.Player1_Deck.Count.ToString());
            SetHeroCard(HeroCard);
        }
        else if (Player.name == "Player2" && playerDeck.Player2_Deck.Count > 0)
        {
            enableACard();
            HeroCard = playerDeck.Player2_Deck[Random.Range(0, playerDeck.Player2_Deck.Count)];
            playerDeck.Player2_Deck.Remove(HeroCard);
            Debug.Log("PLayer2Deck count" + playerDeck.Player2_Deck.Count.ToString());
            SetHeroCard(HeroCard);
        }
        else
        {
            Debug.Log("No Card To Spawn");
        }
        Debug.Log("is herocard null: " + HeroCard == null);
       
    }


    void enableACard()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        this.gameObject.GetComponent<HeroCardOnCard>().enabled = true;
        this.gameObject.GetComponent<CardHealth>().enabled = true;
    }
 
    public CardType GetCardType()
    {
        return typeOfCard;
    }

    public CardSkill GetSkillCard()
    {
        return SkillOfCard;
    }
}
