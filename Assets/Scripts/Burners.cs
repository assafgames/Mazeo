using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burners : MonoBehaviour {

	public Transform leftBurner;
	public Transform rightBurner;
	public float offset = 0.5f;

	private Vector3 leftBurnerInitialPos;
	private Vector3 rightBurnerInitialPos;

	private void Start () {
		leftBurnerInitialPos = leftBurner.localPosition;
		rightBurnerInitialPos = rightBurner.localPosition;
	}

	public void ActivateBurners (float forward) {

		if (forward > 0) {
			leftBurner.localPosition = new Vector3 (leftBurnerInitialPos.x, leftBurnerInitialPos.y, leftBurnerInitialPos.z + offset);
			rightBurner.localPosition = new Vector3 (rightBurnerInitialPos.x, rightBurnerInitialPos.y, rightBurnerInitialPos.z + offset);;
		} else {
			leftBurner.localPosition = leftBurnerInitialPos;
			rightBurner.localPosition = rightBurnerInitialPos;
		}
	}
}