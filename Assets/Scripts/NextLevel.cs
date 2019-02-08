using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

	[SerializeField]
	private Image Star1image;
	[SerializeField]
	private Image Star2image;
	[SerializeField]
	private Image Star3image;

	public void ShowStars (int numberOfStars) {
		Star1image.enabled = numberOfStars > 0;
		Star2image.enabled = numberOfStars > 1;
		Star3image.enabled = numberOfStars > 2;
	}

}
