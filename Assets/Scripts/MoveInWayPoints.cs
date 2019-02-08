using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInWayPoints : MonoBehaviour {

	public List<Vector3> wayPoints = new List<Vector3> ();
	public Color pathColor = Color.red;
	public float speed = 0.5f;
	public GameObject target = null;
	public bool lookAtNextPoint = true;
	private Vector3 nextPoint;
	private int nextPointIndex = 0;
	public bool stoped = false;
	public float gizmoSize = 1;
	private EnemyShooter enemyShooter;

	void Start () {
		// add current pos as first
		wayPoints.Insert (0, transform.position);
		nextPoint = wayPoints[wayPoints.Count - 1];
		
		enemyShooter = GetComponent<EnemyShooter> ();
		// get player ref as default
		if (target == null) {
			target = GameObject.FindWithTag ("Player");
		}
	}

	void Update () {

		if (stoped) {
			return;
		}

		if (lookAtNextPoint && enemyShooter != null && Vector3.Distance (transform.position, target.transform.position) > enemyShooter.attackRadius) {
			transform.LookAt (nextPoint);
			transform.position = Vector3.Lerp (transform.position, nextPoint, speed * Time.deltaTime);
		}

		//set next point if needed
		float distToNextPoint = Vector3.Distance (transform.position, nextPoint);

		if (distToNextPoint < 0.2) {
			nextPoint = GetNextWayPoint ();
		}

	}

	private Vector3 GetNextWayPoint () {
		if (nextPointIndex == -1) {
			nextPointIndex = 0;
		} else if (nextPointIndex == wayPoints.Count - 1) {
			nextPointIndex = 0;
		} else {
			nextPointIndex += 1;
		}

		return wayPoints[nextPointIndex];
	}

	private void OnDrawGizmos () {
		Gizmos.color = pathColor;
		foreach (Vector3 pos in wayPoints) {
			Gizmos.DrawCube (pos, Vector3.one * gizmoSize);
		}
	}
}