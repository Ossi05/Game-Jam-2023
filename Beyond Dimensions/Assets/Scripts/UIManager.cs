using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    float timer = 0f;
    bool isFinished = false;

    private void Start()
    {
        timerText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
    private void Update()
    {
        IsGameFinishded();
        if (!isFinished)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }

    }

    void UpdateTimerText()
    {

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timerText != null)
        {
            timerText.text = timerString;
        }
    }


    void IsGameFinishded()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0 || currentSceneIndex == sceneCount)
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            if (canvas != null)
            {
                canvas.SetActive(false);
            }
        }


        else if (currentSceneIndex == sceneCount - 2)
        {

            isFinished = true;

            TextMeshProUGUI winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<TextMeshProUGUI>();
            winText.text = "You Won!\nThanks for playing!\nYour time was: " + timerText.text;
           
            if (GameObject.FindGameObjectWithTag("Timer") != null)
            {
                GameObject.FindGameObjectWithTag("Timer").SetActive(false);
            }

        }


    }




    public void UpdateLivesText(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }





}
