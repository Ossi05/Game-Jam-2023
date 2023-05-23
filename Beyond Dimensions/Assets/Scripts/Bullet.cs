using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D rb;
    Player player;
    float speed;
    Effects effects;

    private void Awake()
    {
        effects = FindObjectOfType<Effects>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        speed = player.transform.localScale.x * bulletSpeed;
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {   
            effects.PlayExplosion(collision.transform);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
