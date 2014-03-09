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
	private float[] rightCalibrationPoints = new float[29];
	private float[] leftCalibrationPoints = new float[29];
	
	public const int MAX_TRANSITIONS = 6;
	private int transitionCount = 0;
	private int[] finger_extensions = {100, 83, 66, 50, 33, 17, 0};
	// Which fingers are represented by lines in the text file
	private int indexFingerIndex = 1;
	private int middleFingerIndex = 2;
	private int ringFingerIndex = 3;
	private int pinkyFingerIndex = 0;
	
	// Database Player Preference Information (from Login Scene)
	private int active_user;
	private string db_name;
	private string right_calibration_table;
	private string left_calibration_table;
	private string user_table;
	
	public string next_level = "ReachBack";
	
	
	// Use this for initialization
	void Start () {
		moving = false;
		reader = new GloveReader ();
		amount = 0.25f;
		
		// Set up database info and open connection
		SetupDatabase ();
		rightCalibrationPoints [0] = leftCalibrationPoints [0] = active_user;
		//db_control.InsertInto(calibration_table_name, rightCalibrationPoints);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		
		// We've gone through all the images at this point so our calibration data structure
		// should be full now.  Let's store this data in the database now.
		if (transitionCount > MAX_TRANSITIONS){
			Application.LoadLevel(next_level);
		}
		
		// Update GUI text to display proper instructions
		instructions.text = "Copy the hand position \n" +
			"shown in the image. \n" +
				"Finger Extention: " + 
				finger_extensions[transitionCount] + "%";
		
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
		float [] values = reader.getValues();
		int index;
		//float[] values = {10, 20, 30, 40};
		Debug.Log ("Values: " + values [0] + values [1] + values [2] + values [3]);

		// Set calibrations for the right hand during first 7 transitions
		if (transitionCount < 7) {
			// Set base index for reference
			index = transitionCount + 1;
			rightCalibrationPoints [index] = values[indexFingerIndex];
			rightCalibrationPoints [index + 7] = values[middleFingerIndex];	
			rightCalibrationPoints [index + 14] = values[ringFingerIndex];	
			rightCalibrationPoints [index + 15] = values[pinkyFingerIndex];	
		} else if (transitionCount < 14) {
			// Set base index for reference
			index = transitionCount - 6;
			leftCalibrationPoints [index] = values[indexFingerIndex];
			leftCalibrationPoints [index + 7] = values[middleFingerIndex];	
			leftCalibrationPoints [index + 14] = values[ringFingerIndex];	
			leftCalibrationPoints [index + 15] = values[pinkyFingerIndex];	
		} else {
			Debug.Log("End of scene. No more data to capture.");
		}

		/*// 0 degrees
		if (transitionCount == 0) {
			rightCalibrationPoints[1] = values[indexFingerIndex];
			rightCalibrationPoints[8] = values[middleFingerIndex];
			rightCalibrationPoints[15] = values[ringFingerIndex];
			rightCalibrationPoints[22] = values[pinkyFingerIndex];
			// 15 degrees
		} else if (transitionCount == 1) {
			rightCalibrationPoints[2] = values[indexFingerIndex];
			rightCalibrationPoints[9] = values[middleFingerIndex];
			rightCalibrationPoints[16] = values[ringFingerIndex];
			rightCalibrationPoints[23] = values[pinkyFingerIndex];
			// 30 degrees
		} else if (transitionCount == 2) {
			rightCalibrationPoints[3] = values[indexFingerIndex];
			rightCalibrationPoints[10] = values[middleFingerIndex];
			rightCalibrationPoints[17] = values[ringFingerIndex];
			rightCalibrationPoints[24] = values[pinkyFingerIndex];
			// 45 degrees
		} else if (transitionCount == 3) {
			rightCalibrationPoints[4] = values[indexFingerIndex];
			rightCalibrationPoints[11] = values[middleFingerIndex];
			rightCalibrationPoints[18] = values[ringFingerIndex];
			rightCalibrationPoints[25] = values[pinkyFingerIndex];
			// 60 degrees
		} else if (transitionCount == 4) {
			rightCalibrationPoints[5] = values[indexFingerIndex];
			rightCalibrationPoints[12] = values[middleFingerIndex];
			rightCalibrationPoints[19] = values[ringFingerIndex];
			rightCalibrationPoints[26] = values[pinkyFingerIndex];
			// 75 degrees
		} else if (transitionCount == 5) {
			rightCalibrationPoints[6] = values[indexFingerIndex];
			rightCalibrationPoints[13] = values[middleFingerIndex];
			rightCalibrationPoints[20] = values[ringFingerIndex];
			rightCalibrationPoints[27] = values[pinkyFingerIndex];
			// 90 degrees
		} else if (transitionCount == 6) {
			rightCalibrationPoints[7] = values[indexFingerIndex];
			rightCalibrationPoints[14] = values[middleFingerIndex];
			rightCalibrationPoints[21] = values[ringFingerIndex];
			rightCalibrationPoints[28] = values[pinkyFingerIndex];
		} else {
			Debug.Log("End of scene. No more data to capture.");
		}*/
	}
	
	// Setup our database here.  First grab all data saved as PlayerPreferences and capture it locally.
	// Next instantiate our database access object and open the database
	void SetupDatabase() {
		Debug.Log ("Setting up the database for calibration");
		// Capture DB info from Player Preferences
		active_user = PlayerPrefs.GetInt ("ActiveUser", 1);
		db_name = PlayerPrefs.GetString ("DBName", "RehabStats.sqdb");
		right_calibration_table = PlayerPrefs.GetString ("RightCalibrationTable", "RightCalibration");
		left_calibration_table = PlayerPrefs.GetString ("LeftCalibrationTable", "LeftCalibration");
		user_table = PlayerPrefs.GetString ("UserTable", "UserProfiles");
		
		// Instantiate instance of db access controller and open up our database
		db_control = new dbAccess ();
		db_control.OpenDB (db_name);
	}
	
	// This function will insert our calibration data points as a row in the calibration database table
	void SaveData(){
	}
	
	void OnApplicationQuit() {
		db_control.CloseDB ();
		PlayerPrefs.Save ();
	}
}
