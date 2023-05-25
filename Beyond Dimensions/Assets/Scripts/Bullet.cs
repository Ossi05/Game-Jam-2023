using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float timeAlive = 5f;
    Rigidbody2D rb;
    Player player;
    float speed;
    Effects effects;
    Audio audioManager;

    private void Awake()
    {
        effects = FindObjectOfType<Effects>();
        audioManager = FindObjectOfType<Audio>();
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
        Destroy(gameObject, timeAlive);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {   
            audioManager.PlayKillSound();
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
