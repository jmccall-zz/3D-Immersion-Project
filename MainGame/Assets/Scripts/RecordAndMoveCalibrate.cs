using UnityEngine;
using System.Collections;

public class RecordAndMoveCalibrate : MonoBehaviour {

	private bool moving = false;
	private static float amount;
	GloveReader reader;
	private float[] calibrationDataPoints = new float[28];
	private int transitionCount = 0;
	// Which fingers are represented by lines in the text file
	private int indexFingerIndex = 1;
	private int middleFingerIndex = 2;
	private int ringFingerIndex = 3;
	private int pinkyFingerIndex = 0;

	// Use this for initialization
	void Start () {
		moving = false;
		reader = new GloveReader ();
		amount = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (PlayerPrefs.GetInt ("ActiveUser").ToString ());
		Vector3 position = transform.position;
		//if (transitionCount > 6){
		//}
		if(Input.GetKeyDown("space") && position.x % 20 == 0) {
			Record();
			transitionCount++;
			moving = true;
		}
		if (moving) {
			position.x = position.x + amount;
			if (position.x % 20 == 0) moving = false;
		}
		transform.position = position;
	}

	void Record() {
		//float [] values = reader.getValues();
		float[] values = {10, 20, 30, 40};
		//Debug.Log (values[0]);
		if (transitionCount == 0) {
			calibrationDataPoints[0] = values[indexFingerIndex];
			calibrationDataPoints[7] = values[middleFingerIndex];
			calibrationDataPoints[14] = values[ringFingerIndex];
			calibrationDataPoints[21] = values[pinkyFingerIndex];
		} else if (transitionCount == 1) {
			calibrationDataPoints[1] = values[indexFingerIndex];
			calibrationDataPoints[8] = values[middleFingerIndex];
			calibrationDataPoints[15] = values[ringFingerIndex];
			calibrationDataPoints[22] = values[pinkyFingerIndex];
		} else if (transitionCount == 2) {
			calibrationDataPoints[2] = values[indexFingerIndex];
			calibrationDataPoints[9] = values[middleFingerIndex];
			calibrationDataPoints[16] = values[ringFingerIndex];
			calibrationDataPoints[23] = values[pinkyFingerIndex];
		} else if (transitionCount == 3) {
			calibrationDataPoints[3] = values[indexFingerIndex];
			calibrationDataPoints[10] = values[middleFingerIndex];
			calibrationDataPoints[17] = values[ringFingerIndex];
			calibrationDataPoints[24] = values[pinkyFingerIndex];
		} else if (transitionCount == 4) {
			calibrationDataPoints[4] = values[indexFingerIndex];
			calibrationDataPoints[11] = values[middleFingerIndex];
			calibrationDataPoints[18] = values[ringFingerIndex];
			calibrationDataPoints[25] = values[pinkyFingerIndex];
		} else if (transitionCount == 5) {
			calibrationDataPoints[5] = values[indexFingerIndex];
			calibrationDataPoints[12] = values[middleFingerIndex];
			calibrationDataPoints[19] = values[ringFingerIndex];
			calibrationDataPoints[26] = values[pinkyFingerIndex];
		} else if (transitionCount == 6) {
			calibrationDataPoints[6] = values[indexFingerIndex];
			calibrationDataPoints[13] = values[middleFingerIndex];
			calibrationDataPoints[20] = values[ringFingerIndex];
			calibrationDataPoints[27] = values[pinkyFingerIndex];
		} else {
			Debug.Log("End of scene. No more data to capture.");
		}
		// Increment number of transitions
	}

}
