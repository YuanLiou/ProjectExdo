using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : DeathMenu {

    public GameObject pauseMenu;

    public void PauseGame() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public override void Retry() {
        ResumeGame();
        base.Retry();
    }

    public override void QuitToMainMenu() {
        ResumeGame();
        base.QuitToMainMenu();
    }
}
