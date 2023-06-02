using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject shop,miniShop,expandShop;
    [SerializeField] Animator shopAnimator,shopButtonAnimator;

    private void Start()
    {
        // Kích hoạt chế độ tự động xoay màn hình
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        // Chuyển đổi chế độ xoay màn hình thành chế độ hiện tại
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void ShopButton()
    {
        AudioManager.Instance.PlaySoundClickButton();
        this.shop.SetActive(true);
        this.shopButton.SetActive(false);
        this.miniShop.SetActive(true);
        this.expandShop.SetActive(false);
    }
    public void HideShop()
    {
        this.shop.SetActive(false);
        this.shopButton.SetActive(true);
    }

    public void CancelShopButton()
    {
        AudioManager.Instance.PlaySoundClickButton();
        Debug.Log("cancelButton");
        this.shopAnimator.SetTrigger("ShopDisappear");
        Invoke("HideShop", 0.3f);
    }
    
}
