using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {
    [SerializeField] float flySpeed = 1f;
    [SerializeField] float flyAmount = 1f;
    [SerializeField] float flyOffset = 0f;

    Rigidbody2D rb;
    private float startY;
    private float currentOffset;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y + flyAmount;
    }

    void Update()
    {
        currentOffset += Time.deltaTime * flySpeed;

        float newY = startY + Mathf.Sin(currentOffset + flyOffset) * flyAmount;

        Vector2 newPosition = new Vector2(transform.position.x, newY);
        rb.MovePosition(newPosition);
    }
}
