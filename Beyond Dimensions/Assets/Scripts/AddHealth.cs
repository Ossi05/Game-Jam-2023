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
            audioManager.PlayCoinSound();
            wasCollected = true;
            gameSession.AddHealth(healthToAdd);
            Destroy(gameObject);
        }
        
    }
}
