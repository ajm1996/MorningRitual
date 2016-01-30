using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pressbar : MonoBehaviour {

	public GameObject AlarmSlider; 
	public Slider slide;
	public Vector3 playerLoc;//player has to be near the object in order to increase the slider
	public Vector3 alarmLoc;
	public BoxCollider2D alarmCol;
	bool inRange;
	// Use this for initialization
	void Start () {
		slide = GetComponentInChildren<Slider>();
		AlarmSlider = slide.transform.parent.gameObject;
		alarmCol = GetComponentInChildren<BoxCollider2D> ();
		playerLoc = GameObject.Find ("Player").GetComponentInChildren<Transform> ().position;
		alarmLoc = transform.position;
		slide.value = 0;
		inRange = false;
		AlarmSlider.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		playerLoc = GameObject.Find ("Player").GetComponentInChildren<Transform> ().position;
		alarmLoc = transform.position;
		if (inRange) {
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			inRange = true;
			AlarmSlider.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			inRange = false;
			AlarmSlider.SetActive(false);
		}
	}
}
