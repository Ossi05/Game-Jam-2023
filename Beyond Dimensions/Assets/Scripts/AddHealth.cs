using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AddHealth : MonoBehaviour
{
    [SerializeField] int healthToAdd = 1;
    GameSession gameSession;
    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            gameSession.AddHealth(healthToAdd);
            Destroy(gameObject);
        }
        
    }
}
