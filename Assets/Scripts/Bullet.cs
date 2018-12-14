using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject bulletObj;
	public GameObject boomObj;
	public string ownerTag = "Player";
	public int damage = 10;
	public float damageRadius = 0;
	public float speed = 1;
	public bool guided = false;
	private Transform target = null;
	private Vector3 targetPosition = Vector3.zero;
	/* Represents the homing sensitivity of the missile.
Range [0.0,1.0] where 0 will disable homing and 1 will make it follow the target like crazy.
This param is fed into the Slerp (defines the interpolation point to pick) */
	private float homingSensitivity = 0.2f;
	private bool followTarget = false;

	private void Start () {
		Destroy (this.gameObject, 20.0f);
	}

	void Update () {

		if (followTarget) {
			if (target != null) {
				this.targetPosition = target.position;
			}
			Vector3 relativePos = this.targetPosition - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, homingSensitivity);
			transform.LookAt (this.targetPosition);
			transform.Translate (0, 0, speed * Time.deltaTime, Space.Self);
		}

	}

	// fire bullet at a given direction
	public void FireToDirection (Vector3 direction) {
		followTarget = false;
		GetComponent<Rigidbody> ().velocity = direction * (speed);
	}

	// follow bullet to a target
	public void FireAtTarget (Transform target) {
		followTarget = true;
		this.target = target;
	}

	public void FireAtTarget (Vector3 target) {
		followTarget = true;
		this.targetPosition = target;
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
				GameObject objectInRadius = hitColliders[i].gameObject;
				if (objectInRadius.tag == "Enemy") {
					Health enemyInRadius = objectInRadius.GetComponent<Health> ();
					if (enemyInRadius != null) {
						enemyInRadius.Hit (damage, transform.position);
					}
				}
			}
		}

		Destroy (this.gameObject, 1f);
	}

}