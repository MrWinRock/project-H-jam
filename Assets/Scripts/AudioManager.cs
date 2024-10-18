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
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
