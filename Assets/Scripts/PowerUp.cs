using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ProjectComponents {

    public bool doublePointMode;
    public bool spikeProffMode;

    public float powerUpLength;
    private PowerUpManager powerUpManager;
    private SoundController soundController;

    public Sprite[] diamondSprites;

    // Use this for initialization
    void Start () {
        powerUpManager = FindObjectOfType<PowerUpManager>();
        soundController = app.controller.soundController;
    }

    private void Awake() {
        int powerUpSelector = Random.Range(0, 2);
        GetComponent<SpriteRenderer>().sprite = diamondSprites[powerUpSelector];
        switch (powerUpSelector) {
            case 0:
                doublePointMode = true;
                break;
            case 1:
                spikeProffMode = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("Player")) {
            soundController.PlayPowerUpSound();
            powerUpManager.ActivePowerUpMode(doublePointMode, spikeProffMode, powerUpLength);
        }
        gameObject.SetActive(false);
    }
}