using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Sources----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip----------")]
    public AudioClip backgroundMusic;
    public AudioClip cardClick;
    public AudioClip mrPo;
    public AudioClip checker;
    public AudioClip cardSend;
    private bool hasPlayedTicket = false;
    private bool hasPlayedMainCard = false;
    private bool hasPlayedLpd = false;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }

        GameObject foundObject1 = GameObject.FindWithTag("Ticket");
        if (foundObject1 != null && !hasPlayedTicket)
        {
            SFXSource.PlayOneShot(cardSend);
            hasPlayedTicket = true;
        }

        if (foundObject1 == null)
        {
            hasPlayedTicket = false;
        }
        
        GameObject foundObject2 = GameObject.FindWithTag("MainCard");
        if (foundObject2 != null && !hasPlayedMainCard)
        {
            SFXSource.PlayOneShot(cardClick);
            hasPlayedMainCard = true;
        }

        if (foundObject2 == null)
        {
            hasPlayedMainCard = false;
        }
        
        GameObject foundObject3 = GameObject.FindWithTag("Lpd");
        if (foundObject3 != null && !hasPlayedLpd)
        {
            SFXSource.PlayOneShot(mrPo);
            hasPlayedLpd = true;
        }

        if (foundObject3 == null)
        {
            hasPlayedLpd = false;
        }
    }
}