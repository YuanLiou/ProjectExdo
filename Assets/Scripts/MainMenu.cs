using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string playLevel;
    
    public void StartGame() {
        SceneManager.LoadScene(playLevel);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
