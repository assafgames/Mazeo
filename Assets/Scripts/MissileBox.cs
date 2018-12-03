using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBox : MonoBehaviour {

	public float thrust = 1;

	void Start () {
		Vector3 torque = new Vector3 (Random.Range (-thrust, thrust), Random.Range (-thrust, thrust), Random.Range (-thrust, thrust));
		GetComponent<Rigidbody> ().AddTorque (torque);
	}

	private void OnCollisionEnter(Collision other) {
		if (other.transform.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerShooter>().SetNumberOfMissiles(10);
			Destroy(this.gameObject);
		}
	}
}
