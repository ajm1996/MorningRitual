using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private Canvas pauseMenu;
	public Canvas confirmation;

	private int butPressed = -1;

	private bool isPaused = false;

	void Start () {
		pauseMenu = gameObject.GetComponent<Canvas> ();
		confirmation = confirmation.GetComponent<Canvas> ();

		pauseMenu.enabled = false;
		confirmation.enabled = false;

	}

	public void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			isPaused = !isPaused;
			pauseMenu.enabled = isPaused;
			if (isPaused) {
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
			} else {
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
	
	public void ResumePress() {
		pauseMenu.enabled = false;
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
		}

	}

	public void MainMenuPress() {
		confirmation.enabled = true;
		pauseMenu.enabled = false;
		butPressed = 1;
	}

	public void QuitPress() {
		confirmation.enabled = true;
		pauseMenu.enabled = false;
		butPressed = 2;
	}

	public void YesPressed() {
		if (butPressed == 1) {
			EditorSceneManager.LoadScene ("MainMenu");
		} else if (butPressed == 2) {
			Application.Quit();
		}
	}

	public void NoPressed() {
		butPressed = -1;
		confirmation.enabled = false;
		pauseMenu.enabled = true;
	}
}
