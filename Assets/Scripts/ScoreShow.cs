using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class cat : MonoBehaviour
{
    public PointsControl score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = null;
        score = FindObjectOfType<PointsControl>();
        UpdateScoreText();
    }

    void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null && score != null)
        {
            scoreText.text = "Your Score: " + score.puntos;
        }
    }

}
