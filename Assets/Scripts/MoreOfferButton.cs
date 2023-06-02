using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreOfferButton : MonoBehaviour
{
    [SerializeField] GameObject miniShop;
    [SerializeField] GameObject expandShop;

    public void MoreOffer_Button()
    {
        AudioManager.Instance.PlaySoundClickButton();
        this.miniShop.SetActive(false);
        this.expandShop.SetActive(true);
    }
}
