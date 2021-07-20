using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    //private void Awake()
    //{
    //    Debug.Log("Player Controller Awake");
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision: " + collision.gameObject.name);
    //}


    private void Update()
    {
        //Run Script
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Crouch Script
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if (Crouch)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        //Jump Script
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //bool Jump = Input.GetKey("space");
        //if(Jump)
        //{
        //    animator.SetBool("Jump", true);
        //}
    }
}
