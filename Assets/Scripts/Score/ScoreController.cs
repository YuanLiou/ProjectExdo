using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : ProjectComponent {

    public float scorePerSecond;
    public bool doubleScoreMode, scoreIncreasing;

    private ScoreModel scoreModel;
    private ScoreView scoreView;

    void Start() {
        scoreModel = app.model.scoreModel;
        scoreView = app.view.scoreView;
    }

    // Update is called once per frame
    void Update() {
        if (scoreIncreasing) {
            scoreModel.score += scorePerSecond * Time.deltaTime;
        }

        // update canvas view
        scoreView.SetScoreText(Mathf.Round(scoreModel.score).ToString());
        scoreView.SetHighScoreText(Mathf.Round(scoreModel.HighScoreCounts).ToString());
    }

    public void ResetScore() {
        scoreModel.score = 0;
    }

    public void AddScore(int score) {
        scoreModel.score += doubleScoreMode ? (score * 2) : score;
    }
}