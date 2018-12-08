using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Health health;
	private PlayerMovment playerMovment;
	private PlayerShooter playerShooter;
	public GameManager gameManager;

	void Start () {
		health = GetComponent<Health>();
		health.OnDie += PlayerDie;
		playerMovment = GetComponent<PlayerMovment> ();
		playerShooter = GetComponent<PlayerShooter> ();
	}

	void PlayerDie () {
		playerMovment.Stop();
		playerShooter.Stop();
		gameManager.GoToMenu();
	}
}