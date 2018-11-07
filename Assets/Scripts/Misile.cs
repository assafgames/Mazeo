using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour {

	private Transform target = null;
	private Vector3 pointToHit = Vector3.zero;
	public float speed = 1;
	/* Represents the homing sensitivity of the missile.
Range [0.0,1.0] where 0 will disable homing and 1 will make it follow the target like crazy.
This param is fed into the Slerp (defines the interpolation point to pick) */
	float homingSensitivity = 0.2f;

	void Update () {
		if (target != null) {
			Vector3 relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, homingSensitivity);
		} else {
			transform.LookAt (pointToHit);
		}

		transform.Translate (0, 0, speed * Time.deltaTime, Space.Self);
		//rb.AddRelativeForce (new Vector3(0, 0, speed * Time.deltaTime), ForceMode.Impulse);
	}

	public void Fire (Transform target) {
		this.target = target;
	}

	public void Fire (Vector3 target) {
		this.pointToHit = target;
	}

}