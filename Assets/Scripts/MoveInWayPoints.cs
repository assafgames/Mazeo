using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInWayPoints : MonoBehaviour {

	public List<Vector3> wayPoints = new List<Vector3> ();
	public Color pathColor = Color.red;
	public float speed = 0.5f;
	public GameObject target;
	public float attackRadius = 5;
	private Vector3 nextPoint;
	private int nextPointIndex = 0;
	public bool stoped = false;
	public float gizmoSize = 1;

	void Start () {
		// add current pos as first
		nextPoint = transform.position;
		wayPoints.Insert (0, nextPoint);
	}

	void Update () {
		if(stoped){
			return;
		}
		// go after player if needed
		if (target != null && Vector3.Distance (transform.position, target.transform.position) < attackRadius) {
			transform.LookAt (target.transform);
			EnemyShooter enemyShooter = GetComponent<EnemyShooter> ();
			enemyShooter.Shoot (target.transform);
		} else {
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