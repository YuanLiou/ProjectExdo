using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDiamondModel : ProjectComponent {

    public ExtraPlayerState superPower;
    public float powerUpLength;

    public bool isDoubleScorePower() {
        return superPower == ExtraPlayerState.DOULBE_SCORE;
    }

    public bool isSpikeProffPower() {
        return superPower == ExtraPlayerState.SPIKE_PROFF;
    }
}