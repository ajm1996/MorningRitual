using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sink : MonoBehaviour {

	Slider slide;
<<<<<<< HEAD
	GameObject SinkSlider; 
	Announcement announce;
	int doOnce;
	bool inRange;
	// Use this for initialization
	void Start () {
		doOnce = 0;
		slide = GetComponentInChildren<Slider>();
		SinkSlider = slide.transform.parent.gameObject;
		announce = GameObject.Find ("Announce text").GetComponentInChildren<Announcement> ();
		inRange = false;
		SinkSlider.SetActive (false);
=======
	bool inRange;

	void Start () {
		slide = GetComponentInChildren<Slider>();
		gameObject.SetActive (false);
		inRange = false;
>>>>>>> origin/master
	}

	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if(inRange){
			if (slide.value < slide.maxValue) {
				slide.value += .005F;
			}
			if(slide.value == slide.maxValue){
				if (doOnce < 1) {
					announce.getAnnouncements ("You cleaned yourself off!");
					doOnce++;
				}
				SinkSlider.SetActive (false);
			}
		}
=======
		if (inRange) {
			if (Input.GetButtonDown ("Jump") && slide.value < slide.maxValue) {
				slide.value += (1/30f);
			}
			if (slide.value >= slide.maxValue) {
				GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
				gameObject.SetActive (false);
			}
		}
		if (slide.value > 0) {
			slide.value -= (1/10f) * Time.deltaTime;
		}
>>>>>>> origin/master
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
<<<<<<< HEAD
			SinkSlider.SetActive (true);
=======
>>>>>>> origin/master
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
<<<<<<< HEAD
			if (slide.value < slide.maxValue) {
				slide.value -= .1F;
			}
			inRange = false;
			SinkSlider.SetActive (false);
=======
			inRange = false;
>>>>>>> origin/master
		}
	}
}
