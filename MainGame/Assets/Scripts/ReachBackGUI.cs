using UnityEngine;
using System.Collections;

public class ReachBackGUI : MonoBehaviour { 
	OVRGUI GUIControl;
	string theString;
	// Use this for initialization
	void Start () {
		GUIControl = new OVRGUI();
		OVRCameraController  camCont = GetComponent<OVRCameraController>();
		GUIControl.SetCameraController (ref(camCont));
		theString = "TEXT";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUIControl.StereoBox (Screen.width / 2, Screen.height / 2, 20, 20, ref(theString), Color.red);

	}
}
