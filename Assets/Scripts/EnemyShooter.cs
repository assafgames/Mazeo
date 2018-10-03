using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : BaseShooter {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float fireSpeed = 10;
	public float fireRate = 2f;

	private float lastShot = 0.0f;

	public void Shoot (Transform target) {
		if (Time.time > fireRate + lastShot) {
			var bullet = (GameObject) Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			bullet.GetComponent<Bullet> ().ownerTag = "Enemy";
			bullet.GetComponent<Rigidbody> ().velocity = transform.forward * fireSpeed ;
			lastShot = Time.time;
		}
	}

}