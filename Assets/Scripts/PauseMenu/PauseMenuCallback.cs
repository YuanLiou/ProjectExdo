using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PauseMenuCallback {
    void OnPause();
    void OnResume();
    void OnPauseMenuRetryClicked();
    void OnPauseQuitToMainMenuClicked();
}