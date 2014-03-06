using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Models : MonoBehaviour {
	
	static public float[] fingers = new float[4];
	static public float[] accelerometer = new float[3];
	private string [] readLines = new string[7];
	// Path to file with data for each finger
	private string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\testfile.txt");
	public GUIText readings;

	private GloveReader reader;

	int errorcounter = 0;
	
	
	void Start() {
		/* Initialization */
		reader = new GloveReader();
	}
	
	void Update() {
		/* Updates every frame */
		try {
			float [] dims = reader.getValues();
			// accelerometer (0, 1, 2) --> (x, y, z)
			accelerometer[0] = dims[4];
			accelerometer[1] = dims[5];
			accelerometer[2] = dims[6];
			/* Scale text file values */
			/*
			fingers[0] = (dims[0] - 2000) / 3;
			fingers[1] = (dims[1] - 2000) / 3;
			fingers[2] = (dims[2] - 2000) / 3;
			fingers[3] = (dims[3] - 2000) / 3;
			*/
			////////////////////////index block definitions//////////////////
			
			int Index_Finger_Block_0  = reader.fingerZones[0];
			int Index_Finger_Block_15 = reader.fingerZones[1];
			int Index_Finger_Block_30 = reader.fingerZones[2];
			int Index_Finger_Block_45 = reader.fingerZones[3];
			int Index_Finger_Block_60 = reader.fingerZones[4];	
			int Index_Finger_Block_75 = reader.fingerZones[5];
			int Index_Finger_Block_90 = reader.fingerZones[6];	
			
			
			////////////////////////middle finger block definitions//////////////
			int Middle_Finger_Block_0  = reader.fingerZones[7];
			int Middle_Finger_Block_15 = reader.fingerZones[8];
			int Middle_Finger_Block_30 = reader.fingerZones[9];
			int Middle_Finger_Block_45 = reader.fingerZones[10];
			int Middle_Finger_Block_60 = reader.fingerZones[11];
			int Middle_Finger_Block_75 = reader.fingerZones[12];
			int Middle_Finger_Block_90 = reader.fingerZones[13];
			//////////////////////ring finger block definitions//////////////////
			
			
			int Ring_Finger_Block_0  =  reader.fingerZones[14];
			int Ring_Finger_Block_15 =  reader.fingerZones[15];
			int Ring_Finger_Block_30 =  reader.fingerZones[16];
			int Ring_Finger_Block_45 =  reader.fingerZones[17];
			int Ring_Finger_Block_60 =  reader.fingerZones[18];
			int Ring_Finger_Block_75 =  reader.fingerZones[19];
			int Ring_Finger_Block_90 =  reader.fingerZones[20];
			
			
			/////////////////////pinky block definitions////////////////////
			int Pinky_Finger_Block_0  =  reader.fingerZones[21];
			int Pinky_Finger_Block_15 =  reader.fingerZones[22];
			int Pinky_Finger_Block_30 =  reader.fingerZones[23];
			int Pinky_Finger_Block_45 =  reader.fingerZones[24];
			int Pinky_Finger_Block_60 =  reader.fingerZones[25]; 
			int Pinky_Finger_Block_75 =  reader.fingerZones[26];
			int Pinky_Finger_Block_90 =  reader.fingerZones[27];
			
			
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

			/*DEBUG: Print out the current value of our fingers */
			Debug.Log("Fingers: " +
			          "\n0: " + fingers[0] +
			          "\n1: " + fingers[1] + 
			          "\n2: " + fingers[2] + 
			          "\n3: " + fingers[3]);

			// Update the readings on the display!
			readings.text = 
				"Finger 0: " + fingers[0] +
				"\nFinger 1: " + fingers[1] +
				"\nFinger 2: " + fingers[2] +
				"\nFinger 3: " + fingers[3] +
				"\nACEL_X: " + accelerometer[0] +
				"\nACEL_Y: " + accelerometer[1] +
				"\nACEL_Z: " + accelerometer[2];
			
		} catch (Exception e) {
			errorcounter++;
			//Debug.Log("Couldn't update fingers: "+errorcounter + e.ToString() + e.StackTrace);
		}
	}
}



