using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    private int scoreK = 0;
    public int Keys;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUIK();
    }

    public void IncreaseScoreKey(int increment)
    {
        scoreK += increment;
        RefreshUIK();
    }
    private void RefreshUIK()
    {
        scoreText.text = $": {scoreK}/{Keys}";
    }

    public bool Score()
    {
        if (scoreK >= Keys)
        {
            return true;
        }
        return false;
    }
}
