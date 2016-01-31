using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float timer = 0;

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 6) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			GameObject.Find("Game Over Menu").SendMessage ("Kill");
			Destroy (gameObject);
		}
	}
}
