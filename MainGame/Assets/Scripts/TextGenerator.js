#pragma strict

var currentExercise : int;
var exercise: String;
var style : GUIStyle;
var instructions : String;

function Start () {
	currentExercise = 0;
	exercise = "Press Next To Start";
	style = new GUIStyle();
	instructions = " ";
	
}

function Update () {
	switch (currentExercise) {
		case 0: exercise = "Press Next To Start";
				instructions = " ";
			break;
		case 1: exercise = "2";
				instructions = "2";
			break;
		case 2: exercise = "3";
				instructions = "4";
			break;
		case 3: exercise = "4";
				instructions = "4";
			break;
		case 4: exercise = "5";
				instructions = "4";
			break;
		case 5: exercise = "6";
				instructions = "6";
			break;
		default: currentExercise = 0;
				instructions = " "; 
			break;
	}
}

function OnGUI () {
	if (GUI.Button (Rect (Screen.width/2 + 50, Screen.height-50,100,40), "Next")) {
		currentExercise++;
		if (currentExercise > 5) currentExercise = 5;
	}
	if (GUI.Button (Rect (Screen.width/2 - 50, Screen.height-50,100,40), "Prev")) {
		currentExercise--;
		if (currentExercise < 0) currentExercise = 0;
	}
	style.fontSize = 25;
	style.alignment = TextAnchor.LowerCenter;
	GUI.Label (Rect(Screen.width/2, Screen.height-100, 160, 40), exercise, style);
	
	style.fontSize = 60;
	style.alignment = TextAnchor.UpperCenter;
	GUI.Label (Rect(Screen.width/2, 50, 160, 40), exercise, style);
	
}