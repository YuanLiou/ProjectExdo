using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDiamondView : ProjectComponent {

    private PowerUpDiamondController powerUpDiamondController;
    private SoundController soundController;

    public Sprite[] diamondSprites;

    // Use this for initialization
    void Start () {
        soundController = app.controller.soundController;
        powerUpDiamondController = GetComponent<PowerUpDiamondController>();
    }

    public void SetDiamondStyle(int style) {
        GetComponent<SpriteRenderer>().sprite = diamondSprites[style];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("Player")) {
            soundController.PlayPowerUpSound();
            powerUpDiamondController.PowerUp();
        }
        gameObject.SetActive(false);
    }
}