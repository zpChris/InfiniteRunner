using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public Text DistanceText;
	public Text RestartText;
	private float distance;

	void Update() {
		Distance ();
		if (!PlayerMovement.alive) {
			RestartText.text = "Touch to Restart";
		} else {
			RestartText.text = "";
		}
	}

	void Distance() {
		distance = PlayerMovement.distance;
		DistanceText.text = Mathf.Round (distance).ToString ();
	}


}
