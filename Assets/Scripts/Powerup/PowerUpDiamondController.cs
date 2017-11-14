using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDiamondController : ProjectComponent {

    public PowerUpManager powerUpManager;
    private PowerUpDiamondModel powerUpDiamondModel;

    void Awake() {
        powerUpDiamondModel = GetComponent<PowerUpDiamondModel>();
        int powerUpSelector = Random.Range(0, 2);
        GetComponent<PowerUpDiamondView>().SetDiamondStyle(powerUpSelector);
        switch (powerUpSelector) {
            case 0:
                powerUpDiamondModel.superPower = ExtraPlayerState.DOULBE_SCORE;
                break;
            case 1:
                powerUpDiamondModel.superPower = ExtraPlayerState.SPIKE_PROFF;
                break;
        }
    }

    void Start() {
        powerUpManager = app.controller.powerUpManager;
    }

    public void PowerUp() {
        powerUpManager.ActivePowerUpMode(powerUpDiamondModel.superPower, powerUpDiamondModel.powerUpLength);
    }
}