using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardHealth : MonoBehaviour
{

    public static event HandleDead OnDeath; 
    public delegate void HandleDead();

    public float Health;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Force;
    public TextMeshProUGUI Skill;
    private HeroCard heroCard;
    private UnityEngine.UI.Image image;

    private void Start()
    {
        image = this.GetComponent<UnityEngine.UI.Image>();
    }

    public void OnEnable()
    {
        HeroCardOnCard.OnStart += OnGameStart;
       
    }

    private void OnDisable()
    {
        HeroCardOnCard.OnStart -= OnGameStart;
    }

    public void OnGameStart()
    {
        heroCard = this.gameObject.GetComponent<HeroCardOnCard>().HeroCard;
        Debug.Log("Is Hero Card Null?: " + (heroCard == null).ToString());
        // Debug.Log(heroCard.Name);
        Name.SetText(heroCard.Name);
        Force.SetText(heroCard.Force.ToString());
        Skill.SetText(heroCard.SkillCost.ToString());
        image.sprite = heroCard.HeroArt;
    }

    public void SetHealth(float newHealth)
    {
        Health = newHealth;
        Force.SetText(newHealth.ToString());
    }

    public void AddToHealth(float healthToAdd)
    {
        Health += healthToAdd;
        Force.SetText(Health.ToString());
    }

    public void MultiplyToHealth(float healthToMultiply)
    {
        float NewHealth = Health * healthToMultiply;
        Health = NewHealth;
        Force.SetText(Health.ToString());
    }

    public void SubtractFromHealth(float healtToSubtract)
    {
        Health -= healtToSubtract;
        Force.SetText(Health.ToString());
    }

    public void GetAttacked(float NumToAtk)
    {
        if (Health == NumToAtk)
        {
            Debug.Log("dead");
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.GetComponent<HeroCardOnCard>().enabled = false;
            this.gameObject.GetComponent<CardHealth>().enabled = false;
            Name.SetText(" ");
            Skill.SetText(" ");
            Force.SetText(" ");
            image.sprite = null;
            OnDeath?.Invoke();
            this.GetComponent<HeroCardOnCard>().Respawn();
        }
        else
        {
            Debug.Log("attack failed");
        }
    }





}
