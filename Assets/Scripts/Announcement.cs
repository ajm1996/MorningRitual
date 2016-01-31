using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Announcement : MonoBehaviour {

	Text AnnouncementTxt;
	float timer;// After a second a line from the text box is deleted
	// Use this for initialization
	void Start () {
		AnnouncementTxt = GameObject.Find ("Announcement").GetComponentInChildren<Text>();
		timer = 0;
		AnnouncementTxt.text += "Good Morning\n";
	}
	
	// Update is called once per frame
	void Update () {
		
		if (timer >= 2) {
			AnnouncementTxt.text = AnnouncementTxt.text.Remove(0,AnnouncementTxt.text.IndexOf("\n")+1);//removes all the characters up to the first line
			timer = 0;
		}
		timer+=Time.deltaTime;
	}

	public void getAnnouncements(string s){
		//hopefully will get announcements that the other objects will send to when this method is checked;
		//gets called by another script/scripts
		AnnouncementTxt.text += (s+"\n");
	}
}
