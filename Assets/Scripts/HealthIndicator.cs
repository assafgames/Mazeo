using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour {

	public Slider mainSlider;
	public Text text;
	public float value = 100;
	public float maxValue = 100;

	public void SetValue (float health) {
		value = health;
		mainSlider.value = value;
		text.text = value.ToString();
	}

	public void SetMaxValue (float maxValueToSet) {
		maxValue = maxValueToSet;
		mainSlider.maxValue = maxValue;
	}

}