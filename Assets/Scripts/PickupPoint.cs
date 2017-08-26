using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickupPoint : MonoBehaviour {

	public int score;
	private ScoreManager scoreManager;
	
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			scoreManager.AddScore(score);
			gameObject.SetActive(false);
		}
	}
}
