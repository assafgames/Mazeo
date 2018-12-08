using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileBox : MonoBehaviour {

	public float thrust = 1;
	public GameObject misilePrefab;
	public Sprite misileSprite;
	public UImanager uImanager;

	void Start () {
		Vector3 torque = new Vector3 (Random.Range (-thrust, thrust), Random.Range (-thrust, thrust), Random.Range (-thrust, thrust));
		GetComponent<Rigidbody> ().AddTorque (torque);
	}

	private void OnCollisionEnter (Collision other) {
		if (other.transform.tag == "Player") {
			PlayerShooter playerShooter = other.gameObject.GetComponent<PlayerShooter> ();
			playerShooter.misilePrefab = misilePrefab;
			uImanager.SetSecondaryImage(misileSprite);
			playerShooter.SetNumberOfMissiles (10);
			Destroy (this.gameObject);
		}
	}
}