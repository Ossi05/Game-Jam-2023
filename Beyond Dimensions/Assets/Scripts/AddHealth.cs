using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AddHealth : MonoBehaviour
{
    [SerializeField] int healthToAdd = 1;
    GameSession gameSession;
    Audio audioManager;
    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        audioManager = FindObjectOfType<Audio>();
    }
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {   
            if (audioManager == null)
            {
                audioManager = FindObjectOfType<Audio>();
            }
            audioManager.PlayCoinSound();
            wasCollected = true;
            if (gameSession == null)
            {
                gameSession = FindObjectOfType<GameSession>();
            }
            gameSession.AddHealth(healthToAdd);
            Destroy(gameObject);
        }
        
    }

}
