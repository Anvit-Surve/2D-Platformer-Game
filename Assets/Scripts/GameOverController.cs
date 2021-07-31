using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button ButtonRestart;

    private void Awake()
    {
        ButtonRestart.onClick.AddListener(RestartScene);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
