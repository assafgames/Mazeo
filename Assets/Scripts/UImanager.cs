using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
	[SerializeField]
	private Text SecondaryWeaponText;
	[SerializeField]
	private Image image;
	[SerializeField]
	private GameObject secondaryWeapon;
	[SerializeField]
	private Text EnergyBoxesCountText;

	public void SetNumerOfSecondaryWeapon (int numberToSet) {
		SecondaryWeaponText.text = numberToSet.ToString ();
	}

	public void SetSecondaryImage (Sprite spriteToSet) {
		secondaryWeapon.SetActive(true);		
		image.sprite = spriteToSet;
	}

	public void SetNumerOfEnergyBoxes (int numberToSet) {
		EnergyBoxesCountText.text = numberToSet.ToString ();
	}
}