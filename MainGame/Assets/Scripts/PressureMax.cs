using UnityEngine;
using System.Collections;

public class PressureMax : MonoBehaviour {

	GloveReader reader;
	GUIText text;
	float maxGrip;
	float [] sensorValues;

	// Use this for initialization
	void Start () {
		reader = new GloveReader ();
		maxGrip = 0.0f;
		text = new GUIText ();
	}
	
	// Update is called once per frame
	void Update () {
		sensorValues = reader.getValues ();
		if (sensorValues [reader.LH_GripMiddle()] > maxGrip) {
			maxGrip = sensorValues [reader.LH_GripMiddle()];
		}
		Debug.Log (maxGrip);
	}

	void OnGui() {
		text.text = maxGrip.ToString ();
	}
}


