using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Eating : MonoBehaviour {

	Slider slide;

	void Start () {
		slide = GetComponentInChildren<Slider>();
		gameObject.transform.parent.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		print (GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity.magnitude);
		if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 1) {
			if (slide.value < slide.maxValue) {
				slide.value += (1/10f) * Time.deltaTime;
			}
			if (slide.value >= slide.maxValue) {
				GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
				GameObject.Find ("Player").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = false;
				GameObject.Find ("Player").transform.FindChild ("Plate").GetComponent<Renderer> ().enabled = false;
				gameObject.SetActive (false);
			} 
		} else {
			slide.value -= (1/10f) * Time.deltaTime;
		}
	}

}
