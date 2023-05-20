using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 death = new Vector2(20f, 20f);


    Vector2 moveInput;
    Rigidbody2D rb;
    Animator playerAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
        feetCollider = GetComponent<BoxCollider2D>();


    }


    void Update()
    {   
        if (isAlive)
        {
            Death();
            Run();
            FlipPlayer();
        }
   
    }

    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            moveInput = value.Get<Vector2>();
        } 
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipPlayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }

    }

    void Death()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;

            playerAnimator.SetTrigger("Death");
            rb.velocity = death;
            
        }
    }

}
