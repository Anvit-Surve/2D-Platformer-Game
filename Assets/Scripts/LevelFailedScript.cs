using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedScript : MonoBehaviour
{
    public int Respawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level Failed");
            SceneManager.LoadScene(Respawn);
        }
    }
}
