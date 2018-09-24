using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject bulletObj;
	public GameObject boomObj;

	private void Start () {
		Destroy (this.gameObject, 15.0f);
	}

	private void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Player")
		{
			return;
		}

		bulletObj.SetActive (false);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		if (boomObj != null) {
			boomObj.SetActive (true);
		}
		Destroy (this.gameObject, 0.1f);
	}

}