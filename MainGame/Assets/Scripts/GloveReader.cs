using UnityEngine;
using System.IO;
using System.Collections;
using System;



public class GloveReader {
	public const int IndexFinger = 0;	
	public const int MiddleFinger = 7;
	public const int RingFinger = 14;
	public const int PinkyFinger = 21;
	public const int ZeroDegrees = 0;
	public const int FifteenDegrees = 1;
	public const int ThirtyDegrees = 2;
	public const int FortyFiveDegrees = 3;
	public const int SixtyDegrees = 4;
	public const int SeventyFiveDegrees = 5;
	public const int NinetyDegrees = 6;

	private string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\testfile.txt");
	public bool init;
	public bool IsGrab;
	public float[] sensorValues;
	private string [] readLines;
	static int numOfDataPoints = 7;
	int [] fingerZones;

	int user_id;

	public GloveReader() {
		init = true;
		IsGrab = false;
		// Read from global user id: user_id = ...
		fingerZones = readDb (user_id);
	}

	public void ScaleValues () {

	}

	private int [] readDb(int user_id) {
		return;
	}

	public void UpdateGestures(){
		float [] sensorVal = this.getValues ();

		if (sensorVal[0] < 13000 || sensorVal[1] < 200 || sensorVal[2] < 12000 || sensorVal[3] < 4000) {
			IsGrab = true;
		} else if (sensorVal[0] > 13000 && sensorVal[1] > 200 && sensorVal[2] > 12000 && sensorVal[3] > 4000) {
			IsGrab = false;
		}
	}

	public float[] getValues() {
		string [] lines = readSelectLines (path, numOfDataPoints);
		float [] dims;
		if (lines != null){
			dims = stringArrayToFloatArray (lines);
			return dims;
		} else {
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
