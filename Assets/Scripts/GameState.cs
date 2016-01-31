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
				gameObject.GetComponent<Renderer> ().enabled = false;
				gameObject.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);

				StartCoroutine (Blinking ());
				startedBlink = true;
			}
			if (endedBlink) {
				if (Input.GetButtonDown ("Jump")) {
					GetComponent<AudioSource>().Stop();
					GameObject.Find ("Blinking Canvas").SendMessage ("BlinkOpen");

					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
					GameObject.Find ("Bed").GetComponent<Renderer> ().enabled = false;

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
