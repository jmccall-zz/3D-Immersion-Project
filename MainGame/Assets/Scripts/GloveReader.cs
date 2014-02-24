using UnityEngine;
using System.IO;
using System.Collections;
using System;


public class GloveReader {

	private string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\testfile.txt");
	public bool init;
	public float[] sensorValues;
	private string [] readLines;

	public GloveReader() {
		init = true;	
	}

	public float[] getValues() {
		string [] lines = readSelectLines (path, numToRead: 4);
		float [] dims = stringArrayToFloatArrary (lines);
		return dims;
	}

	private float [] stringArrayToFloatArrary(string [] array) {
		/* Convert an array of strings to array of floats */
		float [] floatArray = new float [array.Length];
		float num;
		
		for (int i = 0; i < array.Length; i++) {
			num = float.Parse(array[i]);
			floatArray[i] = num;
		}
		
		return floatArray;
	}

	private string [] readSelectLines(string filePath, int numToRead = 4) {
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
					readLines[i] = line;
					//Debug.Log("Debug: " + line);
				}
				sr.Close ();
			}
			// Catch any file reading exceptions
		} catch (IOException e) {
			Debug.LogError("The file could not be read: " + e.Message);
			readLines = null;
		}
		
		return readLines;
	}
}
