using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int gems;
    [SerializeField] int woods;
    [SerializeField] int meats;

    [SerializeField] float price;


    public int GetCoins()
    {
        return this.coins;
    }
    public int GetGems()
    {
        return this.gems;
    }
    public int GetWoods()
    {
        return this.woods;
    }
    public int GetMeats()
    {
        return this.meats;
    }
    public float GetPrice()
    {
        return this.price;
    }
}
