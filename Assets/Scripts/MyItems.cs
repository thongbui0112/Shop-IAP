using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyItems : MonoBehaviour
{
    [SerializeField] int currentCoins;
    [SerializeField] int currentGems;
    [SerializeField] int currentWoods;
    [SerializeField] int currentMeats;
    [SerializeField] float currentMoneys;

    [SerializeField] TMP_Text currentCoinsText;
    [SerializeField] TMP_Text currentGemsText;
    [SerializeField] TMP_Text currentMeatsText;
    [SerializeField] TMP_Text currentWoodsText;
    [SerializeField] TMP_Text currentMoneysText;

    private void Start()
    {
        LoadDataItems();
        ShowCurrentItems();
    }

    public void ShowCurrentItems()
    {
        this.currentCoinsText.text = this.currentCoins.ToString();
        this.currentGemsText.text = this.currentGems.ToString();
        this.currentMeatsText.text = this.currentMeats.ToString();
        this.currentWoodsText.text = this.currentWoods.ToString();
        this.currentMoneys = (float)Math.Round(this.currentMoneys,2);
        this.currentMoneysText.text = this.currentMoneys.ToString();
    }

    public void LoadDataItems()
    {
        if (PlayerPrefs.HasKey("currentcoins"))
        {
            this.currentCoins = PlayerPrefs.GetInt("currentcoins");
        }
        else this.currentCoins = 100;

        if (PlayerPrefs.HasKey("currentgems"))
        {
            this.currentGems = PlayerPrefs.GetInt("currentgems");
        }
        else this.currentGems = 100;
        
        if (PlayerPrefs.HasKey("currentmeats"))
        {
            this.currentMeats = PlayerPrefs.GetInt("currentmeats");
        }
        else this.currentMeats= 100;
        
        if (PlayerPrefs.HasKey("currentwoods"))
        {
            this.currentWoods = PlayerPrefs.GetInt("currentwoods");
        }
        else this.currentWoods = 100;
        
        if (PlayerPrefs.HasKey("currentmoneys"))
        {
            this.currentMoneys = PlayerPrefs.GetFloat("currentmoneys");
        }
        else this.currentMoneys = 100;
    }
    public void SaveDataItems()
    {
        PlayerPrefs.SetInt("currentcoins", this.currentCoins);
        PlayerPrefs.SetInt("currentgems", this.currentGems);
        PlayerPrefs.SetInt("currentmeats", this.currentMeats);
        PlayerPrefs.SetInt("currentwoods", this.currentWoods);
        PlayerPrefs.SetFloat("currentmoneys", this.currentMoneys);
    }

    public void AddCoins(int coins)
    {
        this.currentCoins += coins;
    }
    public void AddGems(int gems)
    {
        this.currentGems += gems;
    }
    public void AddWoods(int woods)
    {
        this.currentWoods += woods;
    }
    public void AddMeats(int meats)
    {
        this.currentMeats += meats;
    }
    public void AddMoneys(float moneys)
    {
        this.currentMoneys += moneys;
    }
    public float GetCurrentMoney()
    {
        return this.currentMoneys;  
    }

}
