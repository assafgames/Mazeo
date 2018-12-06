using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject bulletObj;
	public GameObject boomObj;
	public string ownerTag = "Player";
	public int damage = 10;
	public float damageRadius = 0;
	private Transform target = null;
	private Vector3 pointToHit = Vector3.zero;
	public float speed = 1;
	/* Represents the homing sensitivity of the missile.
Range [0.0,1.0] where 0 will disable homing and 1 will make it follow the target like crazy.
This param is fed into the Slerp (defines the interpolation point to pick) */
	float homingSensitivity = 0.2f;
	public bool followTarget = false;

	private void Start () {
		Destroy (this.gameObject, 20.0f);
	}

	void Update () {
		if (followTarget) {

			if (target != null) {
				Vector3 relativePos = target.position - transform.position;
				Quaternion rotation = Quaternion.LookRotation (relativePos);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, homingSensitivity);
			} else {
				transform.LookAt (pointToHit);
			}

			transform.Translate (0, 0, speed * Time.deltaTime, Space.Self);
		}

	}

	// fire bullet at a given ray
	public void Fire (Ray ray) {
		GetComponent<Rigidbody> ().velocity = ray.direction * (speed);
	}

	// follow bullet to a target
	public void Fire (Transform target) {
		this.target = target;
	}

	// fire at a target point
	public void Fire (Vector3 target) {
		this.pointToHit = target;
	}

	// bullet collide
	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == ownerTag) {
			return;
		}

		bulletObj.SetActive (false);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		if (boomObj != null) {
			boomObj.SetActive (true);
		}

		Health health = other.gameObject.GetComponent<Health> ();
		if (health != null) {
			health.Hit (damage, transform.position);
		}

		if (damageRadius > 0) {
			Collider[] hitColliders = Physics.OverlapSphere (other.gameObject.transform.position, damageRadius);

			for (int i = 0; i < hitColliders.Length; i++) {
				Health enemyInRadius = hitColliders[i].gameObject.gameObject.GetComponent<Health> ();
				if (enemyInRadius != null) {
					enemyInRadius.Hit (damage, transform.position);
				}
			}
		}

		Destroy (this.gameObject, 0.1f);
	}

}