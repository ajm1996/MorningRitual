using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shower : MonoBehaviour {

	Slider slide;
	bool inRange;

	void Start () {
		slide = GetComponentInChildren<Slider>();
		gameObject.SetActive (false);
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange) {
			if (slide.value < slide.maxValue) {
				slide.value += (1/10f) * Time.deltaTime;
			}
			if (slide.value >= slide.maxValue) {
				GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
				gameObject.SetActive (false);
			} 
		} else if (slide.value > 0) {
			slide.value -= (1/10f) * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = false;
		}
	}
}
