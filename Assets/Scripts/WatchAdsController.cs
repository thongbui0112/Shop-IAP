using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WatchAdsController : MonoBehaviour
{
    [SerializeField] Item item;

    [SerializeField] MyItems myItems;
    [SerializeField] GameObject watchAds;
    private Button watchAdsButton;


    [SerializeField] VideoPlayer adsVideo;

    [SerializeField] bool videoFinished;
    [SerializeField] bool watchingVideo;
    [SerializeField] float maxTimeVideo;
    [SerializeField] float timerWatchingVideo;
    [SerializeField] bool countDownVideo;
    [SerializeField] float timerCountDownVideo;
    [SerializeField] TMP_Text timerText;
    

    [SerializeField] Image timerBar;
    [SerializeField] GameObject noticePanel;
    private void Awake()
    {
        
        this.myItems = FindObjectOfType<MyItems>();
        this.watchAdsButton = GetComponent<Button>();
    }
    private void Start()
    {
        this.timerCountDownVideo = 60*30;

        this.maxTimeVideo = (float)this.adsVideo.length;
    }
    private void Update()
    {
        if(!this.countDownVideo&& this.watchingVideo && this.timerWatchingVideo <= this.maxTimeVideo)
        {
            this.timerWatchingVideo += Time.deltaTime;
            this.timerBar.fillAmount = Mathf.MoveTowards(this.timerBar.fillAmount, this.timerWatchingVideo / this.maxTimeVideo, Time.deltaTime);
        }
        if(this.timerWatchingVideo> this.maxTimeVideo)
        {
            this.videoFinished = true;
            this.watchingVideo = false;
            this.countDownVideo = true;
        }
        if (this.countDownVideo)
        {
            ShowTimeCountDownVideo();
        }
        else
        {
            this.timerText.text = "WatchAds";
        }
    }
    public void FinishWatchAds()
    {
            this.myItems.AddCoins(this.item.GetCoins());
            this.myItems.AddGems(this.item.GetGems());
            this.myItems.AddWoods(this.item.GetWoods());
            this.myItems.AddMeats(this.item.GetMeats());
            this.myItems.AddMoneys(-this.item.GetPrice());

            this.myItems.SaveDataItems();
            this.myItems.ShowCurrentItems();
    }
    public void WatchAds_Button()
    {
        if (!this.countDownVideo) 
        {
            this.timerWatchingVideo= 0;
            this.timerBar.fillAmount= 0;
            AudioManager.Instance.PlaySoundClickButton();
            this.watchingVideo = true;
            this.watchAds.SetActive(true);
        }
        else
        {
            AudioManager.Instance.PlaySoundBuyFailed();
        }
    }
    public void CancelButton()
    {
        if (this.watchingVideo)
        {
            this.adsVideo.Pause();
            this.noticePanel.SetActive(true);
            this.watchingVideo = false;
        }
        if(this.videoFinished)
        {
            this.FinishWatchAds();
            this.watchAds.SetActive(false) ;
            this.timerWatchingVideo = 0f;
            AudioManager.Instance.PlaySoundBuySucces();
        }
    }
    public void ShowTimeCountDownVideo()
    {
        this.timerCountDownVideo -= Time.deltaTime;
        int m = (int)this.timerCountDownVideo / 60;
        int s = (int)this.timerCountDownVideo % 60;
        this.timerText.text = m.ToString() + ":" + s.ToString();
        if (this.timerCountDownVideo <=0)
        {
            this.countDownVideo = false;
        }
    }
    public void OkButton()
    {
        AudioManager.Instance.PlaySoundClickButton();
        this.watchingVideo = true;
        this.noticePanel.SetActive(false);
        this.adsVideo.Play();
    }
    public void ExitButton()
    {
        AudioManager.Instance.PlaySoundClickButton();
        this.adsVideo.Stop();
        this.watchAds.SetActive(false);
        this.noticePanel.SetActive(false);
    }
}
