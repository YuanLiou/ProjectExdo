using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : ProjectComponent {
    public float score;
    public float scorePerSecond;
    private float highScoreCounts;

    public float HighScoreCounts {
        get { return highScoreCounts; }
    }

    // Use this for initialization
    void Start() {
        if (PlayerPrefs.HasKey("HighScores")) {
            highScoreCounts = PlayerPrefs.GetFloat("HighScores");
        }
    }

    // Update is called once per frame
    void Update() {
        if (score > highScoreCounts) {
            highScoreCounts = score;
            PlayerPrefs.SetFloat("HighScores", highScoreCounts);
        }
    }
}