using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : ProjectComponent {

    public Text scoreText, highScoreText;

    public void SetScoreText(String score) {
        scoreText.text = "Score: " + score;
    }

    public void SetHighScoreText(String highScore) {
        highScoreText.text = "High Score: " + highScore;
    }
}