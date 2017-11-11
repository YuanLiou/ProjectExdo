using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickupPoint : ProjectComponents {
    public int score;
    private ScoreController scoreController;
    private AudioSource coinSound;

    // Use this for initialization
    void Start() {
        scoreController = app.controller.scoreController;
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Equals("Player")) {
            if (coinSound.isPlaying) {
                coinSound.Stop();
            }
            coinSound.Play();

            scoreController.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}