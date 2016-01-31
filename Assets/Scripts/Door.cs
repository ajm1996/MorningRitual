using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour {

	//Slider slide;

	void Start () {
		//slide = GetComponentInChildren<Slider>();
		gameObject.SetActive (false);
		//inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
//		if (inRange) {
//		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
//			inRange = false;
		}
	}
}
