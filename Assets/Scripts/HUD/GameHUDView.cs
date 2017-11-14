using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDView : ProjectComponent {

    public Text scoreText, highScoreText;
    public Text readyText;

    public void SetScoreText(String score) {
        scoreText.text = "Score: " + score;
    }

    public void SetHighScoreText(String highScore) {
        highScoreText.text = "High Score: " + highScore;
    }

    public void SetDoubleScoreTextColor() {
        scoreText.GetComponent<Text>().color = new Color(1f, 0.9f, 0f);
    }

    public void ResetScoreTextColor() {
        scoreText.GetComponent<Text>().color = Color.white;
    }
}