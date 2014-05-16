using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width/2 - 75, 10, 150, 25), "Load Login Scene")) {
			Application.LoadLevel("Login");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 40, 150, 25), "Load Calibrate")) {
			Application.LoadLevel("CalibrateGlove");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 70 , 150, 25), "Load Ball Game")) {
			Application.LoadLevel("FirstScene");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 100 , 150, 25), "Load Reach Test")) {
			Application.LoadLevel("ReachBack");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 130 , 150, 25), "Load Grip Test")) {
			Application.LoadLevel("GripStrength");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 160, 150, 25), "ShoulderROM Test")) {
			Application.LoadLevel("ShoulderROM");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 75, 190, 150, 25), "Exit")) {
			Application.Quit();
		}
	}
}
