using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject bulletObj;
	public GameObject boomObj;
	public string ownerTag = "Player";
	public int damage = 10;

	private void Start () {
		Destroy (this.gameObject, 15.0f);
	}

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
			health.Hit (damage);
		}
		Destroy (this.gameObject, 0.1f);
	}

}