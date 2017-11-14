using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : ProjectComponent {

    public ScoreController scoreController;
    public BlinkingTextController blinkingTextController;
    public SoundController soundController;
    public DeathMenuController deathMenuController;
    public PauseMenuController pauseMenuController;
    public DiamondsGenerator diamondsGenerator;
    public PlatformGenerator platformGenerator;
    public CameraController cameraController;
    public PowerUpManager powerUpManager;
    public PlayerController playerController;
}