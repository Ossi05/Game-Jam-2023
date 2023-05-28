using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] float exitTime = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }


    IEnumerator LoadNextLevel()
    {   
        yield return new WaitForSecondsRealtime(exitTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        FindObjectOfType<SaveItemState>().ResetScene();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
