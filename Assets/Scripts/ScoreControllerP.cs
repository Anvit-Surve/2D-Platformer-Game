using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControllerP : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int scoreP = 0;
    public int Pizza;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUIP();
    }

    public void IncreaseScorePizza(int increment)
    {
        scoreP += increment;
        RefreshUIP();
    }
    private void RefreshUIP()
    {
        scoreText.text = $": {scoreP}/{Pizza}";
    }

    public bool Score()
    {
        if (scoreP >= Pizza)
        {
            return true;
        }
        return false;
    }
}
