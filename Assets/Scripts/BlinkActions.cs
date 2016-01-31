using UnityEngine;
using System.Collections;

public class BlinkActions : MonoBehaviour {

	public GameObject upperLid, lowerLid;
	bool blinkOpen, blinkClosed;

	void Start () {
		
	}

	void Update () {
		if (blinkOpen) {
			if (upperLid.transform.localScale.y - (1 * Time.deltaTime) > 0) {
				upperLid.transform.localScale -= new Vector3 (0, 0.5f * Time.deltaTime, 0);
				lowerLid.transform.localScale -= new Vector3 (0, 0.5f * Time.deltaTime, 0);

			} else {
				blinkOpen = false;
				upperLid.transform.localScale = new Vector3 (1, 0, 1);
				lowerLid.transform.localScale = new Vector3 (1, 0, 1);
			}
		}
		if (blinkClosed) {
			if (upperLid.transform.localScale.y + (1 * Time.deltaTime) < 0.5f) {
				
				upperLid.transform.localScale += new Vector3 (0, 0.5f * Time.deltaTime, 0);
				lowerLid.transform.localScale += new Vector3 (0, 0.5f * Time.deltaTime, 0);

			} else {
				blinkClosed = false;
				upperLid.transform.localScale = new Vector3 (1, 0.5f, 1);
				lowerLid.transform.localScale = new Vector3 (1, 0.5f, 1);
			}
		}
	}

	void BlinkOpen () {
		blinkOpen = true;
	}

	void BlinkClosed () {
		blinkClosed = true;
	}
}
