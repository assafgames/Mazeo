using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public UImanager uImanager;
	public List<EnergyCube> healthBoxs = new List<EnergyCube> ();
	public PlayerCamera playerCamera;
	private int numberOfEnergyCubes = 0;
	public Player player;

	public int CurrentLevel {
		get {
			return PlayerPrefs.GetInt ("CURRENT_LEVEL");
		}

		set {
			PlayerPrefs.SetInt ("CURRENT_LEVEL", value);
		}
	}

	private void Start () {
		if (uImanager) {
			healthBoxs = new List<EnergyCube> (FindObjectsOfType<EnergyCube> ());
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
			ShowNextLevel(2);
		}
	}

	public void PlayerDied () {
		GoToMenu ();
	}

	public void GoToMenu () {
		GoToLevel (0);
	}

	public void GoToNextLevel () {
		GoToLevel (CurrentLevel + 1);
	}

	public void GoToLevel (int level) {
		if(level < 3)
		{
			CurrentLevel = level;
			SceneManager.LoadScene (level);
		}
		else
		{
			GoToMenu();
		}
	}

	private void ShowNextLevel(int numberOfStars)
	{
		player.StopPlayer();
		playerCamera.ReleaseMouse();
		uImanager.ShowNextLevelPanel(numberOfStars);
	}
}