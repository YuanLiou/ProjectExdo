using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingTextController : ProjectComponent {

    private GameHUDView gameHudView;
    private bool blinking = false;
    public float readyTextBlinkSpeed;

    // Use this for initialization
    void Start() {
        gameHudView = app.view.gameHudView;
    }

    // Update is called once per frame
    void Update() {
        if (blinking) {
            gameHudView.readyText.color = new Color(gameHudView.readyText.color.r, gameHudView.readyText.color.g, gameHudView.readyText.color.b, Mathf.Round(Mathf.PingPong(Time.time * readyTextBlinkSpeed, 1.0f)));
        }
    }

    public void SetReadyTextBlinking(bool start) {
        blinking = start;
        gameHudView.readyText.enabled = start;
    }
}