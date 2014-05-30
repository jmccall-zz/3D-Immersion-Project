using UnityEngine;
using System.Collections;

public class TextGen : MonoBehaviour {
	int currentExercise;
	string exercise;
	GUIStyle style;
	string instructions;
	bool inPosition;


	float timer;
	// Use this for initialization
	void Start () {
		currentExercise = 0;
		exercise = "Press Next To Start";
		style = new GUIStyle();
		instructions = " ";
		timer = 0;
		inPosition = true;
	}
	
	// Update is called once per frame
	void Update () {
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
			instructions = "5";
			break;
		case 5: exercise = "6";
			instructions = "6";
			break;
		default: currentExercise = 0;
			instructions = " "; 
			break;
		}

		timer += Time.deltaTime;

	}


	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width/2 + 50, Screen.height-50,100,40), "Next")) {
			currentExercise++;
			if (currentExercise > 5) {
				currentExercise = 5;
			} else {
				timer = 0;
			}
		}
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height-50,100,40), "Prev")) {
			currentExercise--;
			if (currentExercise < 0) {
				currentExercise = 0;
			} else {
				timer = 0;
			}
		}
		style.fontSize = 25;
		style.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect(Screen.width/2, Screen.height-100, 160, 40), exercise, style);

		style.alignment = TextAnchor.UpperCenter;
		if (currentExercise == 3) {
			GUI.Label (new Rect (Screen.width / 2, 200, 160, 40), timer.ToString ().Remove (4), style);	
		}

		style.fontSize = 60;

		GUI.Label (new Rect(Screen.width/2, 50, 160, 40), exercise, style);	

	}
}
