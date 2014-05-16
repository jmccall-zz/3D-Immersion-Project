#pragma strict

var textFieldString = "Name";
var MenuState = false;


function Update() {
	if (Input.GetKeyDown(KeyCode.Escape)) {
		Application.LoadLevel("SceneSwitch");
	}
}
