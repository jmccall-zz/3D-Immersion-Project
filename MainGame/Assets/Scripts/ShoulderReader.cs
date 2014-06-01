﻿using UnityEngine;
using System.Collections;
using System;

/* Measure the max and min left and right shoulder abduction angles using Kinect.
 * This seen can also be used to sample upper body joint rotations and positions by selecting
 * "record_joint_rotations" and "record_joint_positions", respectively, in the editor.  Also use the 
 * editor to specify the rate at which you want to sample joint rotation and position data.
 * NOTE: If you would like to test functionality while disconnected from the kinect, uncheck the "Zigfu"
 * game object in the editor
 */

public class ShoulderReader : MonoBehaviour {

	private GameObject zigfu;
	private Transform R_shoulder;
	private Transform L_shoulder;
	private ZigJointId joint_id;
	private ZigJointId R_shoulder_id;
	private ZigJointId L_shoulder_id;
	private ZigSkeleton skeleton;
	private Zig zig_control;
	private bool measurement_complete = false;
	private dbAccess db_control;
	private string db_name;
	private string scores_table;
	private int user_id;
	private JointSampler sampler;

	private bool record_joint_rotations = true;
	private bool record_joint_positions = true;
	// Seconds between measurement of time series joint data
	public float capture_rate = 0.5f;
	
	// The localEulerAngles of the shoulder. This array of length three represents
	// x, y, and z rotation angles.
	private Vector3 l_shoulder_angles;
	private Vector3 r_shoulder_angles;
	// Measured abduction angle observed and calculated
	private float l_abduction_angle;
	private float r_abduction_angle;
	// Maximum/minimum measured abduction angles
	private float l_max_abduction = 0.0f;
	private float l_min_abduction = 180.0f;
	private float r_max_abduction = 0.0f;
	private float r_min_abduction = 180.0f;
	private float l_side_hold = 0.0f;
	private float r_side_hold = 0.0f;
	private float l_front_hold = 0.0f;
	private float r_front_hold = 0.0f;

	// Y-axis rotational boundaries.  Measurements of shoulder abduction angle will only be measured if
	// the shoulder's y-axis rotation is in this range!
	private float max_y_rotation;
	private float min_y_rotation;
	private float time_old = 0.0f;
	private float time_new = 0.0f;
	private float time_diff = 0.0f;

	// Degrees of rotation in both direction allowed for abduction measurement
	public float degrees_freedom = 10.0f;
	private const bool LEFT = false;
	private const bool RIGHT = true;
	//public bool side_to_measure = RIGHT;
	private int currentExercise;
	private string exercise;
	private GUIStyle style;
	private string instructions;
	private bool inPosition;
	private float timer_hold;

