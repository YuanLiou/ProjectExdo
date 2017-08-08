using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;
	
	// Ground checking properties
	public bool isOnGround;
	public LayerMask whatIsGround;

	private Rigidbody2D myRigidbody;
	private Collider2D myCollider;
	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D>();
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Detect the ground
		isOnGround = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		
		// Moving right
		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
		
		// Jump (Space and left key of mouse)
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (isOnGround) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
			}
		}
		
		// Setup animators
		myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool("IsOnGround", isOnGround);
	}
}
