using UnityEngine;
using System.Collections;

public class CylinderCatch : MonoBehaviour {

	public int catchCount;

	// Use this for initialization
	void Start () {
		catchCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (catchCount);
	}

	public void Caught() {
		catchCount++;
	}
}
