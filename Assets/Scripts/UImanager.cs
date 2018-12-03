using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
	[SerializeField]
	private Text SecondaryWeaponText;
	public void SetNumerOfSecondaryWeapon(int numberToSet){
		SecondaryWeaponText.text = numberToSet.ToString();
	}
}
