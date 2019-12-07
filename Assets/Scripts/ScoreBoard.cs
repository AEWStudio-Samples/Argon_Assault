using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // con fig vars
    [Tooltip("Default Points Per Kill"), SerializeField]
    int defaultPPK = 10;

    // state vars
    int score;
    Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScore();
    }

    public void AddPoints(int pointsPK)
    {
        if (pointsPK == 0) pointsPK = defaultPPK;
        score += pointsPK;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString("000000000");
    }
}
