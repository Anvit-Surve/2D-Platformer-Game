using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() && gameObject.tag == "Key")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<PlayerController>() && gameObject.tag == "HW")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpHotWings();
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<PlayerController>() && gameObject.tag == "Pizza")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpPizza();
            Destroy(gameObject);
        }
    }
}
