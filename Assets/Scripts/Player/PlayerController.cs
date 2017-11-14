using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ProjectComponent {
    private PlayerModel playerModel;
    private PlayerView playerView;
    private SoundController soundController;
    private GameModel gameModel;
    public GameManager gameManager;

    private float jumpTimeCounter;
    private bool stopJumpping;
    private bool canDoubleJumping;
    private Vector3 startPosition;
    // Level
    private float speedMilestoneCounts;
    private float speedMilestoneCountsOrigin;

    // Use this for initialization
    void Start() {
        playerModel = app.model.playerModel;
        playerView = app.view.playerView;
        soundController = app.controller.soundController;
        gameModel = app.model.gameModel;

        speedMilestoneCounts = gameModel.speedIncreaseMilestone;
        speedMilestoneCountsOrigin = speedMilestoneCounts;

        startPosition = playerView.transform.position;
    }

    // Update is called once per frame
    void Update() {
        // Speed up if pass the speed milestone
        if (playerView.transform.position.x > speedMilestoneCounts) {
            speedMilestoneCounts += gameModel.speedIncreaseMilestone;
            playerModel.moveSpeed = playerModel.moveSpeed * gameModel.playerSpeedMutiplier;
            gameModel.speedIncreaseMilestone += gameModel.speedIncreaseMilestone * gameModel.playerSpeedMutiplier;
        }
        // Moving right
        playerView.MoveRight(playerModel.moveSpeed);

        if (playerView.isOnGround) {
            jumpTimeCounter = playerModel.jumpTime;
            canDoubleJumping = true;
        }
    }

    public void Jump() {
        if (isActiveAndEnabled && !gameModel.isPause) {
            if (playerView.isOnGround) {
                playerView.Jump(playerModel.jumpForce);
                stopJumpping = false;
                soundController.PlayJumpSound();
            } else if (canDoubleJumping) {
                canDoubleJumping = false;
                jumpTimeCounter = playerModel.jumpTime;
                playerView.Jump(playerModel.jumpForce);
                stopJumpping = false;
                soundController.PlayJumpSound();
            }
        }
    }

    public void JumpHolding() {
        if (!stopJumpping) {
            if (jumpTimeCounter > 0) {
                playerView.Jump(playerModel.jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
    }

    public void LockJumpAction() {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;    // Lock user keeping jumping
            stopJumpping = true;
        }
    }

    public void PlayerActive(bool active) {
        gameObject.SetActive(active);
        playerView.gameObject.SetActive(active);
    }

    public void Die() {
        soundController.PlayPlayerDeathSound();
        gameManager.RestartGame();
        playerModel.ResetToDefault();
        gameModel.ResetLevel();

        speedMilestoneCounts = speedMilestoneCountsOrigin;
    }

    public void ResetPosition() {
        playerView.transform.position = startPosition;
    }
}