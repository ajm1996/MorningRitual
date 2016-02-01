using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

	private Canvas winMenu;
	public Canvas confirmation;

	private int butPressed = -1;

	void Start () {
		winMenu = gameObject.GetComponent<Canvas> ();
		confirmation = confirmation.GetComponent<Canvas> ();

		winMenu.enabled = false;
		confirmation.enabled = false;

	}
	
	public void RestartPress() {
		if (Application.loadedLevelName == "MainHouse") {
			SceneManager.LoadScene ("MainHouse");
		} else if (Application.loadedLevelName == "SwatHouse") {
			SceneManager.LoadScene ("SwatHouse");
		} else if (Application.loadedLevelName == "ZombieHouse") {
			SceneManager.LoadScene ("ZombieHouse");
		}
	}

	public void MainMenuPress() {
		confirmation.enabled = true;
		winMenu.enabled = false;
		butPressed = 1;
	}

	public void QuitPress() {
		confirmation.enabled = true;
		winMenu.enabled = false;
		butPressed = 2;
	}

	public void YesPressed() {
		if (butPressed == 1) {
			SceneManager.LoadScene ("MainMenu");
		} else if (butPressed == 2) {
			Application.Quit();
		}
	}

	public void NoPressed() {
		butPressed = -1;
		confirmation.enabled = false;
		winMenu.enabled = true;
	}
}
