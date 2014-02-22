using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Models : MonoBehaviour {
	
	static public float[] fingers = new float[4];
	private string [] readLines = new string[4];
	// Path to file with data for each finger
	private string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\testfile.txt");
	public GUIText readings;
	
	int errorcounter = 0;
	
	
	void start() {
		/* Initialization */
	}
	
	void Update() {
		/* Updates every frame */
		try {
			string [] lines = readSelectLines (path, numToRead: 4);
			float [] dims = stringArrayToFloatArrary (lines);
			/* Scale text file values */
			/*
			fingers[0] = (dims[0] - 2000) / 3;
			fingers[1] = (dims[1] - 2000) / 3;
			fingers[2] = (dims[2] - 2000) / 3;
			fingers[3] = (dims[3] - 2000) / 3;
			*/
			////////////////////////index block definitions//////////////////
			
			int Index_Finger_Block_0  = 54000;
			int Index_Finger_Block_15 = 48000;
			int Index_Finger_Block_30 = 37000;
			int Index_Finger_Block_45 = 30000;
			int Index_Finger_Block_60 = 27000;	
			int Index_Finger_Block_75 = 25000;
			int Index_Finger_Block_90 = 1700;	
			
			
			////////////////////////middle finger block definitions//////////////
			int Middle_Finger_Block_0  = 54800;
			int Middle_Finger_Block_15 = 44000;
			int Middle_Finger_Block_30 = 40000;
			int Middle_Finger_Block_45 = 35000;
			int Middle_Finger_Block_60 = 20000;
			int Middle_Finger_Block_75 = 12000;
			int Middle_Finger_Block_90 = 1500;
			//////////////////////ring finger block definitions//////////////////
			
			
			int Ring_Finger_Block_0  =  55000;
			int Ring_Finger_Block_15 =  50000;
			int Ring_Finger_Block_30 =  45000;
			int Ring_Finger_Block_45 =  42000;
			int Ring_Finger_Block_60 =  30000;
			int Ring_Finger_Block_75 =  23000;
			int Ring_Finger_Block_90 =  18000;
			
			
			/////////////////////pinky block definitions////////////////////
			int Pinky_Finger_Block_0  =  36000;
			int Pinky_Finger_Block_15 =  27000;
			int Pinky_Finger_Block_30 =  15000;
			int Pinky_Finger_Block_45 =  5000;
			int Pinky_Finger_Block_60 =  1000; 
			int Pinky_Finger_Block_75 =  600;
			int Pinky_Finger_Block_90 =  200;
			
			
			/////////////////////////////midddle finger calibration mapping//////////////
			if((dims[2]<Middle_Finger_Block_0)&&(dims[2]>Middle_Finger_Block_15)){
				
				int scale = (Middle_Finger_Block_0-Middle_Finger_Block_15)/15;
				fingers[1] = 15-(dims[2]-Middle_Finger_Block_15)/scale;
				
			}
			if ((dims[2]<Middle_Finger_Block_15)&&(dims[2]>Middle_Finger_Block_30)){
				
				int scale = (Middle_Finger_Block_15-Middle_Finger_Block_30)/15;
				fingers[1] = 30-(dims[2]-Middle_Finger_Block_30)/scale;
				
			}
			if((dims[2]<Middle_Finger_Block_30)&&(dims[2]>Middle_Finger_Block_45)){
				
				
				int scale = (Middle_Finger_Block_30-Middle_Finger_Block_45)/15;
				fingers[1] = 45-(dims[2]-Middle_Finger_Block_45)/scale;
				
			}
			if((dims[2]<Middle_Finger_Block_45)&&(dims[2]>Middle_Finger_Block_60)){
				
				
				int scale = (Middle_Finger_Block_45-Middle_Finger_Block_60)/15;
				fingers[1] = 60-(dims[2]-Middle_Finger_Block_60)/scale;
				
			}
			if((dims[2]<Middle_Finger_Block_60)&&(dims[2]>Middle_Finger_Block_75)){
				
				
				int scale = (Middle_Finger_Block_60-Middle_Finger_Block_75)/15;
				fingers[1] = 75-(dims[2]-Middle_Finger_Block_75)/scale;
				
			}
			if((dims[2]<Middle_Finger_Block_75)&&(dims[2]>Middle_Finger_Block_90)){
				
				int scale = (Middle_Finger_Block_75-Middle_Finger_Block_90)/15;
				fingers[1] = 90-(dims[2]-Middle_Finger_Block_90)/scale;
			}
			///////////////////////////index finger calibration mapping///////////////////////////////////
			if((dims[1]<Index_Finger_Block_0)&&(dims[1]>Index_Finger_Block_15)){
				
				int scale = (Index_Finger_Block_0-Index_Finger_Block_15)/15;
				fingers[0] = 15-(dims[1]-Index_Finger_Block_15)/scale;
				
			}
			if ((dims[1]<Index_Finger_Block_15)&&(dims[1]>Index_Finger_Block_30)){
				
				int scale = (Index_Finger_Block_15-Index_Finger_Block_30)/15;
				fingers[0] = 30-(dims[1]-Index_Finger_Block_30)/scale;
				
			}
			if((dims[1]<Index_Finger_Block_30)&&(dims[1]>Index_Finger_Block_45)){
				
				
				int scale = (Index_Finger_Block_30-Index_Finger_Block_45)/15;
				fingers[0] = 45-(dims[1]-Index_Finger_Block_45)/scale;
				
			}
			if((dims[1]<Index_Finger_Block_45)&&(dims[1]>Index_Finger_Block_60)){
				
				
				int scale = (Index_Finger_Block_45-Index_Finger_Block_60)/15;
				fingers[0] = 60-(dims[1]-Index_Finger_Block_60)/scale;
				
			}
			if((dims[1]<Index_Finger_Block_60)&&(dims[1]>Index_Finger_Block_75)){
				
				
				int scale = (Index_Finger_Block_60-Index_Finger_Block_75)/15;
				fingers[0] = 75-(dims[1]-Index_Finger_Block_75)/scale;
				
			}
			if((dims[1]<Index_Finger_Block_75)&&(dims[1]>Index_Finger_Block_90)){
				
				int scale = (Index_Finger_Block_75-Index_Finger_Block_90)/15;
				fingers[0] = 90-(dims[1]-Index_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////ring finger calibration mapping///////////////////////////////////
			if((dims[3]<Ring_Finger_Block_0)&&(dims[3]>Ring_Finger_Block_15)){
				
				int scale = (Ring_Finger_Block_0-Ring_Finger_Block_15)/15;
				fingers[2] = 15-(dims[3]-Ring_Finger_Block_15)/scale;
				
			}
			if ((dims[3]<Ring_Finger_Block_15)&&(dims[3]>Ring_Finger_Block_30)){
				
				int scale = (Ring_Finger_Block_15-Ring_Finger_Block_30)/15;
				fingers[2] = 30-(dims[3]-Ring_Finger_Block_30)/scale;
				
			}
			if((dims[3]<Ring_Finger_Block_30)&&(dims[3]>Ring_Finger_Block_45)){
				
				
				int scale = (Ring_Finger_Block_30-Ring_Finger_Block_45)/15;
				fingers[2] = 45-(dims[3]-Ring_Finger_Block_45)/scale;
				
			}
			if((dims[3]<Ring_Finger_Block_45)&&(dims[3]>Ring_Finger_Block_60)){
				
				
				int scale = (Ring_Finger_Block_45-Ring_Finger_Block_60)/15;
				fingers[2] = 60-(dims[3]-Ring_Finger_Block_60)/scale;
				
			}
			if((dims[3]<Ring_Finger_Block_60)&&(dims[3]>Ring_Finger_Block_75)){
				
				
				int scale = (Ring_Finger_Block_60-Ring_Finger_Block_75)/15;
				fingers[2] = 75-(dims[3]-Ring_Finger_Block_75)/scale;
				
			}
			if((dims[3]<Ring_Finger_Block_75)&&(dims[3]>Ring_Finger_Block_90)){
				
				int scale = (Ring_Finger_Block_75-Ring_Finger_Block_90)/15;
				fingers[2] = 90-(dims[3]-Ring_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////pinky finger calibration mapping///////////////////////////////////
			if((dims[0]<Pinky_Finger_Block_0)&&(dims[0]>Pinky_Finger_Block_15)){
				
				int scale = (Pinky_Finger_Block_0-Pinky_Finger_Block_15)/15;
				fingers[3] = 15-(dims[0]-Pinky_Finger_Block_15)/scale;
				
			}
			if ((dims[0]<Pinky_Finger_Block_15)&&(dims[0]>Pinky_Finger_Block_30)){
				
				int scale = (Pinky_Finger_Block_15-Pinky_Finger_Block_30)/15;
				fingers[3] = 30-(dims[0]-Pinky_Finger_Block_30)/scale;
				
			}
			if((dims[0]<Pinky_Finger_Block_30)&&(dims[0]>Pinky_Finger_Block_45)){
				
				
				int scale = (Pinky_Finger_Block_30-Pinky_Finger_Block_45)/15;
				fingers[3] = 45-(dims[0]-Pinky_Finger_Block_45)/scale;
				
			}
			if((dims[0]<Pinky_Finger_Block_45)&&(dims[0]>Pinky_Finger_Block_60)){
				
				
				int scale = (Pinky_Finger_Block_45-Pinky_Finger_Block_60)/15;
				fingers[3] = 60-(dims[0]-Pinky_Finger_Block_60)/scale;
				
			}
			if((dims[0]<Pinky_Finger_Block_60)&&(dims[0]>Pinky_Finger_Block_75)){
				
				
				int scale = (Pinky_Finger_Block_60-Pinky_Finger_Block_75)/15;
				fingers[3] = 75-(dims[0]-Pinky_Finger_Block_75)/scale;
				
			}
			if((dims[0]<Pinky_Finger_Block_75)&&(dims[0]>Pinky_Finger_Block_90)){
				
				int scale = (Pinky_Finger_Block_75-Pinky_Finger_Block_90)/15;
				fingers[3] = 90-(dims[0]-Pinky_Finger_Block_90)/scale;
			}
			
			// Update the readings on the display!
			readings.text = "Finger 0: " + fingers[0] +
				"\nFinger 1: " + fingers[1] +
					"\nFinger 2: " + fingers[2] +
					"\nFinger 3: " + fingers[3];
			
		} catch (Exception e) {
			errorcounter++;
			Debug.Log("Couldn't update fingers: "+errorcounter + e.StackTrace);
		}
		
		
	}
	
	float [] stringArrayToFloatArrary(string [] array) {
		/* Convert an array of strings to array of floats */
		float [] floatArray = new float [array.Length];
		float num;
		
		for (int i = 0; i < array.Length; i++) {
			num = float.Parse(array[i]);
			floatArray[i] = num;
		}
		
		return floatArray;
	}
	
	
	string [] readSelectLines(string filePath, int numToRead = 4) {
		/* Read the specified number of lines from a file starting with the first line.  This function
		 * returns an array of strings, indexed or each line in the file.
		 *
		 *@ param linesToRead: Number of lines to read from file starting at top
		 */
		string line;
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
		}
		
		return readLines;
	}
}



