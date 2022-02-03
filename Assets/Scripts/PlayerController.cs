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
    public ScoreControllerP scoreControllerp;
    public ScoreControllerH scoreControllerh;
    public GameOverController gameOverController;
    public Health health;
    public float recoilForce;
    private bool attack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

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
        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);
        PlayCrouchAnimation();
        HandleAttacks();
        ResetValues();
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScoreKey(1);
    }
    public void PickUpPizza()
    {
        scoreControllerp.IncreaseScorePizza(1);
    }
    public void PickUpHotWings()
    {
        scoreControllerh.IncreaseScoreHW(1);
    }
    private void Update()
    {
        HandleInput();
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
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Melee"))
        {
            position.x += horizontal * movementSpeed * Time.deltaTime;
        }
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
    private void HandleAttacks()
    {
        if(attack && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Melee"))
        {
            animator.SetTrigger("Melee");
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attack = true;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage();
            }
        }
        bool vertical = Input.GetKeyDown(KeyCode.Space);
        if (vertical)
        {
            PlayerJump();
            animator.SetBool("Jump", true);
        }
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
    private void ResetValues()
    {
        attack = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
