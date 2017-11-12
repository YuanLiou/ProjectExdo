using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DiamondView : ProjectComponent {

    private DiamondModel diamondModel;
    private ScoreController scoreController;
    private SoundController soundController;

    // Use this for initialization
    void Start() {
        diamondModel = GetComponent<DiamondModel>();
        scoreController = app.controller.scoreController;
        soundController = app.controller.soundController;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Equals("Player")) {
            soundController.PlayPickCoinSound();
            scoreController.AddScore(diamondModel.score);
            gameObject.SetActive(false);
        }
    }
}