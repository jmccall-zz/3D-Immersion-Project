using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {

	private float time_count = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Update our time count
		time_count += Time.deltaTime;
		Debug.Log ("Timer: " + time_count);
	}
}
