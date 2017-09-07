using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickupPoint : MonoBehaviour {
    public int score;
    private ScoreManager scoreManager;
    private AudioSource coinSound;

    // Use this for initialization
    void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Equals("Player")) {
            if (coinSound.isPlaying) {
                coinSound.Stop();
            }
            coinSound.Play();

            scoreManager.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}