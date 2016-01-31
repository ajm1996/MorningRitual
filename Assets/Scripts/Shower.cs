using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shower : MonoBehaviour {

	Slider slide;
	GameObject ShowerSlider; 
	Announcement announce;
	int doOnce;
	bool inRange;
	// Use this for initialization
	void Start () {
		doOnce = 0;
		slide = GetComponentInChildren<Slider>();
		ShowerSlider = slide.transform.parent.gameObject;
		//announce = GameObject.Find ("Announce text").GetComponentInChildren<Announcement> ();
		inRange = false;
		ShowerSlider.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(inRange){
			if (slide.value < slide.maxValue) {
				slide.value += .005F;
			}
			if(slide.value == slide.maxValue){
				if (doOnce < 1) {
					GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
					doOnce++;
				}
				ShowerSlider.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
			ShowerSlider.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (slide.value < slide.maxValue) {
				slide.value -= .1F;
			}
			inRange = false;
			ShowerSlider.SetActive (false);
		}
	}
}
