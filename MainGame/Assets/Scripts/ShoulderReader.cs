using UnityEngine;
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

	private bool record_joint_rotations = false;
	private bool record_joint_positions = false;
	// Seconds between measurement of time series joint data
	public float capture_rate = 0.5f;
	
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
	private float time_old = 0.0f;
	private float time_new = 0.0f;
	private float time_diff = 0.0f;

	// Degrees of rotation in both direction allowed for abduction measurement
	public float degrees_freedom = 10.0f;
	private const bool LEFT = false;
	private const bool RIGHT = true;
	public bool side_to_measure = RIGHT;

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

		shoulder_angles = new Vector3();


		db_control = new dbAccess ();
		user_id = PlayerPrefs.GetInt ("ActiveUser", 1);
		// DEBUG: Access some application run-time data.  Compare this output to where the scene was loaded from
		Debug.Log ("isEditor: " + Application.isEditor + "\nisLoadinglevel: " + Application.isLoadingLevel + "\nLoadedLevelName: " + Application.loadedLevelName + 
		           "\nplatform: " + Application.platform + "\nGenuine: " + Application.genuine + "\ngenuineCheckAvailable: " + Application.genuineCheckAvailable +
		           "\nbackgroundLoadingPriority: " + Application.backgroundLoadingPriority);

		// Calculate max and min y-axis rotations to allow abduction measurements
		max_y_rotation = degrees_freedom;
		min_y_rotation = -degrees_freedom;

		// Get zig joint identification numbers for each shoulder
		R_shoulder_id = ZigJointId.RightShoulder;
		L_shoulder_id = ZigJointId.LeftShoulder;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("In update() for shoulder reader");
		time_new += Time.deltaTime;
		time_diff = time_new - time_old;

		if (time_diff >= capture_rate) {
			// Update old time 
			time_old = time_new;
			// Check to make sure one user is actually in the Kinect's view
			if (zig_control.usersInView == 1) {
				sampler.SampleAllJoints(skeleton, user_id, record_rotations : record_joint_rotations, record_positions : record_joint_positions);
			}
		}

		// Determine which shoulder we will be sampling
		if (side_to_measure == LEFT) {
			//Debug.Log ("Measuring Left Shoulder Abduction Angle");
			joint_id = L_shoulder_id;
		} else {
			//Debug.Log ("Measuring Right Shoulder Abduction Angle");
			joint_id = R_shoulder_id;
		}

		shoulder_angles = skeleton.GetJointLocalEulerAngles (joint_id);
		//Debug.Log ("Angles: " + shoulder_angles.x + " " + shoulder_angles.y + " " + shoulder_angles.z);
		abduction_angle = GetAbductionAngle (shoulder_angles);

		// Check if abduction angle could be measured
		if (abduction_angle != -1) {
			// Check if max or min abduction angles have been reached
			if (abduction_angle > max_abduction)
				max_abduction = abduction_angle;
			if (abduction_angle < min_abduction)
				min_abduction = abduction_angle;
		}
	}

	/* Display instructions and check for scene switch */
	void OnGUI() {
		// Toggle buttons to determine which side to measure
		GUI.Label (new Rect (10, 15, 200, 30), "Side to Measure:");
		if (GUI.Toggle (new Rect (120, 5, 50, 20), side_to_measure, "Right"))
			side_to_measure = RIGHT;
		if (GUI.Toggle (new Rect (120, 25, 50, 20), !side_to_measure, "Left"))
			side_to_measure = LEFT;
		// Toggle buttons to determine whether or not to sample joint positions and rotations
		record_joint_positions = GUI.Toggle (new Rect (10, 50, 200, 20), record_joint_positions, "Record Joint Positions");
		record_joint_rotations = GUI.Toggle (new Rect (10, 70, 200, 20), record_joint_rotations, "Record Joint Rotations");

		// Store results and prompt user further
		if (GUI.Button(new Rect(10, 170, 200, 30), "Store Max/Min Angle")){
			UpdateMaxMinROM();
		}

		GUI.Label (new Rect (10, 215, 200, 30), "Read Angle:     " + shoulder_angles.z);
		GUI.Label (new Rect (10, 245, 200, 30), "Abduction Angle:" + abduction_angle);
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
	private void UpdateMaxMinROM() {
		string max_rom_field;
		string min_rom_field;

		if (side_to_measure == RIGHT) {
			max_rom_field = "r_shoulder_rom_max";
			min_rom_field = "r_shoulder_rom_min";
		} else {
			max_rom_field = "l_shoulder_rom_max";
			min_rom_field = "l_shoulder_rom_min";
		}

		string query = "UPDATE " + db_control.scores_table + " SET " + max_rom_field + "=" + max_abduction + "," + 
			min_rom_field + "=" + min_abduction + " WHERE user_id=" + user_id + ";";
		db_control.OpenDB ();
		db_control.BasicQuery (query);
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
