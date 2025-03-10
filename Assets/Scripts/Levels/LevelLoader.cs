﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;

        public string LevelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetlevelStatus(LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    break;
                case LevelStatus.Unlocked:
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    SceneManager.LoadScene(LevelName);
                    break;
                case LevelStatus.Completed:
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    SceneManager.LoadScene(LevelName);
                    break;
            }
        }
    }
}