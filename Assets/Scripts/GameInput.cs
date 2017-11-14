using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : ProjectComponent {

    private PlayerController playerController;

    void Start() {
        playerController = app.controller.playerController;
    }

    // Update is called once per frame
    void Update() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) {
            playerController.Jump();
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))) {
            playerController.JumpHolding();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            playerController.LockJumpAction();
        }
    }
}