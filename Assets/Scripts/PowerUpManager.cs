using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : ProjectComponent {
    private bool powerUpActive;
    private float powerUpLengthCounter;

    private GameModel gameModel;
    private ScoreController scoreController;
    private PlatformGenerator platformGenerator;
    private ScoreView scoreView;

    private float defaultSpikeRate;

    // Use this for initialization
    void Start () {
        gameModel = app.model.gameModel;
        scoreController = app.controller.scoreController;
        scoreView = app.view.scoreView;
        platformGenerator = FindObjectOfType<PlatformGenerator>();
        defaultSpikeRate = platformGenerator.spikeGenerateThreshold;
    }

    // Update is called once per frame
    void Update () {
        if (powerUpActive) {
            powerUpLengthCounter -= Time.deltaTime;

            if (gameModel.extraPlayerState == ExtraPlayerState.DOULBE_SCORE) {
                scoreController.doubleScoreMode = true;
                scoreView.SetDoubleScoreTextColor();
            }

            if (gameModel.extraPlayerState == ExtraPlayerState.SPIKE_PROFF) {
                platformGenerator.spikeGenerateThreshold = 0f;
                scoreView.ResetScoreTextColor();
            }

            if (powerUpLengthCounter < 0) {
                platformGenerator.spikeGenerateThreshold = defaultSpikeRate;
                scoreController.doubleScoreMode = false;
                powerUpActive = false;
                scoreView.ResetScoreTextColor();
                gameModel.ResetExtraPlayerState();
            }
        }
    }

    public void ActivePowerUpMode(ExtraPlayerState superPower, float length) {
        gameModel.extraPlayerState = superPower;
        powerUpLengthCounter = length;
        powerUpActive = true;

        if (superPower == ExtraPlayerState.SPIKE_PROFF) {
            GameObject[] killboxes = GameObject.FindGameObjectsWithTag("KillBox");
            foreach (GameObject killbox in killboxes) {
                if (killbox.GetComponent<SpikeView>() != null) {
                    killbox.SetActive(false);
                }
            }
        }
    }

    public void InActivePowerUpMode() {
        gameModel.ResetExtraPlayerState();
        powerUpLengthCounter = 0;
    }
}