using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    public Button ButtonRestart;
    public Button NextLevel;
    public Button MainMenu;

    private void Awake()
    {
        ButtonRestart.onClick.AddListener(RestartScene);
        NextLevel.onClick.AddListener(nextLevel);
        MainMenu.onClick.AddListener(mainMenu);
        SoundManager.Instance.Play(Sounds.LevelComplete);
    }
    public void PlayerWon()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }
    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void nextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void mainMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
