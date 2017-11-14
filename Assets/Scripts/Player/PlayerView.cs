using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : ProjectComponent {

    private PlayerController playerController;

    // Ground checking properties
    public bool isOnGround;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    public float groundCheckRadius;

    void Start() {
        playerController = app.controller.playerController;
    }

    void Update() {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.x);
        GetComponent<Animator>().SetBool("IsOnGround", isOnGround);
    }

    public void MoveRight(float speed) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Jump(float force) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("KillBox")) {
            playerController.Die();
        }
    }

}