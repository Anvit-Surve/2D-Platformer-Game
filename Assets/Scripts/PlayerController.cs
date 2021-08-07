using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float movementSpeed;
    public float jump;
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Health health;
    public float recoilForce;

    private int extraJumps;
    public int extraJumpValue;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Vector2 lookDir;
    private Vector3 scale;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
    }
    public void HurtPlayer()
    {
        scale = transform.localScale;
        if (scale.x == 1)
        {
            rb2d.AddForce(-lookDir * recoilForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce(lookDir * recoilForce, ForceMode2D.Impulse);
        }
        animator.SetBool("Hurt", true);
        health.ReduceHealth();
    }
    public void KillPlayer()
    {
        animator.SetBool("Hurt", false);
        animator.SetBool("Death", true);
        Invoke("PlayerDead", 1.0f);
        this.enabled = false;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);
        PlayCrouchAnimation();
        //PlayJumpAnimation(vertical);
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }
    private void Update()
    {
        bool vertical = Input.GetKeyDown(KeyCode.Space);
        if (vertical) 
        {
            PlayerJump();
            animator.SetBool("Jump", true);
        }

        
    }

    private void PlayerJump()
    {
        if (isGrounded)
        {
            extraJumps = 2;
        }
        if (extraJumps > 0)
        {
            rb2d.velocity = Vector2.up * jump;
            extraJumps--;
        }
        else if (extraJumps == 0 && isGrounded)
        {
            rb2d.velocity = Vector2.up * jump;
        }
    }

    private void MoveCharacter(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * movementSpeed * Time.deltaTime;
        transform.position = position;
        lookDir = Camera.main.ScreenToWorldPoint(position);
    }
    private void PlayCrouchAnimation()
    {
        animator.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        scale = transform.localScale;
        scale.x = (horizontal < 0 ? -1 : (horizontal>0?1:scale.x)) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    public void HurtAnimationFalse()
    {
        animator.SetBool("Hurt", false);
    }
    public void JumpAnimationFalse()
    {
        animator.SetBool("Jump", false);
    }
    public void movementSound()
    {
        SoundManager.Instance.Play(Sounds.PlayerMove);
    }
    public void jumpUpSound()
    {
        SoundManager.Instance.Play(Sounds.PlayerJumpUp);
    }
    public void jumpDownSound()
    {
        SoundManager.Instance.Play(Sounds.PlayerJumpDown);
    }
    public void PlayerDead()
    {
        gameOverController.PlayerDied();
    }
}
