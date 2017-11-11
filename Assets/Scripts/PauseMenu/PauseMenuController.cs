using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : ProjectComponent {

    private PauseMenuView pauseMenuView;
    private PauseMenuCallback pauseMenuCallback;

    private void Start() {
        pauseMenuView = app.view.pauseMenuView;
    }

    public void SetPauseMenuCallback(PauseMenuCallback callback) {
        this.pauseMenuCallback = callback;
    }

    public void ShowPauseButton(bool show) {
        pauseMenuView.ShowPauseButton(show);
    }

    public void PauseGame() {
        pauseMenuView.gameObject.SetActive(true);
        pauseMenuCallback.OnPause();
        ShowPauseButton(false);
    }

    public void ResumeGame() {
        pauseMenuView.gameObject.SetActive(false);
        pauseMenuCallback.OnResume();
        ShowPauseButton(true);
    }

    public void Retry() {
        ResumeGame();
        pauseMenuCallback.OnPauseMenuRetryClicked();
    }

    public void QuitToMainMenu() {
        ResumeGame();
        pauseMenuCallback.OnPauseQuitToMainMenuClicked();
    }
}