using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGeneratorStartPoint;

	public PlayerController playerController;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformDestroyers;

	// Use this for initialization
	void Start () {
		platformGeneratorStartPoint = platformGenerator.position;
		playerStartPoint = playerController.transform.position;
	}
	
	// Update is called once per frame
	void Update () {}

	public void RestartGame() {
		StartCoroutine("RestartGameCoroutine");
	}

	private IEnumerator RestartGameCoroutine() {
		playerController.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		platformDestroyers = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < platformDestroyers.Length; i++) {
			platformDestroyers[i].gameObject.SetActive(false);
		}
		
		playerController.transform.position = playerStartPoint;
		platformGenerator.position = platformGeneratorStartPoint;
		playerController.gameObject.SetActive(true);
	}
}
