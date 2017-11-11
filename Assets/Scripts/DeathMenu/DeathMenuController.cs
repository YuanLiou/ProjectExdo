using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : ProjectComponent {

    private DeathMenuView deathMenuView;
    private DeathMenuCallback deathMenuCallback;

    void Start() {
        deathMenuView = app.view.deathMenuView;
    }

    public void ShowDeathMenu(bool show) {
        deathMenuView.gameObject.SetActive(show);
    }

    public void SetDeathMenuCallback(DeathMenuCallback callback) {
        this.deathMenuCallback = callback;
    }

    public void Retry() {
        deathMenuCallback.OnDeathMenuRetryItemClicked();
    }

    public void QuitToMainMenu() {
        deathMenuCallback.OnDeathMenuQuitToMainMenuItemClicked();
    }
}

public interface DeathMenuCallback {
    void OnDeathMenuRetryItemClicked();
    void OnDeathMenuQuitToMainMenuItemClicked();
}