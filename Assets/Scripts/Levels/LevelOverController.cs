﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{

    public class LevelOverController : MonoBehaviour
    {
        public LevelCompleteController Levelcompletecontroller;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                Debug.Log("Level Finished");
                Levelcompletecontroller.PlayerWon();
                LevelManager.Instance.MarkCurrentLevelComplete();
            }
        }
    }
}
