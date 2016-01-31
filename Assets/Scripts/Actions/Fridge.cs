using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {

	public GameObject toaster;

	void Start () {
		gameObject.SetActive (false);
		GameObject.Find ("Player").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = false;
	}
		
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Player").transform.FindChild ("Pancakes").GetComponent<Renderer> ().enabled = true;
			toaster.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
