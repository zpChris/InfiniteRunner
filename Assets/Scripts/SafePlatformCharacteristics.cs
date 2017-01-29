using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePlatformCharacteristics : MonoBehaviour {

	[HideInInspector] public static bool spawnedNew; //checks to see if it has spawned a platform

	private Renderer safePlatformRenderer; //renderer used to change platform color


	void Start () {

		spawnedNew = false;

		safePlatformRenderer = GetComponent<Renderer> ();
	}

	void Update() {

		if (PlayerMovement.position.x > transform.position.x + 50) {
			Destroy (gameObject);
		}
	}


	void OnCollisionEnter(Collision other) {
		spawnedNew = true; //spawns new platform
	}

	void OnCollisionStay (Collision other) {
		safePlatformRenderer.material.color = new Color (0.04f, 0.825f, 0.0f, 0.865f); //change color
	}
}
