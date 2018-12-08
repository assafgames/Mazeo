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
			var bulletInstanse = (GameObject) Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			Bullet bullet = bulletInstanse.GetComponent<Bullet> ();
			bullet.ownerTag = "Enemy";
			bullet.FireToDirection(transform.forward);
			lastShot = Time.time;
		}
	}

}