using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : ProjectComponent {

    public bool doubleScoreMode, scoreIncreasing;

    private ScoreModel scoreModel;
    private GameHUDView gameHudView;

    void Start() {
        scoreModel = app.model.scoreModel;
        gameHudView = app.view.gameHudView;
    }

    // Update is called once per frame
    void Update() {
        if (scoreIncreasing) {
            scoreModel.score += scoreModel.scorePerSecond * Time.deltaTime;
        }

        // update canvas view
        gameHudView.SetScoreText(Mathf.Round(scoreModel.score).ToString());
        gameHudView.SetHighScoreText(Mathf.Round(scoreModel.HighScoreCounts).ToString());
    }

    public void ResetScore() {
        scoreModel.ResetScore();
    }

    public void AddScore(int score) {
        scoreModel.score += doubleScoreMode ? (score * 2) : score;
    }
}