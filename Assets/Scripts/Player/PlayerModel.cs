using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : ProjectComponent {
    public float moveSpeed;
    private float defaultMoveSpeed;
    
    public float jumpForce;
    public float jumpTime;

    void Start() {
        defaultMoveSpeed = moveSpeed;
    }

    public void ResetToDefault() {
        moveSpeed = defaultMoveSpeed;
    }
}