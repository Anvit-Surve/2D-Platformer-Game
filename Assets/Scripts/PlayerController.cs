﻿using System;
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
    public Health health;

    public int Restart;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    public void HurtPlayer()
    {
        animator.SetBool("Hurt", true);
        health.ReduceHealth();
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(Restart);
    }
    public void KillPlayer()
    {
        animator.SetBool("Death", true);
        Invoke("RestartScene", 1.0f);
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal);
        PlayCrouchAnimation();
        PlayJumpAnimation(vertical);
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
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
        animator.SetBool("Jump", vertical > 0);        
    }
    private void PlayCrouchAnimation()
    {
        animator.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        scale.x = (horizontal < 0 ? -1 : (horizontal>0?1:scale.x)) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    public void HurtAnimationFalse()
    {
        animator.SetBool("Hurt", false);
    }
}
