
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCube : MonoBehaviour {

	public event System.Action OnExpload;

	public float thrust;

	void Start () {
		Vector3 torque = new Vector3 (Random.Range (-thrust, thrust), Random.Range (-thrust, thrust), Random.Range (-thrust, thrust));
		GetComponent<Rigidbody> ().AddTorque (torque);
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Bullet"){
			if(OnExpload!=null){
				OnExpload();
				gameObject.SetActive(false);
			}
		}
	}

}