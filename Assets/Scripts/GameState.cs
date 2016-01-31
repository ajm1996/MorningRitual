using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

	enum State{dayOne, dayTwo, dayThree, dayFour, shower, brushing, dressing, breakfeast, leave};
	State gameState;
	GameObject announce;

	public GameObject shower, sink, dresser, fridge, door;

	bool started = false, ended = false;
	public bool objectiveComplete = false;

	void Start () {
		gameState = State.dayOne;
		GameObject.Find ("Day Announcement").GetComponent<Canvas> ().enabled = false;

		announce = GameObject.Find ("Objective Announcement");
		announce.GetComponent<Canvas> ().enabled = false;
	}

	void Update () {
		if (gameState == State.dayOne) {
			if (!started) {
				gameObject.GetComponent<Renderer> ().enabled = false;
				gameObject.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);

				StartCoroutine (Blinking ());
				started = true;
			}
			if (ended) {
				if (Input.GetButtonDown ("Jump")) {
					GetComponent<AudioSource>().Stop();
					GameObject.Find ("Blinking Canvas").SendMessage ("BlinkOpen");
					GameObject.Find ("Day Announcement").GetComponent<Canvas> ().enabled = false;

					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
					GameObject.Find ("Bed").GetComponent<Renderer> ().enabled = false;

					gameState = State.breakfeast;
					started = false;
					ended = false;
				}
			}
		}

		if (gameState == State.shower) {
			if (!started) {
				announce.GetComponent<Canvas> ().enabled = true;
				announce.GetComponentInChildren<Text> ().text = "Good morning!\nStart your morning off with a shower.";
				shower.SetActive (true);

				StartCoroutine (HideObjective ());
				started = true;
			}

			if (objectiveComplete) {
				gameState = State.brushing;
				started = false;
				objectiveComplete = false;
			}
		}

		if (gameState == State.brushing) {
			if (!started) {
				announce.GetComponent<Canvas> ().enabled = true;
				announce.GetComponentInChildren<Text> ().text = "Well done!\nGo comb your hair and brush your teeth.";
				sink.SetActive (true);

				StartCoroutine (HideObjective ());
				started = true;
			}

			if (objectiveComplete) {
				gameState = State.dressing;
				started = false;
				objectiveComplete = false;
			}
		}

		if (gameState == State.dressing) {
			if (!started) {
				announce.GetComponent<Canvas> ().enabled = true;
				announce.GetComponentInChildren<Text> ().text = "Lookin' good!\nLet's go get dressed.";
				dresser.SetActive (true);

				StartCoroutine (HideObjective ());
				started = true;
			}

			if (objectiveComplete) {
				gameState = State.breakfeast;
				started = false;
				objectiveComplete = false;
			}
		}

		if (gameState == State.breakfeast) {
			if (!started) {
				announce.GetComponent<Canvas> ().enabled = true;
				announce.GetComponentInChildren<Text> ().text = "Nice!\nLet's make something to eat!";
				fridge.SetActive (true);

				StartCoroutine (HideObjective ());
				started = true;
			}

			if (objectiveComplete) {
				gameState = State.leave;
				started = false;
				objectiveComplete = false;
			}
		}

		if (gameState == State.leave) {
			if (!started) {
				announce.GetComponent<Canvas> ().enabled = true;
				announce.GetComponentInChildren<Text> ().text = "Delicious!\nWe're running late though, leave for work!";
				door.SetActive (true);

				StartCoroutine (HideObjective ());
				started = true;
			}

			if (objectiveComplete) {
				gameState = State.leave;
				started = false;
				objectiveComplete = false;
			}
		}

	}

	IEnumerator Blinking() {
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds (1);
		GameObject.Find ("Blinking Canvas").SendMessage ("BlinkOpen");
		yield return new WaitForSeconds (1);
		GameObject.Find ("Blinking Canvas").SendMessage ("BlinkClosed");
		yield return new WaitForSeconds (1);
		GameObject.Find ("Day Announcement").GetComponent<Canvas>().enabled = true;
		yield return new WaitForSeconds (0.5f);
		ended = true;
		yield break;
	}

	IEnumerator HideObjective () {
		yield return new WaitForSeconds (5);
		announce.GetComponent<Canvas> ().enabled = false;
		yield break;
	}
}
