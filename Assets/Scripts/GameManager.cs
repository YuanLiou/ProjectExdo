﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGeneratorStartPoint;

	public PlayerController playerController;
	private Vector3 playerStartPoint;

	private ObjectDestroyer[] objectDestroyers;
	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		platformGeneratorStartPoint = platformGenerator.position;
		playerStartPoint = playerController.transform.position;

		scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {}

	public void RestartGame() {
		StartCoroutine("RestartGameCoroutine");
	}

	private IEnumerator RestartGameCoroutine() {
		scoreManager.scoreIncreasing = false;
		playerController.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		
		objectDestroyers = FindObjectsOfType<ObjectDestroyer>();
		for (int i = 0; i < objectDestroyers.Length; i++) {
			objectDestroyers[i].gameObject.SetActive(false);
		}
		
		playerController.transform.position = playerStartPoint;
		platformGenerator.position = platformGeneratorStartPoint;
		playerController.gameObject.SetActive(true);
		
		scoreManager.scoreCounts = 0;
		scoreManager.scoreIncreasing = true;
	}
}