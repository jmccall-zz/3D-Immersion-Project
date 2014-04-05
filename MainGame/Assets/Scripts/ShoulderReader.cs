using UnityEngine;
using System.Collections;
using System;

public class ShoulderReader : MonoBehaviour {

	private Transform R_shoulder;
	private Transform L_shoulder;
	private ZigJointId active_id;
	private ZigJointId R_shoulder_id;
	private ZigJointId L_shoulder_id;
	private ZigSkeleton skeleton;

	// The localEulerAngles of the shoulder. This array of length three represents
	// x, y, and z rotation angles.
	private Vector3 shoulder_angles;
	private float abduction_angle;

	public bool measure_left = false;

	// Use this for initialization
	void Start () {
		// Initialize ZigSkeleton
		skeleton = new ZigSkeleton ();

		shoulder_angles = new Vector3();

		// Get zig joint identification numbers for each shoulder
		R_shoulder_id = ZigJointId.RightShoulder;
		L_shoulder_id = ZigJointId.LeftShoulder;

	}
	
	// Update is called once per frame
	void Update () {
		// Determine which shoulder we will be sampling
		if (measure_left)
			active_id = L_shoulder_id;
		else
			active_id = R_shoulder_id;

		shoulder_angles = skeleton.GetJointEulerAngles (active_id);
		abduction_angle = GetAbductionAngle (shoulder_angles);

		Debug.Log ("Measured Abduction Angle: " + abduction_angle);


	}

	/* Retrieve measured abduction angle given all shoulder rotation angles.  The normal range for
	 a vertical shoulder abduction measurement is 0 degrees to 180 degrees.  0 meaning arm lowered
	 parallel to spine.  180 meaning arm raised parallel to spine. */
	private float GetAbductionAngle(Vector3 angles) {
		float angle = Math.Abs (angles.z - 90.0f);
		return angle;
	}
}
