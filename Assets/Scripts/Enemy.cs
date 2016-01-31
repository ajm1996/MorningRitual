using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool zombie, swat, demon;
	public float moveSpeed;

	private bool moving, paused;
	private float moveX, moveY;
	private Vector3 target;

	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		moving = false;
	}

	void Update () {
		if (!paused) {
			if (moving) {
				if (Vector2.Distance (target, transform.position) > 0.1f) {
					Vector3 normTar = (target - transform.position).normalized;
					float angle = Mathf.Atan2 (normTar.y, normTar.x) * Mathf.Rad2Deg;
					// rotate to angle
					Quaternion rotation = new Quaternion ();
					rotation.eulerAngles = new Vector3 (0, 0, angle - 90);
					transform.rotation = rotation;
					gameObject.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.down * moveSpeed, ForceMode2D.Force);
				} else {
					moving = false;
				}
			} else {
				moveX = 0;
				moveY = 0;

				if (Random.value > 0.5f)
					moveX = Random.Range (-100.0F, 100.0F);
				else
					moveY = Random.Range (-100.0F, 100.0F);

				target = new Vector2 (transform.position.x + moveX, transform.position.y + moveY);
				moving = true;
			}
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		moving = false;
	}


	void OnTriggerEnter2D(Collider2D col) {
		if (zombie) {
			if (col.tag == "Player") {
				GameObject.Find("Game Over Menu").SendMessage ("Kill");
			}
		}

	}

	void OnPauseGame () {
		paused = true;
	}

	void OnResumeGame () {
		paused = false;
	}
}
