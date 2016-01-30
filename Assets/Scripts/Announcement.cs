using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Announcement : MonoBehaviour {

	Text AnnouncementTxt;
	// Use this for initialization
	void Start () {
		AnnouncementTxt = GameObject.Find ("Announcement").GetComponentInChildren<Text>();

		AnnouncementTxt.text = "Hello World";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
