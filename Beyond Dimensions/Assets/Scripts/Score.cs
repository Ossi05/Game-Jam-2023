using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;
    
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
