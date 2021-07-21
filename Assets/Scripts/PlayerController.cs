using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float movementSpeed;
    public float jump;
    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision: " + collision.gameObject.name);
    //}
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal);
        PlayCrouchAnimation();
        PlayJumpAnimation(vertical);
    }

    private void Update()
    {
        
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector2 position = transform.position;
        position.x += horizontal * movementSpeed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
    private void PlayJumpAnimation(float vertical)
    {
        //if (vertical > 0)
        //{
            animator.SetBool("Jump", vertical > 0);
        //}
        //else
        //{
        //    animator.SetBool("Jump", false);
        //}

        //bool Jump = Input.GetKey("space");
        //if(Jump)
        //{
        //    animator.SetBool("Jump", true);
        //}
    }
    private void PlayCrouchAnimation()
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if (Crouch)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
