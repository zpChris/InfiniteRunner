using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchpadLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool touched;
	private int pointerID;
	public static bool jumpLeft;

	void Awake () {
		touched = false;
		jumpLeft = false;
	}

	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			if (!(TouchpadForward.jumpForward || TouchpadRight.jumpRight)) {
				jumpLeft = true;
			}
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (data.pointerId == pointerID) {
			touched = false;
			jumpLeft = false;
		}
	}
}