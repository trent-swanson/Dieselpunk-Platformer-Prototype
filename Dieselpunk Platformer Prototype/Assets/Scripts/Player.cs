using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody rb;
	bool onGround = false;

	public float speed = 5;
	public float jumpSpeed = 5;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f) * speed;
		movement.y = rb.velocity.y;
		rb.velocity = movement;

		if (Input.GetKeyDown(KeyCode.Space) && onGround) {
			onGround = false;
			rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		onGround = true;
	}
}
