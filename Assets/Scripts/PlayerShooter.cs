using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : BaseShooter, IStopable {

	public GameObject bulletPrefab;
	public GameObject misilePrefab;
	public Transform bulletSpawn;
	public float fireRateInSeconds = 0.1f;
	public Camera mainCam;
	public UImanager uImanager;
	private int numberOfMissiles = 0;
	private bool allowfire = true;

	private bool stoped = false;
	public bool Stoped {
		get {
			return stoped;
		}

		set {
			stoped = value;
		}
	}

	public void Stop () {
		this.stoped = true;
	}

	private void Update () {
		if (Input.GetMouseButton (0) && allowfire) {
			StartCoroutine (FirePrimaryBullet ());
		}

		if (Input.GetMouseButtonDown (1) && allowfire) {
			FireSecondaryBullet ();
		}
	}

	IEnumerator FirePrimaryBullet () {
		allowfire = false;

		// Create the Bullet from the Bullet Prefab
		var primaryBullet = (GameObject) Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		var ray = mainCam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		primaryBullet.GetComponent<Bullet> ().FireToDirection (ray.direction);

		yield return new WaitForSeconds (fireRateInSeconds);
		allowfire = true;
	}

	private void FireSecondaryBullet () {

		if (numberOfMissiles == 0) {
			return;
		}

		numberOfMissiles--;
		uImanager.SetNumerOfSecondaryWeapon (numberOfMissiles);
		RaycastHit hit;
		var ray = mainCam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		if (Physics.Raycast (ray, out hit)) {

			// Create the Bullet from the Bullet Prefab
			var secondaryBullet = (GameObject) Instantiate (
				misilePrefab,
				bulletSpawn.position,
				bulletSpawn.rotation);

			Bullet misile = secondaryBullet.GetComponent<Bullet> ();

			if (hit.transform.tag == "Enemy" && misile.guided) {
				misile.FireAtTarget (hit.transform);
			} else {
				misile.FireToDirection ((hit.point - misile.transform.position).normalized);
			}
		}

	}

	public void SetNumberOfMissiles (int numberOfMissilesToSet) {
		numberOfMissiles = numberOfMissilesToSet;
		uImanager.SetNumerOfSecondaryWeapon (numberOfMissiles);
	}

}