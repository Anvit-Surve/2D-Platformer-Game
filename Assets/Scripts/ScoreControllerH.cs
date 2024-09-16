using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControllerH : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int scoreH = 0;
    public int HotWings;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUIH();
    }

    public void IncreaseScoreHW(int increment)
    {
        scoreH += increment;
        RefreshUIH();
    }
    private void RefreshUIH()
    {
        scoreText.text = $": {scoreH}/{HotWings}";
    }

    public bool Score()
    {
        if (scoreH >= HotWings)
        {
            return true;
        }
        return false;
    }
}
