using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//this touchpad is slightly larger than the others to make it easier for the user to touch the center of the screen

public class TouchpadRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool touched;
	private int pointerID;
	public static bool jumpRight;

	void Awake () {
		touched = false;
		jumpRight = false;
	}

	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			if (!(TouchpadForward.jumpForward || TouchpadLeft.jumpLeft)) {
				jumpRight = true;
			}
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (data.pointerId == pointerID) {
			touched = false;
			jumpRight = false;
		}
	}
}