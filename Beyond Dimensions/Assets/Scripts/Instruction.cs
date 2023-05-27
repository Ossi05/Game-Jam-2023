using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI changeDimensiontext;
    BoxCollider2D boxCollider;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        changeDimensiontext.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            changeDimensiontext.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            changeDimensiontext.gameObject.SetActive(false);
        }
    }

}
