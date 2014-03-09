using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Models : MonoBehaviour {
	
	static public float[] fingers = new float[8];
	static public float[] accelerometer = new float[3];

	private GloveReader reader;
	// Which fingers are represented by lines in the text file
	private int rightIndexFingerIndex = 1;
	private int rightMiddleFingerIndex = 2;
	private int rightRingFingerIndex = 3;
	private int rightPinkyFingerIndex = 0;
	private int leftIndexFingerIndex = 8;
	private int leftMiddleFingerIndex = 9;
	private int leftRingFingerIndex = 10;
	private int leftPinkyFingerIndex = 7;

	int errorcounter = 0;
	
	
	void Start() {
		/* Initialization */
		reader = new GloveReader();
	}
	
	void Update() {
		/* Updates every frame */
		try {
			float [] dims = reader.getValues();
			// DEBUG: Show all data coming from the txt file
			/*Debug.Log("Here are raw text file values starting from line 1: \n" +
			          dims[0] + "\n" +
			          dims[1] + "\n" +
			          dims[2] + "\n" +
			          dims[3] + "\n" +
			          dims[4] + "\n" +
			          dims[5] + "\n" +
			          dims[6] + "\n" +
			          dims[7] + "\n" +
			          dims[8] + "\n" +
			          dims[9] + "\n" +
			          dims[10] + "\n");
			*/
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
			if((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_0)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_15)){
				
				int scale = (Right_Middle_Finger_Block_0-Right_Middle_Finger_Block_15)/15;
				fingers[1] = 15-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_15)/scale;
				
			}
			if ((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_15)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_30)){
				
				int scale = (Right_Middle_Finger_Block_15-Right_Middle_Finger_Block_30)/15;
				fingers[1] = 30-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_30)/scale;
				
			}
			if((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_30)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_45)){
				
				
				int scale = (Right_Middle_Finger_Block_30-Right_Middle_Finger_Block_45)/15;
				fingers[1] = 45-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_45)/scale;
				
			}
			if((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_45)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_60)){
				
				
				int scale = (Right_Middle_Finger_Block_45-Right_Middle_Finger_Block_60)/15;
				fingers[1] = 60-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_60)/scale;
				
			}
			if((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_60)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_75)){
				
				
				int scale = (Right_Middle_Finger_Block_60-Right_Middle_Finger_Block_75)/15;
				fingers[1] = 75-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_75)/scale;
				
			}
			if((dims[rightMiddleFingerIndex]<Right_Middle_Finger_Block_75)&&(dims[rightMiddleFingerIndex]>Right_Middle_Finger_Block_90)){
				
				int scale = (Right_Middle_Finger_Block_75-Right_Middle_Finger_Block_90)/15;
				fingers[1] = 90-(dims[rightMiddleFingerIndex]-Right_Middle_Finger_Block_90)/scale;
			}
			///////////////////////////Right_Index finger calibration mapping///////////////////////////////////
			if((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_0)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_15)){
				
				int scale = (Right_Index_Finger_Block_0-Right_Index_Finger_Block_15)/15;
				fingers[0] = 15-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_15)/scale;
				
			}
			if ((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_15)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_30)){
				
				int scale = (Right_Index_Finger_Block_15-Right_Index_Finger_Block_30)/15;
				fingers[0] = 30-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_30)/scale;
				
			}
			if((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_30)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_45)){
				
				
				int scale = (Right_Index_Finger_Block_30-Right_Index_Finger_Block_45)/15;
				fingers[0] = 45-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_45)/scale;
				
			}
			if((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_45)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_60)){
				
				
				int scale = (Right_Index_Finger_Block_45-Right_Index_Finger_Block_60)/15;
				fingers[0] = 60-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_60)/scale;
				
			}
			if((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_60)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_75)){
				
				
				int scale = (Right_Index_Finger_Block_60-Right_Index_Finger_Block_75)/15;
				fingers[0] = 75-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_75)/scale;
				
			}
			if((dims[rightIndexFingerIndex]<Right_Index_Finger_Block_75)&&(dims[rightIndexFingerIndex]>Right_Index_Finger_Block_90)){
				
				int scale = (Right_Index_Finger_Block_75-Right_Index_Finger_Block_90)/15;
				fingers[0] = 90-(dims[rightIndexFingerIndex]-Right_Index_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Right_Ring finger calibration mapping///////////////////////////////////
			if((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_0)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_15)){
				
				int scale = (Right_Ring_Finger_Block_0-Right_Ring_Finger_Block_15)/15;
				fingers[2] = 15-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_15)/scale;
				
			}
			if ((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_15)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_30)){
				
				int scale = (Right_Ring_Finger_Block_15-Right_Ring_Finger_Block_30)/15;
				fingers[2] = 30-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_30)/scale;
				
			}
			if((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_30)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_45)){
				
				
				int scale = (Right_Ring_Finger_Block_30-Right_Ring_Finger_Block_45)/15;
				fingers[2] = 45-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_45)/scale;
				
			}
			if((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_45)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_60)){
				
				
				int scale = (Right_Ring_Finger_Block_45-Right_Ring_Finger_Block_60)/15;
				fingers[2] = 60-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_60)/scale;
				
			}
			if((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_60)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_75)){
				
				
				int scale = (Right_Ring_Finger_Block_60-Right_Ring_Finger_Block_75)/15;
				fingers[2] = 75-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_75)/scale;
				
			}
			if((dims[rightRingFingerIndex]<Right_Ring_Finger_Block_75)&&(dims[rightRingFingerIndex]>Right_Ring_Finger_Block_90)){
				
				int scale = (Right_Ring_Finger_Block_75-Right_Ring_Finger_Block_90)/15;
				fingers[2] = 90-(dims[rightRingFingerIndex]-Right_Ring_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Right_Pinky finger calibration mapping///////////////////////////////////
			if((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_0)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_15)){
				
				int scale = (Right_Pinky_Finger_Block_0-Right_Pinky_Finger_Block_15)/15;
				fingers[3] = 15-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_15)/scale;
				
			}
			if ((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_15)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_30)){
				
				int scale = (Right_Pinky_Finger_Block_15-Right_Pinky_Finger_Block_30)/15;
				fingers[3] = 30-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_30)/scale;
				
			}
			if((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_30)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_45)){
				
				
				int scale = (Right_Pinky_Finger_Block_30-Right_Pinky_Finger_Block_45)/15;
				fingers[3] = 45-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_45)/scale;
				
			}
			if((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_45)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_60)){
				
				
				int scale = (Right_Pinky_Finger_Block_45-Right_Pinky_Finger_Block_60)/15;
				fingers[3] = 60-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_60)/scale;
				
			}
			if((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_60)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_75)){
				
				
				int scale = (Right_Pinky_Finger_Block_60-Right_Pinky_Finger_Block_75)/15;
				fingers[3] = 75-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_75)/scale;
				
			}
			if((dims[rightPinkyFingerIndex]<Right_Pinky_Finger_Block_75)&&(dims[rightPinkyFingerIndex]>Right_Pinky_Finger_Block_90)){
				
				int scale = (Right_Pinky_Finger_Block_75-Right_Pinky_Finger_Block_90)/15;
				fingers[3] = 90-(dims[rightPinkyFingerIndex]-Right_Pinky_Finger_Block_90)/scale;
			}

			/********************************************************************************************/
			/////////////////////////////midddle finger calibration mapping//////////////
			if((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_0)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_15)){
				
				int scale = (Left_Middle_Finger_Block_0-Left_Middle_Finger_Block_15)/15;
				fingers[5] = 15-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_15)/scale;
				
			}
			if ((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_15)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_30)){
				
				int scale = (Left_Middle_Finger_Block_15-Left_Middle_Finger_Block_30)/15;
				fingers[5] = 30-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_30)/scale;
				
			}
			if((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_30)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_45)){
				
				
				int scale = (Left_Middle_Finger_Block_30-Left_Middle_Finger_Block_45)/15;
				fingers[5] = 45-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_45)/scale;
				
			}
			if((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_45)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_60)){
				
				
				int scale = (Left_Middle_Finger_Block_45-Left_Middle_Finger_Block_60)/15;
				fingers[5] = 60-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_60)/scale;
				
			}
			if((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_60)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_75)){
				
				
				int scale = (Left_Middle_Finger_Block_60-Left_Middle_Finger_Block_75)/15;
				fingers[5] = 75-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_75)/scale;
				
			}
			if((dims[leftMiddleFingerIndex]<Left_Middle_Finger_Block_75)&&(dims[leftMiddleFingerIndex]>Left_Middle_Finger_Block_90)){
				
				int scale = (Left_Middle_Finger_Block_75-Left_Middle_Finger_Block_90)/15;
				fingers[5] = 90-(dims[leftMiddleFingerIndex]-Left_Middle_Finger_Block_90)/scale;
			}
			///////////////////////////Left_Index finger calibration mapping///////////////////////////////////
			if((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_0)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_15)){
				
				int scale = (Left_Index_Finger_Block_0-Left_Index_Finger_Block_15)/15;
				fingers[4] = 15-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_15)/scale;
				
			}
			if ((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_15)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_30)){
				
				int scale = (Left_Index_Finger_Block_15-Left_Index_Finger_Block_30)/15;
				fingers[4] = 30-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_30)/scale;
				
			}
			if((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_30)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_45)){
				
				
				int scale = (Left_Index_Finger_Block_30-Left_Index_Finger_Block_45)/15;
				fingers[4] = 45-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_45)/scale;
				
			}
			if((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_45)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_60)){
				
				
				int scale = (Left_Index_Finger_Block_45-Left_Index_Finger_Block_60)/15;
				fingers[4] = 60-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_60)/scale;
				
			}
			if((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_60)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_75)){
				
				
				int scale = (Left_Index_Finger_Block_60-Left_Index_Finger_Block_75)/15;
				fingers[4] = 75-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_75)/scale;
				
			}
			if((dims[leftIndexFingerIndex]<Left_Index_Finger_Block_75)&&(dims[leftIndexFingerIndex]>Left_Index_Finger_Block_90)){
				
				int scale = (Left_Index_Finger_Block_75-Left_Index_Finger_Block_90)/15;
				fingers[4] = 90-(dims[leftIndexFingerIndex]-Left_Index_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Left_Ring finger calibration mapping///////////////////////////////////
			if((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_0)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_15)){
				
				int scale = (Left_Ring_Finger_Block_0-Left_Ring_Finger_Block_15)/15;
				fingers[6] = 15-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_15)/scale;
				
			}
			if ((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_15)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_30)){
				
				int scale = (Left_Ring_Finger_Block_15-Left_Ring_Finger_Block_30)/15;
				fingers[6] = 30-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_30)/scale;
				
			}
			if((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_30)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_45)){
				
				
				int scale = (Left_Ring_Finger_Block_30-Left_Ring_Finger_Block_45)/15;
				fingers[6] = 45-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_45)/scale;
				
			}
			if((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_45)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_60)){
				
				
				int scale = (Left_Ring_Finger_Block_45-Left_Ring_Finger_Block_60)/15;
				fingers[6] = 60-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_60)/scale;
				
			}
			if((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_60)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_75)){
				
				
				int scale = (Left_Ring_Finger_Block_60-Left_Ring_Finger_Block_75)/15;
				fingers[6] = 75-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_75)/scale;
				
			}
			if((dims[leftRingFingerIndex]<Left_Ring_Finger_Block_75)&&(dims[leftRingFingerIndex]>Left_Ring_Finger_Block_90)){
				
				int scale = (Left_Ring_Finger_Block_75-Left_Ring_Finger_Block_90)/15;
				fingers[6] = 90-(dims[leftRingFingerIndex]-Left_Ring_Finger_Block_90)/scale;
			}
			
			
			//////////////////////////Left_Pinky finger calibration mapping///////////////////////////////////
			if((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_0)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_15)){
				
				int scale = (Left_Pinky_Finger_Block_0-Left_Pinky_Finger_Block_15)/15;
				fingers[7] = 15-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_15)/scale;
				
			}
			if ((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_15)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_30)){
				
				int scale = (Left_Pinky_Finger_Block_15-Left_Pinky_Finger_Block_30)/15;
				fingers[7] = 30-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_30)/scale;
				
			}
			if((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_30)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_45)){
				
				
				int scale = (Left_Pinky_Finger_Block_30-Left_Pinky_Finger_Block_45)/15;
				fingers[7] = 45-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_45)/scale;
				
			}
			if((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_45)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_60)){
				
				
				int scale = (Left_Pinky_Finger_Block_45-Left_Pinky_Finger_Block_60)/15;
				fingers[7] = 60-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_60)/scale;
				
			}
			if((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_60)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_75)){
				
				
				int scale = (Left_Pinky_Finger_Block_60-Left_Pinky_Finger_Block_75)/15;
				fingers[7] = 75-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_75)/scale;
				
			}
			if((dims[leftPinkyFingerIndex]<Left_Pinky_Finger_Block_75)&&(dims[leftPinkyFingerIndex]>Left_Pinky_Finger_Block_90)){
				
				int scale = (Left_Pinky_Finger_Block_75-Left_Pinky_Finger_Block_90)/15;
				fingers[7] = 90-(dims[leftPinkyFingerIndex]-Left_Pinky_Finger_Block_90)/scale;
			}

			/********************************************************************************************/
			//DEBUG: Print out the current value of our fingers 
			/*Debug.Log("Fingers: " +
			          "\n0: " + fingers[0] +
			          "\n1: " + fingers[1] + 
			          "\n2: " + fingers[2] + 
			          "\n3: " + fingers[3] +
			          "\n4: " + fingers[4] +
			          "\n5: " + fingers[5] +
			          "\n6: " + fingers[6] +
			          "\n7: " + fingers[7]);*/
			
		} catch (Exception e) {
			errorcounter++;
			//Debug.Log("Couldn't update fingers: "+errorcounter + e.ToStRight_Ring() + e.StackTrace);
		}
	}
}



