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
        if (collision.tag == "Player" && !wasCollected)
        {            
            wasCollected = true;
            audioManager.PlayCoinSound();
            score.AddToScore(pointsToAdd);
            Destroy(gameObject);
        }
            
    }

}
