using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movex = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (movex * playerSpeed, moveY * playerSpeed));

	}
}
