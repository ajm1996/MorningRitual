using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	private Canvas gameOverMenu;
	public Canvas confirmation;

	private int butPressed = -1;

	void Start () {
		gameOverMenu = gameObject.GetComponent<Canvas> ();
		confirmation = confirmation.GetComponent<Canvas> ();

		gameOverMenu.enabled = false;
		confirmation.enabled = false;

	}

	public void Kill () {
		gameOverMenu.enabled = true;
			
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public void RestartPress() {
		EditorSceneManager.LoadScene ("MainHouse");
	}

	public void MainMenuPress() {
		confirmation.enabled = true;
		gameOverMenu.enabled = false;
		butPressed = 1;
	}

	public void QuitPress() {
		confirmation.enabled = true;
		gameOverMenu.enabled = false;
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
		gameOverMenu.enabled = true;
	}
}
