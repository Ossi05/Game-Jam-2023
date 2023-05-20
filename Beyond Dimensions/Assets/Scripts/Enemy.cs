using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    { 
        rb.velocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D collision)
    {   
        moveSpeed = -moveSpeed;
        FlipEnemy();

    }

    void FlipEnemy()
    {   
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

}
