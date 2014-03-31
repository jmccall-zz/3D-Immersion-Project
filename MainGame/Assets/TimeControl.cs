using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	// Scene will end when timer reaches timeout value
	public float TIMEOUT = 50.0f;

	private float timer = 0.0f;
	private bool scene_completed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		//Debug.Log ("Scene Duration: " + duration);

		if (timer >= TIMEOUT) {
			// Time has expired. Quit scene and store results
			//Application.LoadLevel()
		}
	}
}
