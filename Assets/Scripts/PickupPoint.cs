using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickupPoint : ProjectComponents {
    public int score;
    private ScoreController scoreController;
    private SoundController soundController;

    // Use this for initialization
    void Start() {
        scoreController = app.controller.scoreController;
        soundController = app.controller.soundController;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Equals("Player")) {
            soundController.PlayPickCoinSound();
            scoreController.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}