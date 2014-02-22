using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;

public class FingerControl : MonoBehaviour {
	
	// Max Rotations for joints
	private float j1MaxRot = 90.0F;
	private float j2MaxRot = 110.0F;
	private float j3MaxRot = 50.0F;
	
	void Start () {
		
		
	}
	
	void Update () {
		
		// Adjust all joints for each finger
		if (ZigSkeleton.mirror == true) {
			adjustJointTilts ("LeftHandIndex1", degrees: Models.fingers[0]);
			adjustJointTilts ("LeftHandMiddle1", degrees: Models.fingers[1]);
			adjustJointTilts ("LeftHandRing1", degrees: Models.fingers[2]);
			adjustJointTilts ("LeftHandPinky1", degrees: Models.fingers[3]);
		} else {
			/*adjustJointTilts ("RightHandIndex1", degrees: 90);
			adjustJointTilts ("RightHandMiddle1", degrees: 66);
			adjustJointTilts ("RightHandRing1", degrees: 44);
			adjustJointTilts ("RightHandPinky1", degrees: 22);*/
			adjustJointTilts ("RightHandIndex1", degrees: Models.fingers[0]);
			adjustJointTilts ("RightHandMiddle1", degrees: Models.fingers[1]);
			adjustJointTilts ("RightHandRing1", degrees: Models.fingers[2]);
			adjustJointTilts ("RightHandPinky1", degrees: Models.fingers[3]);
		}
	}
	
	
	void adjustJointTilts (string objectName, float degrees = 0) {
		/* Adjust z-axis euler angle for all finger joints based on the degree value given */ 
		Transform transform = GameObject.Find (objectName).transform;
		
		/********** Adjust base joint ***********/
		if ((degrees <= j1MaxRot) && (degrees > 0)) {
			transform.localEulerAngles = new Vector3 (0, 0, -degrees);
		} else if (degrees < 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			transform.localEulerAngles = new Vector3 (0, 0, -j1MaxRot);
			//Debug.LogWarning("Joint1 Degrees too large: " + degrees.ToString());
		}
		
		/********** Adjust 2nd joint ************/
		transform = transform.GetChild(0);
		degrees = (j2MaxRot / (j1MaxRot / 2.0F)) * degrees;
		if ((degrees <= j2MaxRot) && (degrees > 0)) {
			transform.localEulerAngles = new Vector3 (0, 0, -degrees);
		} else if (degrees < 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			transform.localEulerAngles = new Vector3 (0, 0, -j2MaxRot);
			//Debug.LogWarning("Joint2 Degrees too large: " + degrees.ToString());
		}
		
		/*********** Adjust 3rd joint ************/
		transform = transform.GetChild (0);
		degrees = (j3MaxRot / j2MaxRot) * degrees;
		if ((degrees <= j3MaxRot) && (degrees > 0)) {
			transform.localEulerAngles = new Vector3 (0, 0, -degrees);
		} else if (degrees < 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			
		} else {
			transform.localEulerAngles = new Vector3 (0, 0, -j3MaxRot);
			//Debug.LogWarning("Joint3 Degrees too large: " + degrees.ToString());
		}
		
	}
}