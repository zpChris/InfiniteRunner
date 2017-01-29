using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {

	public static float startTime;
	public static float elapsedTime;

	void Start() {
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time - startTime;
		aliveCheck ();
	}

	//checks if alive and reloads scene if screen is touched
	void aliveCheck() { 
		if (!PlayerMovement.alive) {
			if (TouchpadForward.jumpForward || TouchpadLeft.jumpLeft || TouchpadRight.jumpRight) {
				SceneManager.LoadScene ("3dRunner");
			}
		}
	}
			
}
