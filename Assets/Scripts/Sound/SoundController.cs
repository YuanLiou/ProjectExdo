using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : ProjectComponent {

    private Sound sound;

    // Use this for initialization
    void Start() {
        sound = app.view.sound;
    }

    public void PlayPickCoinSound() {
        Play(sound.coinSound);
    }

    public void PlayJumpSound() {
        Play(sound.jumpSound);
    }

    public void PlayPlayerDeathSound() {
        Play(sound.deathSound);
    }

    public void PlayPowerUpSound() {
        Play(sound.powerUpSound);
    }

    private void Play(AudioSource audioSource) {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.Play();
    }
}