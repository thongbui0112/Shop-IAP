using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceButton : MonoBehaviour
{
    Item item;
    [SerializeField] MyItems myItems;


    private Button priceButton;
    
    private void Awake()
    {
        this.item= GetComponent<Item>();
        this.myItems = FindObjectOfType<MyItems>();
        this.priceButton = GetComponent<Button>();
    }
    private void Start()
    {
        this.priceButton.onClick.AddListener(Price_Button);
    }

    public void Price_Button()
    {
        if (this.myItems.GetCurrentMoney() >= item.GetPrice())
        {
            AudioManager.Instance.PlaySoundBuySucces();
            this.myItems.AddCoins(this.item.GetCoins());
            this.myItems.AddGems(this.item.GetGems());
            this.myItems.AddWoods(this.item.GetWoods());
            this.myItems.AddMeats(this.item.GetMeats());
            this.myItems.AddMoneys(-this.item.GetPrice());
            this.myItems.SaveDataItems();
            this.myItems.ShowCurrentItems();
        }
        else
        {
            AudioManager.Instance.PlaySoundBuyFailed();
        }
    }

}
