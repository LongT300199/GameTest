using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
	walk,
	attack,
	interact
}

public class PlayerMovement : MonoBehaviour {

	public PlayerState currentState;
	public float speed;
	private Rigidbody2D playerRigidBody;
	private Vector3 change;
	private Animator animator;


	// Use this for initialization
	void Start () {
		currentState = PlayerState.walk;
		playerRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		// Set initial animator to down
		animator.SetFloat("moveX", 0);
		animator.SetFloat("moveY", -1);
	}
	
	// Update is called once per frame
	void Update () {
		change = Vector3.zero;
		// GetAxisRaw removes smoothing from normal GetAxis
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		if (Input.GetButtonDown("attack") && currentState != PlayerState.attack) {
			StartCoroutine(AttackCo());
		} else if (currentState == PlayerState.walk) {
			UpdateAnimationAndMove();
		}
	}

	private IEnumerator AttackCo() {
		animator.SetBool("attacking", true);
		currentState = PlayerState.attack;
		// Wait 1 frame
		yield return null;
		animator.SetBool("attacking", false);
		// Wait for animation duration
		yield return new WaitForSeconds(.3f);
		currentState = PlayerState.walk;
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
		// Normalize diagonal movement
		change.Normalize();
		playerRigidBody.MovePosition(
			transform.position + change * speed * Time.deltaTime
		);
	}
}
