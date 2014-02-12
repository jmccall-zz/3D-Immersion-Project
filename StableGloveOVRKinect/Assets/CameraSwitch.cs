using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	
	public Camera camera1;
	public Camera camera2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			if (camera1.enabled == true) {
				camera1.enabled = false;
				camera2.enabled = true;
			} else {
				camera1.enabled = true;
				camera2.enabled = false;
			}
		}
		
	}
}
