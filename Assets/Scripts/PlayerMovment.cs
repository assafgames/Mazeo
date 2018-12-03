using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour, IStopable {

	public float moveSpeed = 10;
	public float boostFactor = 2;
	public float verticalSpeed = 3;
	public float rotationSpeed = 10;
	public Vector3 eulers;
	public float clampAngle = 60.0f;
	public GameObject ship;
	public float smoothTime = 0.3F;
	public float maxTurnAngle = 30.0F;
	private float turnVelocity = 0.0F;
	private float xTurn = 0.0F;
	private Rigidbody rb;
	private Burners burners;
	private bool stoped = false;
	public bool Stoped {
		get {
			return stoped;
		}

		set {
			stoped = value;
		}
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		eulers = transform.eulerAngles;
		burners = GetComponent<Burners> ();
	}

	void FixedUpdate () {
		if (stoped) {
			return;
		}
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		bool up = Input.GetKey(KeyCode.E);
		bool down = Input.GetKey(KeyCode.C);
		bool boost = Input.GetKey(KeyCode.LeftShift);
print(boost);
		int xMultiplayer = -1;

		float forwardSpeed = vertical * moveSpeed * Time.deltaTime;
		if(boost)
		{
			forwardSpeed = forwardSpeed * boostFactor;
		}
		float strafSpeed = horizontal * moveSpeed * Time.deltaTime;
		float xRotation = mouseY * rotationSpeed * Time.deltaTime * xMultiplayer;
		float yRotation = mouseX * rotationSpeed * Time.deltaTime;
		float upSpeed = 0;

		if(up){
			upSpeed = verticalSpeed * Time.deltaTime ;	
		}else if(down){
			upSpeed = -verticalSpeed * Time.deltaTime;
		}
		
		// rotate
		eulers.x += xRotation;

		// make sure not to turm upside doen and mess up y direction
		eulers.x = Mathf.Clamp (eulers.x, -clampAngle, clampAngle);
		eulers.y += yRotation;
		transform.eulerAngles = eulers;

		if (strafSpeed > 0.2f) {
			xTurn = Mathf.SmoothDamp (xTurn, maxTurnAngle, ref turnVelocity, smoothTime);
		} else if (strafSpeed < -0.2f) {
			xTurn = Mathf.SmoothDamp (xTurn, -maxTurnAngle, ref turnVelocity, smoothTime);
		} else {
			xTurn = 0;
		}
		ship.transform.localRotation = new Quaternion (xTurn, 180, 00, 0);

		// move
		rb.velocity = Vector3.zero; //this prevents the rb from move if it had a force aplayed to it
		transform.Translate (strafSpeed, upSpeed, forwardSpeed);
		burners.ActivateBurners (vertical);
	}

	public void Stop () {
		this.stoped = true;
	}
}