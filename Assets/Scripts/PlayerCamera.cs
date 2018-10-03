﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	private void Awake () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}