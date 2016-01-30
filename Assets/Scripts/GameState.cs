using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	enum State{dayOne, dayTwo};
	State gameState;

	bool startedBlink = false, endedBlink = false;

	void Start () {
		gameState = State.dayOne;
	}

	void Update () {
		if (gameState == State.dayOne) {
			if (!startedBlink) {
				StartCoroutine (Blinking ());
				startedBlink = true;
			}
			if (endedBlink) {
				print ("endedBlink");
				if (Input.GetButtonDown ("Jump")) {
					GetComponent<AudioSource>().Stop();
					GameObject.Find ("Blinking Canvas").SendMessage ("BlinkOpen");
					gameState = State.dayTwo;
				}
			}
		}
	}

	IEnumerator Blinking() {
		yield return new WaitForSeconds (1);
		GetComponent<AudioSource>().Play();
		GameObject.Find ("Blinking Canvas").SendMessage ("BlinkOpen");
		yield return new WaitForSeconds (1);
		GameObject.Find ("Blinking Canvas").SendMessage ("BlinkClosed");
		endedBlink = true;
		yield break;
	}
}
