using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : ProjectComponents {

    private SoundModel soundModel;

    // Use this for initialization
    void Start() {
        soundModel = app.model.soundModel;
    }

    public void PlayPickCoinSound() {
        Play(soundModel.coinSound);
    }

    public void PlayJumpSound() {
        Play(soundModel.jumpSound);
    }

    public void PlayPlayerDeathSound() {
        Play(soundModel.deathSound);
    }

    public void PlayPowerUpSound() {
        Play(soundModel.powerUpSound);
    }

    private void Play(AudioSource audioSource) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.Play();
    }
}