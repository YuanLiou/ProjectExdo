using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainSceneName;

    public virtual void Retry() {
        FindObjectOfType<GameManager>().ResetGame();
    }

    public virtual void QuitToMainMenu() {
        SceneManager.LoadScene(mainSceneName);
    }

}
