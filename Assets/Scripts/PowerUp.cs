using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public bool doublePointMode;
    public bool spikeProffMode;

    public float powerUpLength;
    private PowerUpManager powerUpManager;
    private AudioSource powerUpSource;

    public Sprite[] diamondSprites;

    // Use this for initialization
    void Start () {
        powerUpManager = FindObjectOfType<PowerUpManager>();
        powerUpSource = GameObject.Find("PowerUpSound").GetComponent<AudioSource>();
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
            powerUpSource.Play();
            powerUpManager.ActivePowerUpMode(doublePointMode, spikeProffMode, powerUpLength);
        }
        gameObject.SetActive(false);
    }
}