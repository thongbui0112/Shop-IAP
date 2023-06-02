using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FewerOfferButton : MonoBehaviour
{
    [SerializeField] GameObject miniShop;
    [SerializeField] GameObject expandShop;

    public void FewerOffer_Button()
    {
        AudioManager.Instance.PlaySoundClickButton();
        this.miniShop.SetActive(true);
        this.expandShop.SetActive(false);
    }
}
