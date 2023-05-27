using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToScore : MonoBehaviour
{
    [SerializeField] int pointsToAdd = 50;
    Score score;
    Audio audioManager;
    void Awake()
    {
        score = FindObjectOfType<Score>();
        audioManager = FindObjectOfType<Audio>();
    }

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && !wasCollected && gameObject.tag == "Enemy")
        {
            wasCollected = true;
            if (score == null)
            {
                score = FindObjectOfType<Score>();
            }
            score.AddToScore(pointsToAdd);            
            Destroy(gameObject);
        }

        if (collision.tag == "Player" && !wasCollected && gameObject.tag == "Coin")
        {
            wasCollected = true;
            if (audioManager == null)
            {
                audioManager = FindObjectOfType<Audio>();
            }
            audioManager.PlayCoinSound();
            if (score == null)
            {
                score = FindObjectOfType<Score>();
            }
            score.AddToScore(pointsToAdd);
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score.AddToScore(pointsToAdd);
    }

}
