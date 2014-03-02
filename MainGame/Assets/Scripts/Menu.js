#pragma strict

var textFieldString = "Name";

function OnGUI() {
	textFieldString = GUI.TextField (Rect (Screen.width/2 - 50, Screen.height/2 - 15, 100, 30), textFieldString);
	if (GUI.Button (Rect (Screen.width/2 - 75, Screen.height/2 + 20, 150, 20), "Login")) {
		
	}
}