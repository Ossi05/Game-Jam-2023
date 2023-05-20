using System.Collections;
using UnityEngine;

public class DimensionController : MonoBehaviour {
    [SerializeField] GameObject whiteObjects;
    [SerializeField] GameObject blackObjects;
    [SerializeField] Animator playerAnimator;
    bool blackDimension = false;
    void Awake()
    {
        blackObjects.SetActive(false);
        whiteObjects.SetActive(true);
    }


    public void ChangeDimension()
    {
        blackDimension = !blackDimension;
        if (blackDimension)
        {
            playerAnimator.SetLayerWeight(1, 1f);
            playerAnimator.SetLayerWeight(0, 0f);

            blackObjects.SetActive(true);
            whiteObjects.SetActive(false);
            Camera.main.backgroundColor = Color.white;
        }
        else
        {
            playerAnimator.SetLayerWeight(1, 0f);
            playerAnimator.SetLayerWeight(0, 1f);
            whiteObjects.SetActive(true);
            blackObjects.SetActive(false);
            Camera.main.backgroundColor = Color.black;
        }
    }

}
    

