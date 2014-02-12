using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
	
	public int loadedLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			// Check which scene we are in
			loadedLevel = Application.loadedLevel;
			Debug.Log ("Loaded level: " + loadedLevel.ToString ());
		}
	}
}
