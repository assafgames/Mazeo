using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : BaseShooter {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float forwardSpeed = 100;
	public float fireSpeed = 20;
	public float fireRateInSeconds = 0.1f;
	public Camera mainCam;

	private bool allowfire = true;

	private void Update () {
		if (Input.GetMouseButton (0) && allowfire) {
			StartCoroutine (Fire ());
		}
	}

	IEnumerator Fire () {
		allowfire = false;

		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject) Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		var ray = mainCam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		bullet.GetComponent<Rigidbody> ().velocity = ray.direction * (forwardSpeed + fireSpeed);

		yield return new WaitForSeconds (fireRateInSeconds);
		allowfire = true;
	}
}