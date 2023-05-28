using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour {
    [SerializeField] int playerLives = 3;
    Score score;
    UIManager uiManager;


    private void Start()
    {   
        uiManager = GetComponent<UIManager>();
        score = FindObjectOfType<Score>();

        
        uiManager.UpdateLivesText(playerLives);
        

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

        DimensionController dimensionController = FindObjectOfType<DimensionController>();
        if (dimensionController != null)
        {
            dimensionController.ResetDimensionController();
        }
    }

    void TakeLife()
    {
        playerLives--;
        uiManager.UpdateLivesText(playerLives);
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
        uiManager.UpdateLivesText(playerLives);
    }

    public void ResetGame()
    {
        
        
        playerLives = 3;
        uiManager.UpdateLivesText(playerLives);
        

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