	// Use this for initialization
	void Start () {
		// Instantiate objects
		// Load ZigFu game object.  This game object has 4 Zig related script Components.  Use this object
		// to instances of these script's classes in order to access event information :)
		zigfu = GameObject.Find ("ZigFu");
		sampler = new JointSampler ();
		zig_control = zigfu.GetComponent <Zig>();
		// This script is attached to Carl so GetComponent can be called directly
		skeleton = GetComponent <ZigSkeleton>();

		l_shoulder_angles = new Vector3();
		r_shoulder_angles = new Vector3();

		db_control = new dbAccess ();
		user_id = PlayerPrefs.GetInt ("ActiveUser", 1);
		// DEBUG: Access some application run-time data.  Compare this output to where the scene was loaded from
		//Debug.Log ("isEditor: " + Application.isEditor + "\nisLoadinglevel: " + Application.isLoadingLevel + "\nLoadedLevelName: " + Application.loadedLevelName + 
		//           "\nplatform: " + Application.platform + "\nGenuine: " + Application.genuine + "\ngenuineCheckAvailable: " + Application.genuineCheckAvailable +
		//           "\nbackgroundLoadingPriority: " + Application.backgroundLoadingPriority);

		// Calculate max and min y-axis rotations to allow abduction measurements
		max_y_rotation = degrees_freedom;
		min_y_rotation = -degrees_freedom;

		// Get zig joint identification numbers for each shoulder
		R_shoulder_id = ZigJointId.RightShoulder;
		L_shoulder_id = ZigJointId.LeftShoulder;

		currentExercise = 0;
		exercise = "Press Next To Start";
		style = new GUIStyle();
		instructions = " ";
		timer_hold = 0;
		inPosition = true;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentExercise) {
		case 0: exercise = "Press Next To Start";
			instructions = " ";
			break;

		// Max/min shoulder abduction right arm
		case 1: exercise = "2";
			instructions = "2";
			r_shoulder_angles = skeleton.GetJointLocalEulerAngles (R_shoulder_id);
			r_abduction_angle = GetAbductionAngle (r_shoulder_angles);
			if (l_abduction_angle != -1) {
				// Check if max or min abduction angles have been reached
				if (r_abduction_angle > r_max_abduction) 
					r_max_abduction = r_abduction_angle;
				if (r_abduction_angle < r_min_abduction)
					r_min_abduction = r_abduction_angle;
			}
			break;

		// Max/min shoulder abduction left arm
		case 2: exercise = "3";
			instructions = "4";
			l_shoulder_angles = skeleton.GetJointLocalEulerAngles (L_shoulder_id);
			l_abduction_angle = GetAbductionAngle (l_shoulder_angles);
			if (l_abduction_angle != -1) {
				// Check if max or min abduction angles have been reached
				if (l_abduction_angle > l_max_abduction) 
					l_max_abduction = l_abduction_angle;
				if (l_abduction_angle < l_min_abduction)
					l_min_abduction = l_abduction_angle;
			}
			break;

		// How long can you hold right arm out to the side
		case 3: exercise = "4";
			instructions = "4";
			break;

		// How long can you hold left arm out to the side
		case 4: exercise = "5";
			instructions = "5";
			break;

		// How long can you hold right arm out in front
		case 5: exercise = "6";
			instructions = "6";
			break;

		// How long can you hold left arm out in front
		case 6: exercise = "7";
			instructions = "7";
			break;

		// Final page with test results yay!!!
		case 7: exercise = "8";
			instructions = "8";
			break;

		default: currentExercise = 0;
			instructions = " "; 
			break;
		}
		
		timer_hold += Time.deltaTime;

		/*******************************************************************/
		/*************** Routine for sampling all body joints **************/
		time_new += Time.deltaTime;
		time_diff = time_new - time_old;

