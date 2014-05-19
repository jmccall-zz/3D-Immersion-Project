using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;

public class FingerControl : MonoBehaviour {
	
	// Max Rotations for each joint in a given finger
	private float j1MaxRot = 90.0F;
	private float j2MaxRot = 110.0F;
	private float j3MaxRot = 50.0F;

	private const bool LEFT = false;
	private const bool RIGHT = true;

	void Start () {
		
		
	}
	
	void Update () {
		adjustJointTilts ("RightHandIndex1", degrees: Models.fingers[0], knuckle: Models.fingers[4], hand: RIGHT);
		adjustJointTilts ("RightHandMiddle1", degrees: Models.fingers[1], knuckle: Models.fingers[4], hand: RIGHT);
		adjustJointTilts ("RightHandRing1", degrees: Models.fingers[2], knuckle: Models.fingers[4], hand: RIGHT);
		adjustJointTilts ("RightHandPinky1", degrees: Models.fingers[3], knuckle: Models.fingers[4], hand: RIGHT);
		adjustJointTilts ("LeftHandIndex1", degrees: Models.fingers[4], knuckle: Models.fingers[9], hand: LEFT);
		adjustJointTilts ("LeftHandMiddle1", degrees: Models.fingers[5], knuckle: Models.fingers[9], hand: LEFT);
		adjustJointTilts ("LeftHandRing1", degrees: Models.fingers[6], knuckle: Models.fingers[9], hand: LEFT);
		adjustJointTilts ("LeftHandPinky1", degrees: Models.fingers[7], knuckle: Models.fingers[9], hand: LEFT);

	}
	
	/* 
	 * This function adjust the rotation of the 3 ball joints in the finger. The goal is that
	 * we have a realistic animation of how a hand opens/closes.  No scaling is done here. Degree data
	 * is given and all finger joint positions are determined. It is up to the caller to scale values
	 * appropriately.
	 * 
	 * @param hand: The rotation values used to adjust the fingers are opposite for the right
	 * and left hand respectively.
	 */
	void adjustJointTilts (string objectName, float degrees = 0, float knuckle = 0, bool hand = RIGHT) {
		/* Adjust z-axis euler angle for all finger joints based on the degree value given */ 
		Transform transform = GameObject.Find (objectName).transform;
		
		/********** Adjust base joint ***********/
		if ((degrees <= j1MaxRot) && (degrees > 0)) {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -knuckle);
			else
				transform.localEulerAngles = new Vector3 (0, 0, knuckle);

		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -j1MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j1MaxRot);
		}
		
		/********** Adjust 2nd joint ************/
		transform = transform.GetChild(0);
		degrees = (j2MaxRot / (j1MaxRot / 2.0F)) * degrees;
		if ((degrees <= j2MaxRot) && (degrees > 0)) {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			else
				transform.localEulerAngles = new Vector3 (0, 0, degrees);
		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -j2MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j2MaxRot);

		}
		
		/*********** Adjust 3rd joint ************/
		transform = transform.GetChild (0);
		degrees = (j3MaxRot / j2MaxRot) * degrees;
		if ((degrees <= j3MaxRot) && (degrees > 0)) {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			else
				transform.localEulerAngles = new Vector3 (0, 0, degrees);
		} else if (degrees <= 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			
		} else {
			if (hand == RIGHT)
				transform.localEulerAngles = new Vector3 (0, 0, -j3MaxRot);
			else
				transform.localEulerAngles = new Vector3 (0, 0, j3MaxRot);
		}
		
	}
}