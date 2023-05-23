using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] ParticleSystem whiteExplosion;
    [SerializeField] ParticleSystem blackExplosion;

    public void PlayExplosion(Transform objectPosition)
    {
        DimensionController dimensionController = FindObjectOfType<DimensionController>();
        bool blackDimension = dimensionController.GetDimension();

        if (blackDimension)
        {
            Instantiate(blackExplosion, objectPosition.position, Quaternion.identity);
        }
        else
        {
            Instantiate(whiteExplosion, objectPosition.position, Quaternion.identity);
        }
    }
}
