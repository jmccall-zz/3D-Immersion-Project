﻿#pragma strict

function Update() {
	if (Input.GetKeyDown(KeyCode.Escape)) {
		Application.LoadLevel("SceneSwitch");
	}
}
