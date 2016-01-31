using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public GameObject fireSpawn;
	float time;
	float endtime;
	float totaltime;
	int numOfSpawns;
	// Use this for initialization
	void Start () {
		time = 0;
		endtime = Random.Range (20, 30);
	}
	
	// Update is called once per frame
	void Update () {
		if(time >= endtime){
			
			numOfSpawns = Random.Range (1, 5);
			for (int i = 0; i < numOfSpawns; i++) {
				fireSpawn = (GameObject)Instantiate (fireSpawn, transform.position, new Quaternion (0, 0, 0, 0));
				//fireSpawn.transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
				fireSpawn.GetComponentInChildren<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-80, 80), Random.Range (-80, 80)));
			}
			endtime = Random.Range (20, 30);
			time = 0;
		}

		time += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			GameObject.Find("Game Over Menu").SendMessage ("Kill");
			Destroy (gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Boundary") {
			Destroy (this);
		}
	}
}
