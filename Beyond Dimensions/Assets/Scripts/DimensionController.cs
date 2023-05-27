using System.Collections;
using System.Threading;
using UnityEngine;

public class DimensionController : MonoBehaviour {
    [SerializeField] GameObject whiteObjects;
    [SerializeField] GameObject blackObjects;
    [SerializeField] SpriteRenderer bullet;
    [SerializeField] SpriteRenderer player;
    bool blackDimension = false;
    void Awake()
    {
        SaveItemState saveItemState = FindObjectOfType<SaveItemState>();
        bullet.color = Color.white;
        blackObjects.SetActive(false);
        whiteObjects.SetActive(true);
        saveItemState.white();
    }


    public void ChangeDimension()
    {
        SaveItemState saveItemState = FindObjectOfType<SaveItemState>();
        blackDimension = !blackDimension;

        
        if (blackDimension)
        {
            
            bullet.color = Color.black;
            player.color = Color.black;
            saveItemState.black();
            blackObjects.SetActive(true);
            whiteObjects.SetActive(false);
            Camera.main.backgroundColor = Color.white;
        }
        else
        {
            
            whiteObjects.SetActive(true);
            blackObjects.SetActive(false);
            saveItemState.white();
            bullet.color = Color.white;
            player.color = Color.white;
            Camera.main.backgroundColor = Color.black;
        }
    }

    public bool GetDimension()
    {   
        return blackDimension;
    }
}
    

