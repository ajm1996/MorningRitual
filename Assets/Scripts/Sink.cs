using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sink : MonoBehaviour {

	Slider slide;
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
	}

	// Update is called once per frame
	void Update () {
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
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
			SinkSlider.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (slide.value < slide.maxValue) {
				slide.value -= .1F;
			}
			inRange = false;
			SinkSlider.SetActive (false);
		}
	}
}
