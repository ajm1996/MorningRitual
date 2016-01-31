using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Closet : MonoBehaviour {

	Slider slide;
	GameObject ClosetSlider; 
	Announcement announce;
	int doOnce;
	bool inRange;
	// Use this for initialization
	void Start () {
		doOnce = 0;
		slide = GetComponentInChildren<Slider>();
		ClosetSlider = slide.transform.parent.gameObject;
		announce = GameObject.Find ("Announce text").GetComponentInChildren<Announcement> ();
		inRange = false;
		ClosetSlider.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(inRange){
			if (slide.value < slide.maxValue) {
				slide.value += .005F;
			}
			if(slide.value == slide.maxValue){
				if (doOnce < 1) {
					announce.getAnnouncements ("You put on your clothes");
					doOnce++;
				}
				ClosetSlider.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
			ClosetSlider.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = false;
			ClosetSlider.SetActive (false);
		}
	}
}
