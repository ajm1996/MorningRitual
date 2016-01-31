using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject countdown;

	void Start () {
		gameObject.SetActive (false);
	}

	void Update () {
		countdown.SetActive (true);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Player").GetComponent<GameState> ().objectiveComplete = true;
		}
	}
}
