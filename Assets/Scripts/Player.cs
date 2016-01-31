using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerSpeed = 10;
	public bool paused = true;

	public Sprite groomed, dressed;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			float moveX = Input.GetAxis ("Horizontal");
			float moveY = Input.GetAxis ("Vertical");
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (moveX * playerSpeed, moveY * playerSpeed));

			if (moveX > 0) {
				
				if (moveY > 0) {
					Look (new Vector3(-1, -1, 0));
				} else if (moveY < 0) {
					Look (new Vector3(-1, 1, 0));
				} else {
					Look (Vector3.left);
				}

			} else if (moveX < 0) {
				if (moveY > 0) {
					Look (new Vector3(1, -1, 0));
				} else if (moveY < 0) {
					Look (new Vector3(1, 1, 0));
				} else {
					Look (Vector3.right);
				}
			} else if (moveY > 0) {
				Look (Vector3.down);
			} else if (moveY < 0) {
				Look (Vector3.up);
			}
		}
	}

	void Look (Vector2 v) {
		v = v.normalized;
		float angle = Mathf.Atan2 (v.y, v.x) * Mathf.Rad2Deg;
		// rotate to angle
		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3 (0, 0, angle - 90);
		transform.rotation = rotation;
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
