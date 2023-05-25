using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 death = new Vector2(20f, 20f);
    [Header("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;


    Vector2 moveInput;
    Rigidbody2D rb;
    Animator playerAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;
    DimensionController dimensionController;
    GameSession gameSession;
    Audio audioManager;
    Buttons buttons;

    void Awake()
    {
        dimensionController = FindObjectOfType<DimensionController>();
        gameSession = FindObjectOfType<GameSession>();
        audioManager = FindObjectOfType<Audio>();
        buttons = FindObjectOfType<Buttons>();
    }
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
            FindAudioManager();
            if (audioManager != null)
            {
                audioManager.PlayJumpSound();
            }
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

    void OnFire(InputValue value)
    {
        if (isAlive)
        {
            FindAudioManager();

            if (audioManager != null)
            {
                audioManager.PlayShootSound();
            }
            
            Instantiate(bullet, bulletSpawn.position, transform.rotation);
        }
    }
    void FlipPlayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }

    }

    public void Death()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Spikes")) )
        {
            isAlive = false;
            FindAudioManager();
            if (audioManager != null)
            {
                audioManager.PlayDeathSound();
            }
            
            playerAnimator.SetTrigger("Death");
            rb.velocity = death;
            StartCoroutine(DelayedPlayerDeath());

        }
    }

    IEnumerator DelayedPlayerDeath()
    {   
        yield return new WaitForSecondsRealtime(1);
        gameSession.PlayerDeath();
        
    }

    void OnDimension()
    {
        if (isAlive)
        {
            dimensionController.ChangeDimension();
        }
    }

    void OnMenu()
    {   
        buttons.HideMenu();
    }

    void FindAudioManager()
    {
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<Audio>();
        }
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
}
