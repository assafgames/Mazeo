﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public event Action OnDie;
	public int healthLevel = 100;
	public GameObject dieBoom;
	public GameObject hitBoom;
	public GameObject modelToHideOnDie;
	private MoveInWayPoints movment; 
	private ParticleSystem hitBoomParticleSystem;

	private void Start () {
		if(hitBoom!=null){
			hitBoomParticleSystem = hitBoom.GetComponent<ParticleSystem> ();
		}
		movment = GetComponent<MoveInWayPoints>();
	}

	public void Hit (int demage, Vector3 position) {
		healthLevel -= demage;
		if (healthLevel <= 0) {
			Die ();
		} else if (hitBoom != null) {
			hitBoom.transform.position = position;
			hitBoomParticleSystem.Play ();
		}
	}

	private void Die () {

		if (dieBoom != null) {
			dieBoom.SetActive (true);
		}

		if (modelToHideOnDie != null) {
			modelToHideOnDie.SetActive (false);
		}

		if(movment != null){
			movment.stoped = true;
		}

		if(OnDie != null){
			OnDie();
		}else{
			Destroy (this.gameObject, 2.0f);
		}

	}
}