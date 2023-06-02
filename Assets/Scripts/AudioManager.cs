using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip soundClickButton,soundBuySucces,soundBuyFailed;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    public void PlaySoundClickButton()
    {
        audioSource.PlayOneShot(soundClickButton,1f);
    }
    public void PlaySoundBuySucces()
    {
        audioSource.PlayOneShot(soundBuySucces);
    }
    public void PlaySoundBuyFailed()
    {
        audioSource.PlayOneShot(soundBuyFailed);
    }

}
