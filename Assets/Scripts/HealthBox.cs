using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour {

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			Health health = other.gameObject.GetComponent<Health> ();
			if (health != null) {
				health.Revive ();
			}
			Destroy (this.gameObject, 0.1f);
		}

	}
}