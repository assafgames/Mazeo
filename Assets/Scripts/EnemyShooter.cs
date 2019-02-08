using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : BaseShooter {

	public float fireSpeed = 10;
	public float fireRate = 2f;
	public GameObject target = null;
	private float lastShot = 0.0f;
	public GameObject weapon;
	public float attackRadius = 50;
	private Quaternion weaponOriginalTransform;

	private void Start () {
		if (weapon == null) {
			weapon = this.gameObject;
		}

		// get player ref as default
		if (target == null) {
			target = GameObject.FindWithTag ("Player");
		}

		weaponOriginalTransform = weapon.transform.localRotation;
	}

	private void Update () {
		if (Vector3.Distance (transform.position, target.transform.position) < attackRadius) {
			weapon.transform.LookAt (target.transform,Vector3.up);
			Shoot (target.transform);
		} else {
			//weapon.transform.LookAt (Vector3.forward);
			weapon.transform.transform.localRotation = weaponOriginalTransform;//Quaternion.identity;
		}
	}
	public void Shoot (Transform target) {

		if (Time.time > fireRate + lastShot) {
			var bulletInstanse = (GameObject) Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			Bullet bullet = bulletInstanse.GetComponent<Bullet> ();
			bullet.ownerTag = "Enemy";
			bullet.FireAtTarget (target.position);
			lastShot = Time.time;
		}
	}

}