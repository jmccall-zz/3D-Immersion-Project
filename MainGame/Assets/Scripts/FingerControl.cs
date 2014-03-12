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
		adjustJointTilts ("RightHandIndex1", degrees: Models.fingers[0], rightHand: true);
		adjustJointTilts ("RightHandMiddle1", degrees: Models.fingers[1], rightHand: true);
		adjustJointTilts ("RightHandRing1", degrees: Models.fingers[2], rightHand: true);
		adjustJointTilts ("RightHandPinky1", degrees: Models.fingers[3], rightHand: true);
		adjustJointTilts ("LeftHandIndex1", degrees: Models.fingers[4], rightHand: false);
		adjustJointTilts ("LeftHandMiddle1", degrees: Models.fingers[5], rightHand: false);
		adjustJointTilts ("LeftHandRing1", degrees: Models.fingers[6], rightHand: false);
		adjustJointTilts ("LeftHandPinky1", degrees: Models.fingers[7], rightHand: false);

	}
	
	/* 
	 * This function adjust the rotation of the 3 ball joints in the finger. The goal is that
	 * we have a realistic animation of how a hand opens/closes.  No scaling is done here. Degree data
	 * is given and all finger joint positions are determined. It is up to the caller to scale values
	 * appropriately.
	 * 
	 * @param rightHand: The rotation values used to adjust the fingers are opposite for the right
	 * and left hand respectively.
	 */
	void adjustJointTilts (string objectName, float degrees = 0, bool rightHand = true) {
		/* Adjust z-axis euler angle for all finger joints based on the degree value given */ 
		Transform transform = GameObject.Find (objectName).transform;
		
		/********** Adjust base joint ***********/
		if ((degrees <= j1MaxRot) && (degrees > 0)) {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			else
				transform.localEulerAngles = new Vector3 (0, 0, degrees);

		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -j1MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j1MaxRot);
		}
		
		/********** Adjust 2nd joint ************/
		transform = transform.GetChild(0);
		degrees = (j2MaxRot / (j1MaxRot / 2.0F)) * degrees;
		if ((degrees <= j2MaxRot) && (degrees > 0)) {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			else
				transform.localEulerAngles = new Vector3 (0, 0, degrees);
		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -j2MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j2MaxRot);

		}
		
		/*********** Adjust 3rd joint ************/
		transform = transform.GetChild (0);
		degrees = (j3MaxRot / j2MaxRot) * degrees;
		if ((degrees <= j3MaxRot) && (degrees > 0)) {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			else
				transform.localEulerAngles = new Vector3 (0, 0, degrees);
		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			
		} else {
			if (rightHand)
				transform.localEulerAngles = new Vector3 (0, 0, -j3MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j3MaxRot);
		}
		
	}
}