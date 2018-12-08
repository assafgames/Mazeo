using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public UImanager uImanager;
	public List<EnergyCube> healthBoxs = new List<EnergyCube>();
	private int numberOfEnergyCubes = 0;

	private void Start() {

		numberOfEnergyCubes = healthBoxs.Count;

		uImanager.SetNumerOfEnergyBoxes(numberOfEnergyCubes);

		foreach (EnergyCube energyCube in healthBoxs)
		{
			energyCube.OnExpload += ReduceEnergyCube;
		}
	}

	private void ReduceEnergyCube(){
		numberOfEnergyCubes--;
		uImanager.SetNumerOfEnergyBoxes(numberOfEnergyCubes);
		if(numberOfEnergyCubes < 1){
			GoToNextLevel();
		}
	}

	public void GoToMenu(){
		print("GOTO MENU LEVEL !!!");
		//SceneManager.LoadScene(0);
	}

	public void GoToNextLevel(){
		print("LEVEL COMPLEATED !!!");
		//SceneManager.LoadScene(0);
	}
}
