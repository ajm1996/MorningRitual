using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pressbar : MonoBehaviour {

	GameObject AlarmSlider; 
	Slider slide;
	Vector3 playerLoc;//player has to be near the object in order to increase the slider
	Vector3 alarmLoc;
	public BoxCollider2D alarmCol;
	bool inRange;
	bool pastState;
	Announcement announce;
	int doOnce;

	// Use this for initialization
	void Start () {
		slide = GetComponentInChildren<Slider>();
		AlarmSlider = slide.transform.parent.gameObject;
		alarmCol = GetComponentInChildren<BoxCollider2D> ();
//		playerLoc = GameObject.Find ("Player").GetComponentInChildren<Transform> ().position;
//		alarmLoc = transform.position;
		announce = GameObject.Find ("Announce text").GetComponentInChildren<Announcement> ();
		doOnce = 0;
		slide.value = 0;
		inRange = false;
		pastState = false;
		AlarmSlider.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
//		playerLoc = GameObject.Find ("Player").GetComponentInChildren<Transform> ().position;
//		alarmLoc = transform.position;
		if (inRange) {
			if (slide.value < slide.maxValue) {
				//checks if the button is 
				if (Input.GetKeyUp (KeyCode.J) && pastState) {
					slide.value += .20F;
					pastState = false;
				}
				pastState = Input.GetKey (KeyCode.J);



			} 
			if(slide.value == slide.maxValue){
				if (doOnce < 1) {
					announce.getAnnouncements ("!Alarm Is turned off!");
					doOnce++;
				}
				AlarmSlider.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = true;
			AlarmSlider.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inRange = false;
			AlarmSlider.SetActive (false);
		}
	}
}
