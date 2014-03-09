using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Models : MonoBehaviour {
	
	static public float[] fingers = new float[8];
	static public float[] accelerometer = new float[3];
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

			////////////////////////Right_Index block definitions/////////////////////
			int Right_Index_Finger_Block_0  = reader.rightFingerZones[0];
			int Right_Index_Finger_Block_15 = reader.rightFingerZones[1];
			int Right_Index_Finger_Block_30 = reader.rightFingerZones[2];
			int Right_Index_Finger_Block_45 = reader.rightFingerZones[3];
			int Right_Index_Finger_Block_60 = reader.rightFingerZones[4];	
			int Right_Index_Finger_Block_75 = reader.rightFingerZones[5];
			int Right_Index_Finger_Block_90 = reader.rightFingerZones[6];	
			
			
			////////////////////////Right_Middle finger block definitions//////////////
			int Right_Middle_Finger_Block_0  = reader.rightFingerZones[7];
			int Right_Middle_Finger_Block_15 = reader.rightFingerZones[8];
			int Right_Middle_Finger_Block_30 = reader.rightFingerZones[9];
			int Right_Middle_Finger_Block_45 = reader.rightFingerZones[10];
			int Right_Middle_Finger_Block_60 = reader.rightFingerZones[11];
			int Right_Middle_Finger_Block_75 = reader.rightFingerZones[12];
			int Right_Middle_Finger_Block_90 = reader.rightFingerZones[13];

			//////////////////////Right_Ring finger block definitions//////////////////
			int Right_Ring_Finger_Block_0  =  reader.rightFingerZones[14];
			int Right_Ring_Finger_Block_15 =  reader.rightFingerZones[15];
			int Right_Ring_Finger_Block_30 =  reader.rightFingerZones[16];
			int Right_Ring_Finger_Block_45 =  reader.rightFingerZones[17];
			int Right_Ring_Finger_Block_60 =  reader.rightFingerZones[18];
			int Right_Ring_Finger_Block_75 =  reader.rightFingerZones[19];
			int Right_Ring_Finger_Block_90 =  reader.rightFingerZones[20];
			
			
			/////////////////////Right_Pinky block definitions////////////////////
			int Right_Pinky_Finger_Block_0  =  reader.rightFingerZones[21];
			int Right_Pinky_Finger_Block_15 =  reader.rightFingerZones[22];
			int Right_Pinky_Finger_Block_30 =  reader.rightFingerZones[23];
			int Right_Pinky_Finger_Block_45 =  reader.rightFingerZones[24];
			int Right_Pinky_Finger_Block_60 =  reader.rightFingerZones[25]; 
			int Right_Pinky_Finger_Block_75 =  reader.rightFingerZones[26];
			int Right_Pinky_Finger_Block_90 =  reader.rightFingerZones[27];

			///////////////////////Left_Index block definitions/////////////////////
			int Left_Index_Finger_Block_0  = reader.leftFingerZones[0];
			int Left_Index_Finger_Block_15 = reader.leftFingerZones[1];
			int Left_Index_Finger_Block_30 = reader.leftFingerZones[2];
			int Left_Index_Finger_Block_45 = reader.leftFingerZones[3];
			int Left_Index_Finger_Block_60 = reader.leftFingerZones[4];	
			int Left_Index_Finger_Block_75 = reader.leftFingerZones[5];
			int Left_Index_Finger_Block_90 = reader.leftFingerZones[6];	
			
			
			////////////////////////Left_Middle finger block definitions//////////////
			int Left_Middle_Finger_Block_0  = reader.leftFingerZones[7];
			int Left_Middle_Finger_Block_15 = reader.leftFingerZones[8];
			int Left_Middle_Finger_Block_30 = reader.leftFingerZones[9];
			int Left_Middle_Finger_Block_45 = reader.leftFingerZones[10];
			int Left_Middle_Finger_Block_60 = reader.leftFingerZones[11];
			int Left_Middle_Finger_Block_75 = reader.leftFingerZones[12];
			int Left_Middle_Finger_Block_90 = reader.leftFingerZones[13];
			
			//////////////////////Left_Ring finger block definitions//////////////////
			int Left_Ring_Finger_Block_0  =  reader.leftFingerZones[14];
			int Left_Ring_Finger_Block_15 =  reader.leftFingerZones[15];
			int Left_Ring_Finger_Block_30 =  reader.leftFingerZones[16];
			int Left_Ring_Finger_Block_45 =  reader.leftFingerZones[17];
			int Left_Ring_Finger_Block_60 =  reader.leftFingerZones[18];
			int Left_Ring_Finger_Block_75 =  reader.leftFingerZones[19];
			int Left_Ring_Finger_Block_90 =  reader.leftFingerZones[20];
			
			
			/////////////////////Left_Pinky block definitions////////////////////
			int Left_Pinky_Finger_Block_0  =  reader.leftFingerZones[21];
			int Left_Pinky_Finger_Block_15 =  reader.leftFingerZones[22];
			int Left_Pinky_Finger_Block_30 =  reader.leftFingerZones[23];
			int Left_Pinky_Finger_Block_45 =  reader.leftFingerZones[24];
			int Left_Pinky_Finger_Block_60 =  reader.leftFingerZones[25]; 
			int Left_Pinky_Finger_Block_75 =  reader.leftFingerZones[26];
			int Left_Pinky_Finger_Block_90 =  reader.leftFingerZones[27];
			
			
			/////////////////////////////midddle finger calibration mapping//////////////
			if((dims[2]<Right_Middle_Finger_Block_0)&&(dims[2]>Right_Middle_Finger_Block_15)){
				
				int scale = (Right_Middle_Finger_Block_0-Right_Middle_Finger_Block_15)/15;
				fingers[1] = 15-(dims[2]-Right_Middle_Finger_Block_15)/scale;
				
			}
			if ((dims[2]<Right_Middle_Finger_Block_15)&&(dims[2]>Right_Middle_Finger_Block_30)){
				
				int scale = (Right_Middle_Finger_Block_15-Right_Middle_Finger_Block_30)/15;
				fingers[1] = 30-(dims[2]-Right_Middle_Finger_Block_30)/scale;
				
			}
			if((dims[2]<Right_Middle_Finger_Block_30)&&(dims[2]>Right_Middle_Finger_Block_45)){
				
				
				int scale = (Right_Middle_Finger_Block_30-Right_Middle_Finger_Block_45)/15;
				fingers[1] = 45-(dims[2]-Right_Middle_Finger_Block_45)/scale;
				
			}
			if((dims[2]<Right_Middle_Finger_Block_45)&&(dims[2]>Right_Middle_Finger_Block_60)){
				
				
				int scale = (Right_Middle_Finger_Block_45-Right_Middle_Finger_Block_60)/15;
				fingers[1] = 60-(dims[2]-Right_Middle_Finger_Block_60)/scale;
				
			}
			if((dims[2]<Right_Middle_Finger_Block_60)&&(dims[2]>Right_Middle_Finger_Block_75)){
				
				
				int scale = (Right_Middle_Finger_Block_60-Right_Middle_Finger_Block_75)/15;
				fingers[1] = 75-(dims[2]-Right_Middle_Finger_Block_75)/scale;
				
			}
			if((dims[2]<Right_Middle_Finger_Block_75)&&(dims[2]>Right_Middle_Finger_Block_90)){
				
				int scale = (Right_Middle_Finger_Block_75-Right_Middle_Finger_Block_90)/15;
				fingers[1] = 90-(dims[2]-Right_Middle_Finger_Block_90)/scale;
			}
			///////////////////////////Right_Index finger calibration mapping///////////////////////////////////
			if((dims[1]<Right_Index_Finger_Block_0)&&(dims[1]>Right_Index_Finger_Block_15)){
				
				int scale = (Right_Index_Finger_Block_0-Right_Index_Finger_Block_15)/15;
				fingers[0] = 15-(dims[1]-Right_Index_Finger_Block_15)/scale;
				
			}
			if ((dims[1]<Right_Index_Finger_Block_15)&&(dims[1]>Right_Index_Finger_Block_30)){
				
				int scale = (Right_Index_Finger_Block_15-Right_Index_Finger_Block_30)/15;
				fingers[0] = 30-(dims[1]-Right_Index_Finger_Block_30)/scale;
				
			}
			if((dims[1]<Right_Index_Finger_Block_30)&&(dims[1]>Right_Index_Finger_Block_45)){
				
				
				int scale = (Right_Index_Finger_Block_30-Right_Index_Finger_Block_45)/15;
				fingers[0] = 45-(dims[1]-Right_Index_Finger_Block_45)/scale;
				
			}
			if((dims[1]<Right_Index_Finger_Block_45)&&(dims[1]>Right_Index_Finger_Block_60)){
				
				
				int scale = (Right_Index_Finger_Block_45-Right_Index_Finger_Block_60)/15;
				fingers[0] = 60-(dims[1]-Right_Index_Finger_Block_60)/scale;
				
			}
			if((dims[1]<Right_Index_Finger_Block_60)&&(dims[1]>Right_Index_Finger_Block_75)){
				
				
				int scale = (Right_Index_Finger_Block_60-Right_Index_Finger_Block_75)/15;
				fingers[0] = 75-(dims[1]-Right_Index_Finger_Block_75)/scale;
				
			}
			if((dims[1]<Right_Index_Finger_Block_75)&&(dims[1]>Right_Index_Finger_Block_90)){
				
				int scale = (Right_Index_Finger_Block_75-Right_Index_Finger_Block_90)/15;
				fingers[0] = 90-(dims[1]-Right_Index_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Right_Ring finger calibration mapping///////////////////////////////////
			if((dims[3]<Right_Ring_Finger_Block_0)&&(dims[3]>Right_Ring_Finger_Block_15)){
				
				int scale = (Right_Ring_Finger_Block_0-Right_Ring_Finger_Block_15)/15;
				fingers[2] = 15-(dims[3]-Right_Ring_Finger_Block_15)/scale;
				
			}
			if ((dims[3]<Right_Ring_Finger_Block_15)&&(dims[3]>Right_Ring_Finger_Block_30)){
				
				int scale = (Right_Ring_Finger_Block_15-Right_Ring_Finger_Block_30)/15;
				fingers[2] = 30-(dims[3]-Right_Ring_Finger_Block_30)/scale;
				
			}
			if((dims[3]<Right_Ring_Finger_Block_30)&&(dims[3]>Right_Ring_Finger_Block_45)){
				
				
				int scale = (Right_Ring_Finger_Block_30-Right_Ring_Finger_Block_45)/15;
				fingers[2] = 45-(dims[3]-Right_Ring_Finger_Block_45)/scale;
				
			}
			if((dims[3]<Right_Ring_Finger_Block_45)&&(dims[3]>Right_Ring_Finger_Block_60)){
				
				
				int scale = (Right_Ring_Finger_Block_45-Right_Ring_Finger_Block_60)/15;
				fingers[2] = 60-(dims[3]-Right_Ring_Finger_Block_60)/scale;
				
			}
			if((dims[3]<Right_Ring_Finger_Block_60)&&(dims[3]>Right_Ring_Finger_Block_75)){
				
				
				int scale = (Right_Ring_Finger_Block_60-Right_Ring_Finger_Block_75)/15;
				fingers[2] = 75-(dims[3]-Right_Ring_Finger_Block_75)/scale;
				
			}
			if((dims[3]<Right_Ring_Finger_Block_75)&&(dims[3]>Right_Ring_Finger_Block_90)){
				
				int scale = (Right_Ring_Finger_Block_75-Right_Ring_Finger_Block_90)/15;
				fingers[2] = 90-(dims[3]-Right_Ring_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Right_Pinky finger calibration mapping///////////////////////////////////
			if((dims[0]<Right_Pinky_Finger_Block_0)&&(dims[0]>Right_Pinky_Finger_Block_15)){
				
				int scale = (Right_Pinky_Finger_Block_0-Right_Pinky_Finger_Block_15)/15;
				fingers[3] = 15-(dims[0]-Right_Pinky_Finger_Block_15)/scale;
				
			}
			if ((dims[0]<Right_Pinky_Finger_Block_15)&&(dims[0]>Right_Pinky_Finger_Block_30)){
				
				int scale = (Right_Pinky_Finger_Block_15-Right_Pinky_Finger_Block_30)/15;
				fingers[3] = 30-(dims[0]-Right_Pinky_Finger_Block_30)/scale;
				
			}
			if((dims[0]<Right_Pinky_Finger_Block_30)&&(dims[0]>Right_Pinky_Finger_Block_45)){
				
				
				int scale = (Right_Pinky_Finger_Block_30-Right_Pinky_Finger_Block_45)/15;
				fingers[3] = 45-(dims[0]-Right_Pinky_Finger_Block_45)/scale;
				
			}
			if((dims[0]<Right_Pinky_Finger_Block_45)&&(dims[0]>Right_Pinky_Finger_Block_60)){
				
				
				int scale = (Right_Pinky_Finger_Block_45-Right_Pinky_Finger_Block_60)/15;
				fingers[3] = 60-(dims[0]-Right_Pinky_Finger_Block_60)/scale;
				
			}
			if((dims[0]<Right_Pinky_Finger_Block_60)&&(dims[0]>Right_Pinky_Finger_Block_75)){
				
				
				int scale = (Right_Pinky_Finger_Block_60-Right_Pinky_Finger_Block_75)/15;
				fingers[3] = 75-(dims[0]-Right_Pinky_Finger_Block_75)/scale;
				
			}
			if((dims[0]<Right_Pinky_Finger_Block_75)&&(dims[0]>Right_Pinky_Finger_Block_90)){
				
				int scale = (Right_Pinky_Finger_Block_75-Right_Pinky_Finger_Block_90)/15;
				fingers[3] = 90-(dims[0]-Right_Pinky_Finger_Block_90)/scale;
			}

			/********************************************************************************************/
			/////////////////////////////midddle finger calibration mapping//////////////
			if((dims[2]<Left_Middle_Finger_Block_0)&&(dims[2]>Left_Middle_Finger_Block_15)){
				
				int scale = (Left_Middle_Finger_Block_0-Left_Middle_Finger_Block_15)/15;
				fingers[5] = 15-(dims[2]-Left_Middle_Finger_Block_15)/scale;
				
			}
			if ((dims[2]<Left_Middle_Finger_Block_15)&&(dims[2]>Left_Middle_Finger_Block_30)){
				
				int scale = (Left_Middle_Finger_Block_15-Left_Middle_Finger_Block_30)/15;
				fingers[5] = 30-(dims[2]-Left_Middle_Finger_Block_30)/scale;
				
			}
			if((dims[2]<Left_Middle_Finger_Block_30)&&(dims[2]>Left_Middle_Finger_Block_45)){
				
				
				int scale = (Left_Middle_Finger_Block_30-Left_Middle_Finger_Block_45)/15;
				fingers[5] = 45-(dims[2]-Left_Middle_Finger_Block_45)/scale;
				
			}
			if((dims[2]<Left_Middle_Finger_Block_45)&&(dims[2]>Left_Middle_Finger_Block_60)){
				
				
				int scale = (Left_Middle_Finger_Block_45-Left_Middle_Finger_Block_60)/15;
				fingers[5] = 60-(dims[2]-Left_Middle_Finger_Block_60)/scale;
				
			}
			if((dims[2]<Left_Middle_Finger_Block_60)&&(dims[2]>Left_Middle_Finger_Block_75)){
				
				
				int scale = (Left_Middle_Finger_Block_60-Left_Middle_Finger_Block_75)/15;
				fingers[5] = 75-(dims[2]-Left_Middle_Finger_Block_75)/scale;
				
			}
			if((dims[2]<Left_Middle_Finger_Block_75)&&(dims[2]>Left_Middle_Finger_Block_90)){
				
				int scale = (Left_Middle_Finger_Block_75-Left_Middle_Finger_Block_90)/15;
				fingers[5] = 90-(dims[2]-Left_Middle_Finger_Block_90)/scale;
			}
			///////////////////////////Left_Index finger calibration mapping///////////////////////////////////
			if((dims[1]<Left_Index_Finger_Block_0)&&(dims[1]>Left_Index_Finger_Block_15)){
				
				int scale = (Left_Index_Finger_Block_0-Left_Index_Finger_Block_15)/15;
				fingers[4] = 15-(dims[1]-Left_Index_Finger_Block_15)/scale;
				
			}
			if ((dims[1]<Left_Index_Finger_Block_15)&&(dims[1]>Left_Index_Finger_Block_30)){
				
				int scale = (Left_Index_Finger_Block_15-Left_Index_Finger_Block_30)/15;
				fingers[4] = 30-(dims[1]-Left_Index_Finger_Block_30)/scale;
				
			}
			if((dims[1]<Left_Index_Finger_Block_30)&&(dims[1]>Left_Index_Finger_Block_45)){
				
				
				int scale = (Left_Index_Finger_Block_30-Left_Index_Finger_Block_45)/15;
				fingers[4] = 45-(dims[1]-Left_Index_Finger_Block_45)/scale;
				
			}
			if((dims[1]<Left_Index_Finger_Block_45)&&(dims[1]>Left_Index_Finger_Block_60)){
				
				
				int scale = (Left_Index_Finger_Block_45-Left_Index_Finger_Block_60)/15;
				fingers[4] = 60-(dims[1]-Left_Index_Finger_Block_60)/scale;
				
			}
			if((dims[1]<Left_Index_Finger_Block_60)&&(dims[1]>Left_Index_Finger_Block_75)){
				
				
				int scale = (Left_Index_Finger_Block_60-Left_Index_Finger_Block_75)/15;
				fingers[4] = 75-(dims[1]-Left_Index_Finger_Block_75)/scale;
				
			}
			if((dims[1]<Left_Index_Finger_Block_75)&&(dims[1]>Left_Index_Finger_Block_90)){
				
				int scale = (Left_Index_Finger_Block_75-Left_Index_Finger_Block_90)/15;
				fingers[4] = 90-(dims[1]-Left_Index_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Left_Ring finger calibration mapping///////////////////////////////////
			if((dims[3]<Left_Ring_Finger_Block_0)&&(dims[3]>Left_Ring_Finger_Block_15)){
				
				int scale = (Left_Ring_Finger_Block_0-Left_Ring_Finger_Block_15)/15;
				fingers[6] = 15-(dims[3]-Left_Ring_Finger_Block_15)/scale;
				
			}
			if ((dims[3]<Left_Ring_Finger_Block_15)&&(dims[3]>Left_Ring_Finger_Block_30)){
				
				int scale = (Left_Ring_Finger_Block_15-Left_Ring_Finger_Block_30)/15;
				fingers[6] = 30-(dims[3]-Left_Ring_Finger_Block_30)/scale;
				
			}
			if((dims[3]<Left_Ring_Finger_Block_30)&&(dims[3]>Left_Ring_Finger_Block_45)){
				
				
				int scale = (Left_Ring_Finger_Block_30-Left_Ring_Finger_Block_45)/15;
				fingers[6] = 45-(dims[3]-Left_Ring_Finger_Block_45)/scale;
				
			}
			if((dims[3]<Left_Ring_Finger_Block_45)&&(dims[3]>Left_Ring_Finger_Block_60)){
				
				
				int scale = (Left_Ring_Finger_Block_45-Left_Ring_Finger_Block_60)/15;
				fingers[6] = 60-(dims[3]-Left_Ring_Finger_Block_60)/scale;
				
			}
			if((dims[3]<Left_Ring_Finger_Block_60)&&(dims[3]>Left_Ring_Finger_Block_75)){
				
				
				int scale = (Left_Ring_Finger_Block_60-Left_Ring_Finger_Block_75)/15;
				fingers[6] = 75-(dims[3]-Left_Ring_Finger_Block_75)/scale;
				
			}
			if((dims[3]<Left_Ring_Finger_Block_75)&&(dims[3]>Left_Ring_Finger_Block_90)){
				
				int scale = (Left_Ring_Finger_Block_75-Left_Ring_Finger_Block_90)/15;
				fingers[6] = 90-(dims[3]-Left_Ring_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Left_Pinky finger calibration mapping///////////////////////////////////
			if((dims[0]<Left_Pinky_Finger_Block_0)&&(dims[0]>Left_Pinky_Finger_Block_15)){
				
				int scale = (Left_Pinky_Finger_Block_0-Left_Pinky_Finger_Block_15)/15;
				fingers[7] = 15-(dims[0]-Left_Pinky_Finger_Block_15)/scale;
				
			}
			if ((dims[0]<Left_Pinky_Finger_Block_15)&&(dims[0]>Left_Pinky_Finger_Block_30)){
				
				int scale = (Left_Pinky_Finger_Block_15-Left_Pinky_Finger_Block_30)/15;
				fingers[7] = 30-(dims[0]-Left_Pinky_Finger_Block_30)/scale;
				
			}
			if((dims[0]<Left_Pinky_Finger_Block_30)&&(dims[0]>Left_Pinky_Finger_Block_45)){
				
				
				int scale = (Left_Pinky_Finger_Block_30-Left_Pinky_Finger_Block_45)/15;
				fingers[7] = 45-(dims[0]-Left_Pinky_Finger_Block_45)/scale;
				
			}
			if((dims[0]<Left_Pinky_Finger_Block_45)&&(dims[0]>Left_Pinky_Finger_Block_60)){
				
				
				int scale = (Left_Pinky_Finger_Block_45-Left_Pinky_Finger_Block_60)/15;
				fingers[7] = 60-(dims[0]-Left_Pinky_Finger_Block_60)/scale;
				
			}
			if((dims[0]<Left_Pinky_Finger_Block_60)&&(dims[0]>Left_Pinky_Finger_Block_75)){
				
				
				int scale = (Left_Pinky_Finger_Block_60-Left_Pinky_Finger_Block_75)/15;
				fingers[7] = 75-(dims[0]-Left_Pinky_Finger_Block_75)/scale;
				
			}
			if((dims[0]<Left_Pinky_Finger_Block_75)&&(dims[0]>Left_Pinky_Finger_Block_90)){
				
				int scale = (Left_Pinky_Finger_Block_75-Left_Pinky_Finger_Block_90)/15;
				fingers[7] = 90-(dims[0]-Left_Pinky_Finger_Block_90)/scale;
			}
			/********************************************************************************************/
			/*DEBUG: Print out the current value of our fingers */
			Debug.Log("Fingers: " +
			          "\n0: " + fingers[0] +
			          "\n1: " + fingers[1] + 
			          "\n2: " + fingers[2] + 
			          "\n2: " + fingers[3] +
			          "\n2: " + fingers[4] +
			          "\n2: " + fingers[5] +
			          "\n2: " + fingers[6] +
			          "\n3: " + fingers[7]);

			// Update the readings on the display!
			readings.text = 
				"Finger 0: " + fingers[0] +
				"\nFinger 1: " + fingers[1] +
				"\nFinger 2: " + fingers[2] +
				"\nFinger 3: " + fingers[3] +
				"\nFinger 1: " + fingers[4] +
				"\nFinger 2: " + fingers[5] +
				"\nFinger 3: " + fingers[6] +
				"\nFinger 3: " + fingers[7] +
				"\nACEL_X: " + accelerometer[0] +
				"\nACEL_Y: " + accelerometer[1] +
				"\nACEL_Z: " + accelerometer[2];
			
		} catch (Exception e) {
			errorcounter++;
			//Debug.Log("Couldn't update fingers: "+errorcounter + e.ToStRight_Ring() + e.StackTrace);
		}
	}
}



