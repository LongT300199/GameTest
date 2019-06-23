using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D playerRigidBody;
	private Vector3 change;
	private Animator animator;


	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		change = Vector3.zero;
		// GetAxisRaw removes smoothing from normal GetAxis
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		UpdateAnimationAndMove();
	}

	void UpdateAnimationAndMove() {
		// If moving
		if (change != Vector3.zero) {
			MoveCharacter();
			// Change idle animation
			animator.SetFloat("moveX", change.x);
			animator.SetFloat("moveY", change.y);
			// Change walking animation
			animator.SetBool("moving", true);
		} else {
			animator.SetBool("moving", false);
		}
	}

	void MoveCharacter() {
		playerRigidBody.MovePosition(
			transform.position + change * speed * Time.deltaTime
		);
	}
}
