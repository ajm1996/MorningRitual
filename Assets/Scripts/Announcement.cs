using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Announcement : MonoBehaviour {

	Text AnnouncementTxt;
	List<string> Announces = new List<string>();//strings that will be passed to the txtbox
	float timer;// After a second a line from the text box is deleted
	// Use this for initialization
	void Start () {
		AnnouncementTxt = GameObject.Find ("Announcement").GetComponentInChildren<Text>();
		timer = 0;
		AnnouncementTxt.text += "Hello World\n";
	}
	
	// Update is called once per frame
	void Update () {
		if (getAnnouncements ()) {
			AnnouncementTxt.text += (Announces[(Announces.Count-1)]+"\n");//hopefully gets the last thing and announces it
		}
		if (timer >= 5) {
			AnnouncementTxt.text = AnnouncementTxt.text.Remove(0,AnnouncementTxt.text.IndexOf("\n"));//removes all the characters up to the first line
			timer = 0;
		}
		timer+=Time.deltaTime;
	}

	bool getAnnouncements(){
		//hopefully will get announcements that the other objects will send to when this method is checked;
		return false;
	}
}
