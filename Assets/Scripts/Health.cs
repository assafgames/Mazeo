using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int healthLevel = 100;
	public GameObject dieBoom;
	public GameObject modelToHideOnDie;

	public void Hit (int demage) {
		healthLevel -= demage;
		if (healthLevel <= 0) {
			Die ();
		}
	}

	private void Die () {
		if (dieBoom != null) {
			dieBoom.SetActive (true);
		}
		if (modelToHideOnDie != null) {
			modelToHideOnDie.SetActive (false);
		}
		Destroy (this.gameObject, 1.0f);
	}
}