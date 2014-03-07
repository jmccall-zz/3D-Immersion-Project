using UnityEngine;
using System.Collections;

public class RecordAndMoveCalibrate : MonoBehaviour {
	
	private bool moving = false;
	private static float amount;
	public GUIText instructions;
	GloveReader reader;

	private dbAccess db_control;
	// These 29 fields represent all the columns in the calibration table.  Storing them in 
	// a large list allows us to simple pass the structure into a database control function
	// for the database insertion. NOTE: Index zero is the active user_id.
	private float[] calibrationDataPoints = new float[29];

	public const int MAX_TRANSITIONS = 6;
	private int transitionCount = 0;
	private int percent_extension;
	// Which fingers are represented by lines in the text file
	private int indexFingerIndex = 1;
	private int middleFingerIndex = 2;
	private int ringFingerIndex = 3;
	private int pinkyFingerIndex = 0;

	// Database Player Preference Information (from Login Scene)
	private int active_user;
	private string db_name;
	private string calibration_table_name;
	private string user_table_name;

	public string next_level = "ReachBack";


	// Use this for initialization
	void Start () {
		moving = false;
		reader = new GloveReader ();
		amount = 0.25f;

		// Set up database info and open connection
		SetupDatabase ();
		calibrationDataPoints [0] = active_user;
		//db_control.InsertInto(calibration_table_name, calibrationDataPoints);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;

		// We've gone through all the images at this point so our calibration data structure
		// should be full now.  Let's store this data in the database now.
		if (transitionCount > MAX_TRANSITIONS){
			SaveData();
			Application.LoadLevel(next_level);
		}
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

		// Update GUI text to display proper instructions
		percent_extension = (int) ((transitionCount * 15) + (transitionCount + (transitionCount * 0.67)));
		instructions.text = "Copy the hand position \n" +
			"shown in the image. \n" +
			"Finger Extention: " + 
			percent_extension + "%";
	}

	void Record() {
		float [] values = reader.getValues();
		//float[] values = {10, 20, 30, 40};
		Debug.Log ("Values: " + values [0] + values [1] + values [2] + values [3]);

		// 0 degrees
		if (transitionCount == 0) {
			calibrationDataPoints[1] = values[indexFingerIndex];
			calibrationDataPoints[8] = values[middleFingerIndex];
			calibrationDataPoints[15] = values[ringFingerIndex];
			calibrationDataPoints[22] = values[pinkyFingerIndex];
		// 15 degrees
		} else if (transitionCount == 1) {
			calibrationDataPoints[2] = values[indexFingerIndex];
			calibrationDataPoints[9] = values[middleFingerIndex];
			calibrationDataPoints[16] = values[ringFingerIndex];
			calibrationDataPoints[23] = values[pinkyFingerIndex];
		// 30 degrees
		} else if (transitionCount == 2) {
			calibrationDataPoints[3] = values[indexFingerIndex];
			calibrationDataPoints[10] = values[middleFingerIndex];
			calibrationDataPoints[17] = values[ringFingerIndex];
			calibrationDataPoints[24] = values[pinkyFingerIndex];
		// 45 degrees
		} else if (transitionCount == 3) {
			calibrationDataPoints[4] = values[indexFingerIndex];
			calibrationDataPoints[11] = values[middleFingerIndex];
			calibrationDataPoints[18] = values[ringFingerIndex];
			calibrationDataPoints[25] = values[pinkyFingerIndex];
		// 60 degrees
		} else if (transitionCount == 4) {
			calibrationDataPoints[5] = values[indexFingerIndex];
			calibrationDataPoints[12] = values[middleFingerIndex];
			calibrationDataPoints[19] = values[ringFingerIndex];
			calibrationDataPoints[26] = values[pinkyFingerIndex];
		// 75 degrees
		} else if (transitionCount == 5) {
			calibrationDataPoints[6] = values[indexFingerIndex];
			calibrationDataPoints[13] = values[middleFingerIndex];
			calibrationDataPoints[20] = values[ringFingerIndex];
			calibrationDataPoints[27] = values[pinkyFingerIndex];
		// 90 degrees
		} else if (transitionCount == 6) {
			calibrationDataPoints[7] = values[indexFingerIndex];
			calibrationDataPoints[14] = values[middleFingerIndex];
			calibrationDataPoints[21] = values[ringFingerIndex];
			calibrationDataPoints[28] = values[pinkyFingerIndex];
		} else {
			Debug.Log("End of scene. No more data to capture.");
		}
	}

	// Setup our database here.  First grab all data saved as PlayerPreferences and capture it locally.
	// Next instantiate our database access object and open the database
	void SetupDatabase() {
		Debug.Log ("Setting up the database for calibration");
		// Capture DB info from Player Preferences
		active_user = PlayerPrefs.GetInt ("ActiveUser", 1);
		db_name = PlayerPrefs.GetString ("DBName", "RehabStats.sqdb");
		calibration_table_name = PlayerPrefs.GetString ("CalibrationTable", "CalibTable");
		user_table_name = PlayerPrefs.GetString ("UserTable", "UserProfiles");

		// Instantiate instance of db access controller and open up our database
		db_control = new dbAccess ();
		db_control.OpenDB (db_name);
	}

	// This function will insert our calibration data points as a row in the calibration database table
	void SaveData(){
		db_control.InsertInto (calibration_table_name, calibrationDataPoints);
	}

	void OnApplicationQuit() {
		db_control.CloseDB ();
		PlayerPrefs.Save ();
	}
}
