using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip killSound;
    [SerializeField] AudioClip coinPickUp;
    [SerializeField] float killAudioVolume = 0.5f;
    [SerializeField] float JumpAudioVolume = 0.2f;
    [SerializeField] float volume = 1f;

    AudioSource audioSource;
    static Audio instance;

    void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }


    public void PlayShootSound()
    {   
        PlayAudio(shootSound, volume);
    }

    public void PlayJumpSound()
    {
        PlayAudio(jumpSound, JumpAudioVolume);
    }

    public void PlayDeathSound()
    {
        PlayAudio(deathSound, volume);
    }

    public void PlayKillSound()
    {
        PlayAudio(killSound, killAudioVolume);
    }

    public void PlayCoinSound()
    {
        PlayAudio(coinPickUp, volume);
    }

    void PlayAudio(AudioClip audioClip, float volume)
    {   
        if (audioClip != null)
        {   if(audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
            audioSource.PlayOneShot(audioClip);
        }
        
    }
}
