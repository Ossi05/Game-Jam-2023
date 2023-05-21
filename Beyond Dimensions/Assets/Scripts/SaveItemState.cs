using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItemState : MonoBehaviour
{
    [SerializeField] GameObject whiteItems;
    [SerializeField] GameObject blackItems;
    void Awake()
    {

        int ItemStates = FindObjectsOfType<SaveItemState>().Length;
  
        if (ItemStates > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }

    public void black()
    {
        blackItems.SetActive(true);
        whiteItems.SetActive(false);
    }

    public void white()
    {
        whiteItems.SetActive(true);
        blackItems.SetActive(false);
    }
}
