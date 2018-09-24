using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

	public float moveSpeed = 10;
	public float rotationSpeed = 10;
	public Vector3 eulers;

	void Start () {
		eulers = transform.eulerAngles;
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		float forwardSpeed = vertical * moveSpeed * Time.deltaTime;
		float strafSpeed = horizontal * moveSpeed * Time.deltaTime;
		float xRotation = mouseY * rotationSpeed * Time.deltaTime * -1;
		float yRotation = mouseX * rotationSpeed * Time.deltaTime;

		//rotate
		eulers.x += xRotation;
		eulers.y += yRotation;
		transform.eulerAngles = eulers;
		
		//move
		transform.Translate (strafSpeed, 0.0f, forwardSpeed);

	}
}