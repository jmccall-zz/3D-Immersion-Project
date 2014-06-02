using UnityEngine;
using System.IO;
using System.Collections;
using System;



public class GloveReader {
	private const int IndexFinger = 0;	
	private const int MiddleFinger = 2;
	private const int RingFinger = 4;
	private const int PinkyFinger = 6;
	private const int ZeroDegrees = 0;
	private const int FifteenDegrees = 1;
	private const int ThirtyDegrees = 2;
	private const int FortyFiveDegrees = 3;
	private const int SixtyDegrees = 4;
	private const int SeventyFiveDegrees = 5;
	private const int NinetyDegrees = 6;

	public int RH_IndexFinger () {
		return 0;
	}
	public int RH_MiddleFinger() {
		return 1;
	}
	public int RH_RingFinger () {
		return 2;
	}
	public int RH_PinkyFinger () {
		return 3;
	}
	public int RH_Knuckle () {
		return 4;
	}
	public int RH_AccX () {
		return 5;
	}
	public int RH_AccY () {
		return 6;
	}
	public int RH_AccZ () {
		return 7;
	}
	public int LH_IndexFinger () {
		return 8;
	}
	public int LH_MiddleFinger () {
		return 9;
	}
	public int LH_RingFinger () {
		return 10;
	}
	public int LH_PinkyFinger () {
		return 11;
	}
	public int LH_Knuckle () {
		return 12;
	}
	public int LH_AccX () {
		return 13;
	}
	public int LH_AccY () {
		return 14;
	}
	public int LH_AccZ () {
		return 15;
	}
	public int LH_GripMiddle () {
		return 16;
	}

	private string hand_path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GloveData.txt");
	public bool init;
	public bool RightIsGrab;
	public bool LeftIsGrab;
	public float[] sensorValues;
	private string [] readLines;
	private ArrayList allFingerZones;
	const int numOfDataPoints = 16;
	public int[] rightFingerZones;
	public int[] leftFingerZones;


	// Database Player Preference Information (from Login Scene)
	public int active_user;
	private dbAccess db_control;
	
	public GloveReader() {
		init = true;
		RightIsGrab = false;
		LeftIsGrab = false;
		// Instantiate database access object
		db_control = new dbAccess();
		// Read from global user id: user_id = ...
		// Get active user from player prefs. Use default user 1 if no active user is set
		active_user = PlayerPrefs.GetInt("ActiveUser", 1);
		Debug.Log ("Glove reader sees active user: " + active_user);
		allFingerZones = readDB (active_user);
		rightFingerZones = (int[]) allFingerZones [0];
		leftFingerZones = (int[]) allFingerZones [1];
	}

	/* 
	 * This function will grab calibration data for the active user defined in PlayerPrefs.
	 * Right and left hand data is retrieved from the database and stored in separate integer
	 * lists. These lists are returned in one array list object. It's up to the caller to 
	 * break them apart
	 */
	private ArrayList readDB(int user_id) {
		ArrayList fingerBlocks = new ArrayList();
		int [] rightFingerBlocks = new int [10];
		int [] leftFingerBlocks = new int [10];

		rightFingerBlocks = GetCalibrationRow (db_control.right_calib_table, user_id);
		leftFingerBlocks = GetCalibrationRow (db_control.left_calib_table, user_id);

		// Store integer arrays into ArrayList object and return
		fingerBlocks.Add (rightFingerBlocks);
		fingerBlocks.Add (leftFingerBlocks);

		Debug.Log ("Got the calibration data: " + rightFingerBlocks[0]);
		return fingerBlocks;
	}

	/* 
	 * This function pulls a single row of calibration data from the database and returns
	 * it in the form of an integer array.
	 */ 
	private int [] GetCalibrationRow(string table_name, int user_id) {
		int [] blocks = new int[10];
		string query;
		ArrayList results = new ArrayList();
		ArrayList row = new ArrayList();
		// Open up our database
		db_control.OpenDB();
		
		// Pull entire right hand calibration data row for this user
		query = "SELECT * FROM " + table_name + " WHERE user_id=" + user_id + ";";
		results = db_control.BasicQuery(query);
		// Close the database to avoid locking
		db_control.CloseDB();
		//Debug.Log("Pulling calibrations from: " + table_name + " for user: " + user_id);
		
		// If a row is returned by the query, fill the integer array with data
		if (results.Count > 0) {
			// Capture first row of returned data
			row = (ArrayList) results[0];
			// Convert values to intgers
			for (int i = 1; i < row.Count; i++) {
				blocks[i - 1] = Convert.ToInt32(row[i]);
			}
		} else {
			// Retrieve calibration information from the default user if current active user does not have calibration data
			Debug.Log("No calibration data was found for user: " + user_id + "\nRetrieving default data now");

			GetCalibrationRow (table_name, 1);
		}
		return blocks;
	}

