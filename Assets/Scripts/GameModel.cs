using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExtraPlayerState {
    NONE,
    DOULBE_SCORE,
    SPIKE_PROFF
}

public class GameModel : ProjectComponent {

    public ExtraPlayerState extraPlayerState;
    public bool isPause;
    public readonly string mainMenuName = "main_menu";

    public void ResetExtraPlayerState() {
        extraPlayerState = ExtraPlayerState.NONE;
    }
}