using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	public Vector3 closePosition;
	private Vector3 nextPoint;
	private Vector3 targetPoint;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
		nextPoint = transform.position;
		targetPoint = closePosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.Lerp (transform.position, targetPoint, speed);
		
		//set next point if needed
		float distToNextPoint = Vector3.Distance (transform.position, targetPoint);

		if (distToNextPoint < 0.2) {
			Vector3 tmpPoint = targetPoint;
			targetPoint = nextPoint;
			nextPoint = tmpPoint;
		}
	}

	private void OnDrawGizmos () {
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube (closePosition, transform.localScale );
	}
}
