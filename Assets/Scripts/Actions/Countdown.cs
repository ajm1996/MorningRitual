using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	Slider slide;

	void Start () {
		slide = GetComponentInChildren<Slider>();
		gameObject.SetActive (false);
		slide.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		slide.value -= (1/20f) * Time.deltaTime;

		if (slide.value <= 0) {
			GameObject.Find("Game Over Menu").SendMessage ("Kill");
		} 
	}
}
