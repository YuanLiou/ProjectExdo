using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : ProjectComponent {

    public Button pauseButton;

    public void ShowPauseButton(bool show) {
        pauseButton.gameObject.SetActive(show);
    }
}
