using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchpadForward : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool touched;
	private int pointerID;
	public static bool jumpForward;

	void Awake () {
		touched = false;
		jumpForward = false;
	}

	public void OnPointerDown (PointerEventData data) {
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			if (!(TouchpadLeft.jumpLeft || TouchpadRight.jumpRight)) {
				jumpForward = true;
			}
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (data.pointerId == pointerID) {
			touched = false;
			jumpForward = false;
		}
	}
}