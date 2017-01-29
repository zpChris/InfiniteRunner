using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public ParticleSystem collectableAnim;
	[HideInInspector] public static Vector3 speed; //instance of rb.velocity so it can be modified
	[HideInInspector] public static Vector3 position; //instance of rb.position so it can be modified/used
	[HideInInspector] public static float distance; //adds 1 for every platform, used to calculate score
	[HideInInspector] public static bool alive; //bool to check if alive
	[HideInInspector] public static bool isGrounded; //checks if ball is grounded
	private bool jumpRight;
	private bool jumpLeft;
	private bool start; //tests to see if first platform has been touched
	private float startPosition, endPosition;
	private float startJumpTime; //keeps track of when jump starts
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = Vector3.zero;
		position = Vector3.zero;
		distance = 0.0f;
		alive = true;
		isGrounded = false;
		start = false;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
	}

	void Update() {
		position = rb.position;
		if (jumpRight) {
			position.z = Mathf.Lerp (startPosition, endPosition, (Time.time - startJumpTime) * (1.0f / 0.50f));
			rb.position = position;
		}
		if (jumpLeft) {
			position.z = Mathf.Lerp (startPosition, endPosition, (Time.time - startJumpTime) * (1.0f / 0.50f));
			rb.position = position;
		}
	}

	void FixedUpdate () {
		if (start) {
			Debug.Log (rb.velocity.x);
			setSpeed ();
			if (isGrounded && (TouchpadForward.jumpForward || TouchpadRight.jumpRight || TouchpadLeft.jumpLeft)) {
				rb.AddForce(new Vector3(0.0f, 750.0f, 0.0f));
				if (TouchpadRight.jumpRight) {
					jumpRight = true;
					startPosition = rb.position.z;
					endPosition = rb.position.z - 5.0f;
				}
				if (TouchpadLeft.jumpLeft) {
					jumpLeft = true;
					startPosition = rb.position.z;
					endPosition = rb.position.z + 5.0f;
				}
			}
			if (rb.position.y < -10.0f) {
				rb.gameObject.SetActive (false);
				alive = false;
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		//checks if ball is touching platform AND not touching the back edge of the platform (screws up jumping)
		if (other.gameObject.tag == "SafePlatform" && rb.position.x > (other.transform.position.x - other.transform.localScale.x/2.0f)) {
			distance++;
			isGrounded = true;
		}
		start = true;
		jumpRight = false;
		jumpLeft = false;
		rb.velocity = new Vector3 (speed.x, 0.0f, 0.0f);
		rb.angularVelocity = Vector3.zero;
	}
		
		
	void OnCollisionExit(Collision other) {
		isGrounded = false;
		startJumpTime = Time.time;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Collectable") {
			Instantiate (collectableAnim, other.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			Destroy (other.gameObject);
		}
	}

	void setSpeed() {
		speed = rb.velocity;
		//speed increases quickly until it reaches 35, then increases much more slowly
		if (rb.velocity.x < 35.0f) {
			rb.AddForce (35.0f, 0.0f, 0.0f);
		} else if (rb.velocity.x >= 35.0f) {
			speed.x = 35.0f + GameplayManager.elapsedTime / 10.0f;
			rb.velocity = speed;
		}
	}
}
