using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour {
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();

        if (livesText != null)
        {
            livesText.text = "Lives: " + playerLives.ToString();
        }

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
        FindObjectOfType<SaveItemState>().ResetScene();
        int lastScene = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(lastScene);
        Destroy(gameObject);
    }

    public void AddHealth(int health)
    {
        playerLives += health;
        livesText.text = "Lives: " + playerLives.ToString();
    }

    public void ResetGame()
    {
        if (livesText != null)
        {
            playerLives = 3;
            livesText.text = "Lives: " + playerLives.ToString();
        }

        if (score != null)
        {
            score.ResetScore();
        }

        SaveItemState saveItemState = FindObjectOfType<SaveItemState>();

        if (saveItemState != null)
        {
            saveItemState.ResetScene();
        }

        Destroy(gameObject);
    }
}