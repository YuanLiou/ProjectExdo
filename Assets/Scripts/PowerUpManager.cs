using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {

    public Text scoreText;
    private bool doublePointMode;
    private bool spikeProffMode;

    private bool powerUpActive;
    private float powerUpLengthCounter;

    private ScoreManager scoreManager;
    private PlatformGenerator platformGenerator;

    private float normalPointPerSecond;
    private float normalSpikeRate;

    // Use this for initialization
    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        platformGenerator = FindObjectOfType<PlatformGenerator>();

        normalPointPerSecond = scoreManager.pointPerSecond;
        normalSpikeRate = platformGenerator.spikeGenerateThreshold;
    }

    // Update is called once per frame
    void Update () {
        if (powerUpActive) {
            powerUpLengthCounter -= Time.deltaTime;

            if (doublePointMode) {
                scoreManager.coinDoublePoints = true;
                scoreText.GetComponent<Text>().color = new Color(1f, 0.9f, 0f);
            }

            if (spikeProffMode) {
                platformGenerator.spikeGenerateThreshold = 0f;
                scoreText.GetComponent<Text>().color = Color.white;
            }

            if (powerUpLengthCounter < 0) {
                scoreText.GetComponent<Text>().color = Color.white;
                platformGenerator.spikeGenerateThreshold = normalSpikeRate;
                scoreManager.coinDoublePoints = false;
                doublePointMode = false;
                spikeProffMode = false;
                powerUpActive = false;
            }
        }
    }

    public void ActivePowerUpMode(bool doublePointMode, bool spikeProffMode, float length) {
        this.doublePointMode = doublePointMode;
        this.spikeProffMode = spikeProffMode;
        this.powerUpLengthCounter = length;
        powerUpActive = true;

        if (spikeProffMode) {
            GameObject[] killboxes = GameObject.FindGameObjectsWithTag("KillBox");
            foreach (GameObject killbox in killboxes) {
                if (killbox.name.StartsWith("Spike")) {
                    killbox.SetActive(false);
                }
            }
        }
    }

    public void InActivePowerUpMode() {
        powerUpLengthCounter = 0;
    }
}