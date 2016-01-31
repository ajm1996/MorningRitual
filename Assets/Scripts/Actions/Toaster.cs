using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toaster : MonoBehaviour {

	Slider slide;
	bool triggered, entered;

	public GameObject plate, eating;
	private bool pickedUp;

	void Start () {
		slide = GetComponentInChildren<Slider>();
		gameObject.SetActive (false);
		GameObject.Find ("Toaster_Object").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (entered) {
			if (slide.value < slide.maxValue) {
				slide.value += (1/10f) * Time.deltaTime;
			}
		}
		if (triggered) {
			if (slide.value >= slide.maxValue) {
				if (pickedUp) {
					GameObject.Find ("Player").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = true;
					GameObject.Find ("Toaster_Object").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = false;
					eating.SetActive (true);
					plate.SetActive (false);
					gameObject.SetActive (false);
				}
			} 
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			triggered = true;
			entered = true;
			GameObject.Find ("Player").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = false;
			GameObject.Find ("Toaster_Object").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = true;
			plate.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		triggered = false;
	}

	void PickedUp() {
		pickedUp = true;
	}

}
