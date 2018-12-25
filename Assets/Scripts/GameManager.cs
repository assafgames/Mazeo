using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public UImanager uImanager;
	public List<EnergyCube> healthBoxs = new List<EnergyCube> ();
	private int numberOfEnergyCubes = 0;

	private void Start () {

		if (uImanager) {
			healthBoxs = new List<EnergyCube> (FindObjectsOfType<EnergyCube>()) ;
			numberOfEnergyCubes = healthBoxs.Count;
			uImanager.SetNumerOfEnergyBoxes (numberOfEnergyCubes);
			foreach (EnergyCube energyCube in healthBoxs) {
				energyCube.OnExpload += ReduceEnergyCube;
			}
		}
	}

	private void ReduceEnergyCube () {
		numberOfEnergyCubes--;
		uImanager.SetNumerOfEnergyBoxes (numberOfEnergyCubes);
		if (numberOfEnergyCubes < 1) {
			GoToNextLevel ();
		}
	}

	public void GoToMenu () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		GoToLevel(0);
	}

	public void GoToNextLevel () {
		GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void GoToLevel (int level) {
		SceneManager.LoadScene (level);
	}
}