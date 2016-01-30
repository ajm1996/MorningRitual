using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerSpeed = 10;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			float movex = Input.GetAxis ("Horizontal");
			float moveY = Input.GetAxis ("Vertical");
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (movex * playerSpeed, moveY * playerSpeed));
		}
	}

	void Kill() {
		//TODO
	}

	void OnPauseGame () {
		paused = true;
	}

	void OnResumeGame () {
		paused = false;
	}
}
