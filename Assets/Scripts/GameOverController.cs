using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button ButtonRestart;
    public Button MainMenu;

    private void Awake()
    {
        ButtonRestart.onClick.AddListener(RestartScene);
        MainMenu.onClick.AddListener(mainMenu);
        SoundManager.Instance.Play(Sounds.LevelFailed);
    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }
    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void mainMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