	public void UpdateGestures(){
		sensorValues = this.getValues ();

		// Update Right Hand Grab gesture
		if (sensorValues[0] < (((rightFingerZones[IndexFinger]-rightFingerZones[IndexFinger+1])/2) + rightFingerZones[IndexFinger+1]) ||
		    sensorValues[1] < (((rightFingerZones[MiddleFinger]-rightFingerZones[MiddleFinger+1])/2) + rightFingerZones[MiddleFinger+1]) || 
		    sensorValues[2] < (((rightFingerZones[RingFinger]-rightFingerZones[RingFinger+1])/2) + rightFingerZones[RingFinger+1]) || 
		    sensorValues[3] < (((rightFingerZones[PinkyFinger]-rightFingerZones[PinkyFinger+1])/2) + rightFingerZones[PinkyFinger+1])) {
			RightIsGrab = true;
		} else { /*if (sensorValues[0] > (((rightFingerZones[IndexFinger]-rightFingerZones[IndexFinger+1])/2) + rightFingerZones[IndexFinger+1]) &&
		           sensorValues[1] > (((rightFingerZones[MiddleFinger]-rightFingerZones[MiddleFinger+1])/2) + rightFingerZones[MiddleFinger+1]) && 
		           sensorValues[2] > (((rightFingerZones[RingFinger]-rightFingerZones[RingFinger+1])/2) + rightFingerZones[RingFinger+1]) && 
		           sensorValues[3] > (((rightFingerZones[PinkyFinger]-rightFingerZones[PinkyFinger+1])/2) + rightFingerZones[PinkyFinger+1])) */
			RightIsGrab = false;
		}

		// Update Left Hand Grab gesture
		if (sensorValues[this.LH_IndexFinger()] < (((leftFingerZones[IndexFinger]-leftFingerZones[IndexFinger+1])/2) + leftFingerZones[IndexFinger+1]) ||
		    sensorValues[this.LH_MiddleFinger()] < (((leftFingerZones[IndexFinger]-leftFingerZones[IndexFinger+1])/2) + leftFingerZones[IndexFinger+1]) || 
		    sensorValues[this.LH_RingFinger()] < (((leftFingerZones[IndexFinger]-leftFingerZones[IndexFinger+1])/2) + leftFingerZones[IndexFinger+1]) || 
		    sensorValues[this.LH_PinkyFinger()] < (((leftFingerZones[IndexFinger]-leftFingerZones[IndexFinger+1])/2) + leftFingerZones[IndexFinger+1])) {
			LeftIsGrab = true;
		} else {/*if (sensorValues[this.LH_IndexFinger()] > leftFingerZones[IndexFinger + FortyFiveDegrees] &&
		           sensorValues[this.LH_MiddleFinger()] > leftFingerZones[MiddleFinger + FortyFiveDegrees] && 
		           sensorValues[this.LH_RingFinger()] > leftFingerZones[RingFinger + FortyFiveDegrees] && 
		           sensorValues[this.LH_PinkyFinger()] > leftFingerZones[PinkyFinger + FortyFiveDegrees])*/ 
			LeftIsGrab = false;
		}
	}

	public float[] getValues() {
		// Get strings from hand data file
		string [] lines = readSelectLines (hand_path, numOfDataPoints);
		// Float arrays for right and left and hands
		float [] f_array;
		if (lines != null) {
			// Get float arrays
			f_array = stringArrayToFloatArray (lines);

			return f_array;
		} else {
			Debug.Log ("ey glovereader");
			return null;
		}
	}

	private float [] stringArrayToFloatArray(string [] array) {
		/* Convert an array of strings to array of floats */
		float [] floatArray = new float [array.Length];
		float num;
		
		for (int i = 0; i < array.Length; i++) {
			//Debug.Log(i);
			//Debug.Log(array);
			//Debug.Log("Index: " + i.ToString() + " Value: " + array[i]);
			if(array[i] != null) {
				num = float.Parse(array[i]);
			} else {
				num = 0;
			}
				floatArray[i] = num;
		}
		
		return floatArray;
	}

	private string [] readSelectLines(string filePath, int numToRead) {
		/* Read the specified number of lines from a file starting with the first line.  This function
		 * returns an array of strings, indexed or each line in the file.
		 *
		 *@ param linesToRead: Number of lines to read from file starting at top
		 */
		string line;
		readLines = new string[numToRead];
		try {
			// Use stream reader object to execute file reads
			using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			using (StreamReader sr = new StreamReader(fileStream)) {
				for (int i = 0; i < numToRead; i++) {
					// Read a line
					line = sr.ReadLine();
					if (line == null)
						break;
					readLines[i] = line;
					//Debug.Log("Debug: " + line);
				}
				sr.Close ();
			}
			// Catch any file reading exceptions
		} catch (IOException e) {
			Debug.Log("The file could not be read: " + e.Message);
			readLines = null;
		}
		
		return readLines;
	}
}
