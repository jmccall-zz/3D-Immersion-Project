using UnityEngine;
using System.Collections;

public class CylinderCatch : MonoBehaviour {

	public int catchCount;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		catchCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (catchCount);


		if (catchCount < 3) {
			timer += Time.deltaTime;
		} else {
			Debug.Log(timer);
			// Write to database here
		}
	}

	public void Caught() {
		catchCount++;
	}
}