		if (time_diff >= capture_rate) {
			// Update old time 
			time_old = time_new;
			// Check to make sure one user is actually in the Kinect's view
			if (zig_control.usersInView == 1) {
				sampler.SampleAllJoints(skeleton, user_id, db_control.shoulder_rom_scene, record_rotations : record_joint_rotations, record_positions : record_joint_positions);
			}
		}
		/*******************************************************************/
	}

	/* Display instructions and check for scene switch */
	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width/2 + 50, Screen.height-50,100,40), "Next")) {
			currentExercise++;
			// Store max/min right shoulder abduction angle
			if (currentExercise == 2) {
				UpdateMaxMinROM(r_max : r_max_abduction, r_min : r_min_abduction);
			
			// Store max/min left shoulder abduction angle
			} else if (currentExercise == 3) {
				UpdateMaxMinROM(l_max : l_max_abduction, l_min : l_min_abduction);

			// 
			} else if (currentExercise == 4) {
				UpdateMaxMinROM(l_max : l_max_abduction, l_min : l_min_abduction);
				
			} else if (currentExercise == 5) {
				UpdateMaxMinROM(l_max : l_max_abduction, l_min : l_min_abduction);
				
			} else if (currentExercise == 6) {
				UpdateMaxMinROM(l_max : l_max_abduction, l_min : l_min_abduction);
				
			} else if (currentExercise == 7) {
				UpdateMaxMinROM(l_max : l_max_abduction, l_min : l_min_abduction);
				
			} else if (currentExercise > 7) {
				currentExercise = 7;
			} else {
				timer_hold = 0;
			}
		}
		if (GUI.Button (new Rect (Screen.width/2 - 50, Screen.height-50,100,40), "Prev")) {
			currentExercise--;
			if (currentExercise < 0) {
				currentExercise = 0;
			} else {
				timer_hold = 0;
			}
		}
		style.fontSize = 25;
		style.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect(Screen.width/2, Screen.height-100, 160, 40), exercise, style);
		
		style.alignment = TextAnchor.UpperCenter;
		if (currentExercise == 3) {
			GUI.Label (new Rect (Screen.width / 2, 200, 160, 40), timer_hold.ToString ().Remove (4), style);	
		}
		
		style.fontSize = 60;
		
		GUI.Label (new Rect(Screen.width/2, 50, 160, 40), exercise, style);	
		// Toggle buttons to determine which side to measure
		//GUI.Label (new Rect (10, 15, 200, 30), "Side to Measure:");
		//if (GUI.Toggle (new Rect (120, 5, 50, 20), side_to_measure, "Right"))
		//	side_to_measure = RIGHT;
		//if (GUI.Toggle (new Rect (120, 25, 50, 20), !side_to_measure, "Left"))
		//	side_to_measure = LEFT;
		// Toggle buttons to determine whether or not to sample joint positions and rotations
		//record_joint_positions = GUI.Toggle (new Rect (10, 50, 200, 20), record_joint_positions, "Record Joint Positions");
		//record_joint_rotations = GUI.Toggle (new Rect (10, 70, 200, 20), record_joint_rotations, "Record Joint Rotations");

		// Store results and prompt user further
		//if (GUI.Button(new Rect(10, 170, 200, 30), "Store Max/Min Angle")){
		//	UpdateMaxMinROM();
		//}

		//GUI.Label (new Rect (10, 215, 200, 30), "Read Angle:     " + shoulder_angles.z);
		//GUI.Label (new Rect (10, 245, 200, 30), "Abduction Angle:" + abduction_angle);
	}

	/*
	 * Retrieve measured abduction angle given all shoulder rotation angles.  The normal range for
	 * a vertical shoulder abduction measurement is 0 degrees to 180 degrees.  0 meaning arm lowered
	 * parallel to spine.  180 meaning arm raised parallel to spine.
	 */
	private float GetAbductionAngle(Vector3 angles) {
		float angle = -1;
		if ((angles.y >  max_y_rotation) || (angles.y < min_y_rotation)) {
			angle = Math.Abs (angles.z - 90.0f);
			//Debug.Log ("Measured Abduction Angle: " + angle);
		} 
		// Only return the measured abduction angle if it is between 0 and 180 degrees
		if ((angle < 180.0f) && (angle > 0.0f))
			return angle;

		return -1;
	}

	/* Update the maximum and minimum shoulder abduction angles for this user in the database. */
	private void UpdateMaxMinROM(float r_max = -1.0f, float l_max = -1.0f, float r_min = -1.0f, float l_min = -1.0f) {
		string r_max_field = "r_shoulder_rom_max";
		string l_max_field = "l_shoulder_rom_max";
		string r_min_field = "r_shoulder_rom_min";
		string l_min_field = "l_shoulder_rom_min";
		string query;

		// Open up the database yee
		db_control.OpenDB ();

		if (r_max == -1.0f) {
			query = "UPDATE " + db_control.scores_table + " SET " + r_max_field + "=" + r_max + " WHERE user_id=" + user_id + ";";
			db_control.BasicQuery(query);
		}

		if (l_max == -1.0f) {
			query = "UPDATE " + db_control.scores_table + " SET " + l_max_field + "=" + l_max + " WHERE user_id=" + user_id + ";";
			db_control.BasicQuery(query);
		}

		if (r_min == -1.0f) {
			query = "UPDATE " + db_control.scores_table + " SET " + r_min_field + "=" + r_min + " WHERE user_id=" + user_id + ";";
			db_control.BasicQuery(query);
		}

		if (l_min == -1.0f) {
			query = "UPDATE " + db_control.scores_table + " SET " + l_min_field + "=" + l_min + " WHERE user_id=" + user_id + ";";
			db_control.BasicQuery(query);
		}

		db_control.CloseDB ();
	}

	/* 
	When play mode is stopped make sure to close the database.  This helps avoid some database
	issues upon early exit.
	*/
	private void OnApplicationQuit() {
		db_control.CloseDB ();
		PlayerPrefs.Save();
	}
}
