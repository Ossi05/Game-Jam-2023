using System.Collections;
using UnityEngine;

public class DimensionController : MonoBehaviour {
    [SerializeField] GameObject whiteObjects;
    [SerializeField] GameObject blackObjects;
    [SerializeField] float dimensionTime = 5f;
    [SerializeField] float cooldownTime = 3f;
    void Awake()
    {
        blackObjects.SetActive(false);
        whiteObjects.SetActive(true);
    }


    public void SetBlackDimension()
    {
        StartCoroutine(BlackDimensionTime());
    }

    IEnumerator BlackDimensionTime()
    {
        blackObjects.SetActive(true);
        whiteObjects.SetActive(false);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSecondsRealtime(dimensionTime);
        whiteObjects.SetActive(true);
        blackObjects.SetActive(false);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSecondsRealtime(cooldownTime);
    }
}
