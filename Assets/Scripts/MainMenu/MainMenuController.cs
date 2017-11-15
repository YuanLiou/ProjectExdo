using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : ProjectComponent {

    private GameModel gameModel;

    // Use this for initialization
    void Start() {
        gameModel = app.model.gameModel;
    }

    public void StartGame() {
        SceneManager.LoadScene(gameModel.level1SceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
