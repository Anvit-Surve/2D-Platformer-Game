using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numofHearts;
    public Image[] hearts;
    public Image[] emptyhearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public PlayerController playerController;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numofHearts)
            {
                health = numofHearts;
            }
            hearts[i].sprite = i < health ? fullHeart:emptyHeart;
            hearts[i].enabled = i < numofHearts ? true : false;
        }
    }

    public void ReduceHealth()
    {
        if (health == 0)
        {
            playerController.KillPlayer();
        }
        else
        {
            health -= 1;
        }
    }
}
