using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    void Awake()
    {
        livesText.text = "Lives: " + playerLives.ToString();
        int gameSessions = FindObjectsOfType<GameSession>().Length;
        if (gameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    

    public void PlayerDeath()
    {   
        
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {  
        playerLives--;
        livesText.text = "Lives: " + playerLives.ToString();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void ResetGameSession()
    {
        FindObjectOfType<SaveItemState>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void AddHealth(int health)
    {
        playerLives += health;
        livesText.text = "Lives: " + playerLives.ToString();
    }

}
