using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

	public float moveSpeed = 10;
	public float rotationSpeed = 10;
	public Vector3 eulers;
	public float clampAngle = 60.0f;
	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		eulers = transform.eulerAngles;
	}

	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		int xMultiplayer = -1;

		float forwardSpeed = vertical * moveSpeed * Time.deltaTime;
		float strafSpeed = horizontal * moveSpeed * Time.deltaTime;
		float xRotation = mouseY * rotationSpeed * Time.deltaTime * xMultiplayer;
		float yRotation = mouseX * rotationSpeed * Time.deltaTime;

		//rotate
		eulers.x += xRotation;
		// make sure not to turm upside doen and mess up y direction
		eulers.x = Mathf.Clamp (eulers.x, -clampAngle, clampAngle);
		eulers.y += yRotation;
		transform.eulerAngles = eulers;

		//move
		rb.velocity = Vector3.zero;//this prevents the rb from move if it had a force aplayed to it
		transform.Translate (strafSpeed, 0.0f, forwardSpeed);

	}
}