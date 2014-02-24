using UnityEngine;
using System.Collections;

public class RecordAndMoveCalibrate : MonoBehaviour {

	private bool moving = false;
	private static float amount;
	GloveReader reader;


	// Use this for initialization
	void Start () {
		moving = false;
		reader = new GloveReader ();
		amount = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		if(Input.GetKeyDown("space") && position.x % 20 == 0) {
			Record();
			moving = true;
		}
		if (moving) {
			position.x = position.x + amount;
			if (position.x % 20 == 0) moving = false;
		}
		transform.position = position;
	}

	void Record() {
		float [] values = reader.getValues();
		//Debug.Log (values[0]);
	}

}
