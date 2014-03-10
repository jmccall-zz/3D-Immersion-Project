#pragma strict

var textFieldString = "Name";
var MenuState = false;


function Update() {
	if (Input.GetKeyDown(KeyCode.Escape)) {
		MenuState = !MenuState;
		if (MenuState) 
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}

function OnGUI() {
	if (MenuState) {
		//textFieldString = GUI.TextField (Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), textFieldString);
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 - 60, 150, 20), "Resume")) {
			MenuState = !MenuState;
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 - 30, 150, 20), "Load Login Scene")) {
			Application.LoadLevel("Login");
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2, 150, 20), "Load Calibrate")) {
			Application.LoadLevel("CalibrateGlove");
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 + 30 , 150, 20), "Load Ball Game")) {
			Application.LoadLevel("FirstScene");
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 + 60 , 150, 20), "Load Reach Test")) {
			Application.LoadLevel("ReachBack");
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 + 90 , 150, 20), "Load Grip Test")) {
			Application.LoadLevel("GripStrength");
		}
		if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 + 120, 150, 20), "Exit")) {
			Application.Quit();
		}
	}
}