using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ProjectComponent, DeathMenuCallback, PauseMenuCallback {

    public Transform platformGenerator;
    private GameModel gameModel;
    private Vector3 platformGeneratorStartPoint;

    public PlayerController playerController;
    private PowerUpManager powerUpManager;
    private ScoreController scoreController;
    private DeathMenuController deathMenuController;
    private PauseMenuController pauseMenuController;
    private BlinkingTextController blinkingTextController;
    private bool prepare;

    // Use this for initialization
    void Start () {
        gameModel = app.model.gameModel;
        platformGeneratorStartPoint = platformGenerator.position;
        powerUpManager = app.controller.powerUpManager;
        scoreController = app.controller.scoreController;
        blinkingTextController = app.controller.blinkingTextController;
        deathMenuController = app.controller.deathMenuController;
        deathMenuController.SetDeathMenuCallback(this);
        pauseMenuController = app.controller.pauseMenuController;
        pauseMenuController.SetPauseMenuCallback(this);

        ShowReadyText();
    }

    public void RestartGame() {
        scoreController.scoreIncreasing = false;
        playerController.PlayerActive(false);
        deathMenuController.ShowDeathMenu(true);
        pauseMenuController.ShowPauseButton(false);
    }

    public void ResetGame() {
        powerUpManager.InActivePowerUpMode();
        deathMenuController.ShowDeathMenu(false);
        ObjectDestroyer[] objectDestroyers = FindObjectsOfType<ObjectDestroyer>();
        for (int i = 0; i < objectDestroyers.Length; i++) {
            objectDestroyers[i].gameObject.SetActive(false);
        }
        playerController.ResetPlayerPosition();
        platformGenerator.position = platformGeneratorStartPoint;

        scoreController.scoreIncreasing = false;
        scoreController.ResetScore();
        playerController.PlayerActive(false);
        ShowReadyText();
    }

    private void ShowReadyText() {
        blinkingTextController.SetReadyTextBlinking(true);
        if (prepare) {
           StopAllCoroutines();
        }
        StartCoroutine(GameStartWaiting());
    }

    IEnumerator GameStartWaiting() {
        prepare = true;
        yield return new WaitForSeconds(3f);

        blinkingTextController.SetReadyTextBlinking(false);
        playerController.PlayerActive(true);
        scoreController.scoreIncreasing = true;
        pauseMenuController.ShowPauseButton(true);
        prepare = false;
    }

    // region DeathMenuCallback start
    public void OnDeathMenuRetryItemClicked() {
        ResetGame();
    }

    public void OnDeathMenuQuitToMainMenuItemClicked() {
        SceneManager.LoadScene(gameModel.mainMenuName);
    }
    // end region DeathMenuCallback

    // region PauseMenuCallback start
    public void OnPause() {
        Time.timeScale = 0f;
        gameModel.isPause = true;
    }

    public void OnResume() {
        Time.timeScale = 1f;
        gameModel.isPause = false;
    }

    public void OnPauseMenuRetryClicked() {
        ResetGame();
    }

    public void OnPauseQuitToMainMenuClicked() {
        SceneManager.LoadScene(gameModel.mainMenuName);
    }
    // end region DeathMenuCallback
}