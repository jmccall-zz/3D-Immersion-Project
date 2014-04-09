using UnityEngine;
using System.Collections;
using System;

public class ShoulderReader : MonoBehaviour {

	private Transform R_shoulder;
	private Transform L_shoulder;
	private ZigJointId joint_id;
	private ZigJointId R_shoulder_id;
	private ZigJointId L_shoulder_id;
	private ZigSkeleton skeleton;
	private bool measurement_complete = false;
	private dbAccess db_control;
	private string db_name;
	private string scores_table;
	private int user_id;

	// The localEulerAngles of the shoulder. This array of length three represents
	// x, y, and z rotation angles.
	private Vector3 shoulder_angles;
	// Measured abduction angle observed and calculated
	private float abduction_angle;
	// Maximum/minimum measured abduction angles
	private float max_abduction = 0.0f;
	private float min_abduction = 180.0f;
	// Y-axis rotational boundaries.  Measurements of shoulder abduction angle will only be measured if
	// the shoulder's y-axis rotation is in this range!
	private float max_y_rotation;
	private float min_y_rotation;

	// Degrees of rotation in both direction allowed for abduction measurement
	public float degrees_freedom = 10.0f;
	public bool measure_left = false;


	// Use this for initialization
	void Start () {
		// Instantiate objects
		shoulder_angles = new Vector3();
		skeleton = GetComponent <ZigSkeleton>();
		db_control = new dbAccess ();
		db_name = PlayerPrefs.GetString ("DBName");
		scores_table = PlayerPrefs.GetString ("ScoresTable");
		user_id = PlayerPrefs.GetInt ("ActiveUser");



		// Calculate max and min y-axis rotations to allow abduction measurements
		max_y_rotation = degrees_freedom;
		min_y_rotation = -degrees_freedom;

		// Get zig joint identification numbers for each shoulder
		R_shoulder_id = ZigJointId.RightShoulder;
		L_shoulder_id = ZigJointId.LeftShoulder;

	}
	
	// Update is called once per frame
	void Update () {
		// Check if we are done with the current measurement
		if (Input.GetKeyDown("space")) {
			measurement_complete = true;
			//TODO: Write to database here.  Maybe we want to check if better results already exist and 
			// say something to therapist.  Or we could leave this type of data analysis to whoever is reading 
			// from the database.  This makes sense as therapists can conduct whatever scenes they want and move
			// to data analysis at a later time
			UpdateDatabaseROM();
		}
		// Determine which shoulder we will be sampling
		if (measure_left) {
			Debug.Log ("Measuring Left Shoulder Abduction Angle");
			joint_id = L_shoulder_id;
		} else {
			Debug.Log ("Measuring Right Shoulder Abduction Angle");
			joint_id = R_shoulder_id;
		}
		shoulder_angles = skeleton.GetJointEulerAngles (joint_id);

		abduction_angle = GetAbductionAngle (shoulder_angles);

		// Check if abduction angle could be measured
		if (abduction_angle == -1) {
			// Check if max or min abduction angles have been reached
			if (abduction_angle > max_abduction)
				max_abduction = abduction_angle;
			if (abduction_angle < min_abduction)
				min_abduction = abduction_angle;
		}
		Debug.Log ("Measured Abduction Angle: " + abduction_angle);
	}
	
	/* Retrieve measured abduction angle given all shoulder rotation angles.  The normal range for
	 a vertical shoulder abduction measurement is 0 degrees to 180 degrees.  0 meaning arm lowered
	 parallel to spine.  180 meaning arm raised parallel to spine. */
	private float GetAbductionAngle(Vector3 angles) {
		float angle = -1;
		if ((angles.y >  max_y_rotation) || (angles.y < min_y_rotation)) {
			angle = Math.Abs (angles.z - 90.0f);
		} 

		return angle;
	}

	private void UpdateDatabaseROM() {
		string max_rom_field = "shoulder_rom_max";
		string min_rom_field = "shoulder_rom_min";

		string query = "UPDATE " + scores_table + " SET " + max_rom_field + "=" + max_abduction + "," + 
			min_rom_field + "=" + min_abduction + " WHERE user_id=" + user_id + ";";
		db_control.OpenDB (db_name);
		db_control.BasicQuery (query);
		db_control.CloseDB ();
	}
}
