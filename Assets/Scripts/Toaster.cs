using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toaster : MonoBehaviour {

	Slider slide;
	GameObject ToasterSlider; 
	Announcement announce;
	int doOnce;
	bool inRange;
	// Use this for initialization
	void Start () {
		doOnce = 0;
		slide = GetComponentInChildren<Slider>();
		ToasterSlider = slide.transform.parent.gameObject;
		announce = GameObject.Find ("Announce text").GetComponentInChildren<Announcement> ();
		inRange = false;
		ToasterSlider.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(inRange){
			if (slide.value < slide.maxValue) {
				slide.value += .005F;
			}
			if(slide.value == slide.maxValue){
				if (doOnce < 1) {
					announce.getAnnouncements ("You cooked a pancake in a toaster!");
					doOnce++;
				}
				ToasterSlider.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
			ToasterSlider.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (slide.value < slide.maxValue) {
				slide.value -= .1F;
			}
			inRange = false;
			ToasterSlider.SetActive (false);
		}
	}
}
