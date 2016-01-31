using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {

	void Update () {
		if (!GameObject.Find ("Player").GetComponent<Player> ().paused) {
			transform.position = new Vector3 (GameObject.Find ("Player").transform.position.x, GameObject.Find ("Player").transform.position.y, -0.1f);
		}
	}
}
