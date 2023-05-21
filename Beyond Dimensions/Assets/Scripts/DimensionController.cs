using System.Collections;
using UnityEngine;

public class DimensionController : MonoBehaviour {
    [SerializeField] GameObject whiteObjects;
    [SerializeField] GameObject blackObjects;
    [SerializeField] SpriteRenderer bullet;
    [SerializeField] SpriteRenderer player;
    bool blackDimension = false;
    void Awake()
    {
        bullet.color = Color.white;
        blackObjects.SetActive(false);
        whiteObjects.SetActive(true);
    }


    public void ChangeDimension()
    {
        blackDimension = !blackDimension;
        if (blackDimension)
        {
            
            bullet.color = Color.black;
            player.color = Color.black;
            blackObjects.SetActive(true);
            whiteObjects.SetActive(false);
            Camera.main.backgroundColor = Color.white;
        }
        else
        {
            
            whiteObjects.SetActive(true);
            blackObjects.SetActive(false);
            bullet.color = Color.white;
            player.color = Color.white;
            Camera.main.backgroundColor = Color.black;
        }
    }

}
    

