using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {

	void Start () {
		gameObject.SetActive (false);
		GameObject.Find("Player").transform.FindChild("Plate").GetComponent<Renderer> ().enabled = false;
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Player").transform.FindChild ("Plate").GetComponent<Renderer> ().enabled = true;
			GameObject.Find ("Toaster").SendMessage ("PickedUp");
			gameObject.SetActive (false);
		}
	}
}
