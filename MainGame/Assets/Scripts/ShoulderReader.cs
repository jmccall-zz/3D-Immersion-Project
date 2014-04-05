using UnityEngine;
using System.Collections;

public class ShoulderReader : MonoBehaviour {

	private float abduction_angle;
	private Transform R_shoulder;
	private Transform L_shoulder;
	private ZigJointId R_shoulder_id;
	private ZigJointId L_shoulder_id;
	private ZigSkeleton skeleton;

	public bool measure_left = false;

	// Use this for initialization
	void Start () {
		// Initialize ZigSkeleton
		skeleton = new ZigSkeleton ();

		// Get zig joint identification numbers for each shoulder
		R_shoulder_id = ZigJointId.RightShoulder;
		L_shoulder_id = ZigJointId.LeftShoulder;
		Debug.Log ("HIIIIIIII");
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShoulderTransforms ();
		Debug.Log ("Right Shoulder Rotation Z: " + R_shoulder.localEulerAngles.z);

	}

	/* Grab shoulder transforms from ZigSkeleton */
	void UpdateShoulderTransforms() {
		// Retrieve current shoulder transforms
		R_shoulder = skeleton.GetJointTransform (R_shoulder_id);
		L_shoulder = skeleton.GetJointTransform (L_shoulder_id);
	}
}
