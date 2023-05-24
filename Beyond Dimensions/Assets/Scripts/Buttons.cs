using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    GameSession gameSession;

    void Awake()
    {   
        gameSession = FindObjectOfType<GameSession>();
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {   
        if (gameSession == null)
        {
            gameSession = FindObjectOfType<GameSession>();
        }
        gameSession.ResetGame();
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {   
        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
        
        SceneManager.LoadScene(0);
    }

    public void HideMenu()
    {   
        if (pauseMenu != null) 
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        
    }


}
