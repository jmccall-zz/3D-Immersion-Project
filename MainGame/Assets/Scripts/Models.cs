using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Models : MonoBehaviour {
	
	static public float[] fingers = new float[10];
	static public float[] accelerometer = new float[3];

	private GloveReader reader;

	private int[] degreeTranslations = {
		0,	// 0 -> 0
		15, // 1 -> 15
		30, // 2 -> 30
		45, // 3 -> 45
		60, // 4 -> 60
		75, // 5 -> 75
		90  // 6 -> 90 
	};
	
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
			          dims[10] + "\n");*/

			// accelerometer (0, 1, 2) --> (x, y, z)
			//accelerometer[0] = dims[5];
			//accelerometer[1] = dims[6];
			//accelerometer[2] = dims[7];
			/* Scale text file values */
			////////////////////////Right_Index block definitions/////////////////////
			int [] Right_Index_Finger_Blocks  =  {
				reader.rightFingerZones[0],
				reader.rightFingerZones[1],
				reader.rightFingerZones[2],
				reader.rightFingerZones[3],
				reader.rightFingerZones[4], 
				reader.rightFingerZones[5],
				reader.rightFingerZones[6]
			};	

			////////////////////////Right_Middle finger block definitions//////////////
			int [] Right_Middle_Finger_Blocks  =  {
				reader.rightFingerZones[7],
				reader.rightFingerZones[8],
				reader.rightFingerZones[9],
				reader.rightFingerZones[10],
				reader.rightFingerZones[11], 
				reader.rightFingerZones[12],
				reader.rightFingerZones[13]
			};

			//////////////////////Right_Ring finger block definitions//////////////////
			int [] Right_Ring_Finger_Blocks  =  {
				reader.rightFingerZones[14],
				reader.rightFingerZones[15],
				reader.rightFingerZones[16],
				reader.rightFingerZones[17],
				reader.rightFingerZones[18], 
				reader.rightFingerZones[19],
				reader.rightFingerZones[20]
			};
			
			/////////////////////Right_Pinky block definitions////////////////////
			int [] Right_Pinky_Finger_Blocks  =  {
				reader.rightFingerZones[21],
				reader.rightFingerZones[22],
				reader.rightFingerZones[23],
				reader.rightFingerZones[24],
				reader.rightFingerZones[25], 
				reader.rightFingerZones[26],
				reader.rightFingerZones[27]
			};
			/////////////////////Right_Knuckle block definitions////////////////////
			int [] Right_Knuckle_Blocks  =  {
				reader.rightFingerZones[28],
				reader.rightFingerZones[29],
				reader.rightFingerZones[30],
				reader.rightFingerZones[31],
				reader.rightFingerZones[32], 
				reader.rightFingerZones[33],
				reader.rightFingerZones[34]
			};
			///////////////////////Left_Index block definitions/////////////////////
			int [] Left_Index_Finger_Blocks  =  {
				reader.leftFingerZones[0],
				reader.leftFingerZones[1],
				reader.leftFingerZones[2],
				reader.leftFingerZones[3],
				reader.leftFingerZones[4], 
				reader.leftFingerZones[5],
				reader.leftFingerZones[6]
			};
			
			////////////////////////Left_Middle finger block definitions//////////////
			int [] Left_Middle_Finger_Blocks  =  {
				reader.leftFingerZones[7],
				reader.leftFingerZones[8],
				reader.leftFingerZones[9],
				reader.leftFingerZones[10],
				reader.leftFingerZones[11], 
				reader.leftFingerZones[12],
				reader.leftFingerZones[13]
			};
			
			//////////////////////Left_Ring finger block definitions//////////////////
			int [] Left_Ring_Finger_Blocks  =  {
				reader.leftFingerZones[14],
				reader.leftFingerZones[15],
				reader.leftFingerZones[16],
				reader.leftFingerZones[17],
				reader.leftFingerZones[18], 
				reader.leftFingerZones[19],
				reader.leftFingerZones[20]
			};
			
			/////////////////////Left_Pinky block definitions////////////////////
			int [] Left_Pinky_Finger_Blocks  =  {
				reader.leftFingerZones[21],
			 	reader.leftFingerZones[22],
				reader.leftFingerZones[23],
				reader.leftFingerZones[24],
				reader.leftFingerZones[25], 
				reader.leftFingerZones[26],
				reader.leftFingerZones[27]
			};

			/////////////////////Left_Knuckle block definitions////////////////////
			int [] Left_Knuckle_Blocks  =  {
				reader.leftFingerZones[28],
				reader.leftFingerZones[29],
				reader.leftFingerZones[30],
				reader.leftFingerZones[31],
				reader.leftFingerZones[32], 
				reader.leftFingerZones[33],
				reader.leftFingerZones[34]
			};
			// Scale right hand fingers to degrees 0 - 90
			fingers[0] = scale_finger(dims[reader.RH_IndexFinger()], Right_Index_Finger_Blocks);
			fingers[1] = scale_finger(dims[reader.RH_MiddleFinger()], Right_Middle_Finger_Blocks);
			fingers[2] = scale_finger(dims[reader.RH_RingFinger()], Right_Ring_Finger_Blocks);
			fingers[3] = scale_finger(dims[reader.RH_PinkyFinger()], Right_Pinky_Finger_Blocks);
			fingers[4] = scale_finger(dims[reader.RH_Knuckle()], Right_Knuckle_Blocks);

			// Scale left hand fingers to degrees 0 - 90
			fingers[5] = scale_finger(dims[reader.LH_IndexFinger()], Left_Index_Finger_Blocks);
			fingers[6] = scale_finger(dims[reader.LH_MiddleFinger()], Left_Middle_Finger_Blocks);
			fingers[7] = scale_finger(dims[reader.LH_RingFinger()], Left_Ring_Finger_Blocks);
			fingers[8] = scale_finger(dims[reader.LH_PinkyFinger()], Left_Pinky_Finger_Blocks);
			fingers[9] = scale_finger(dims[reader.LH_Knuckle()], Left_Knuckle_Blocks);
			
		} catch (Exception e) {
			errorcounter++;
			//Debug.Log("Couldn't update fingers: "+errorcounter + e.ToStRight_Ring() + e.StackTrace);
		}
	}
	
	/* This function returns a degree value based on the the range that the raw glove data falls into
	 * 
	 * @param value: Raw glove value returned by the bend sensor
	 * @param max: The maximum glove value obtained from a calibration table. ex) Say our value falls between the
	 * calibration blocks 75 & 90. The highest of the calibration values for 75 & 90 (in the database) should be "max".
	 * @param max_degrees: The upper boundary of the degree range we are in. In our previous example this would be 90
	 */ 
	float get_degrees (float value, int max, int min, int max_degrees, int scale_factor = 15) {
		float scale = (max - min) / scale_factor;
		return max_degrees - ((value - min) / scale);
	}


	/* Scale an entire finger.  Do this by checking which range the raw glove data value falls into.  Then use appropriate
	 * values for said range to caluculate an appropriate degree value
	 * TODO: This function sometimes evaluates to a negative number. This is not ideal. These negative values are dealt
	 * with properly by outside functions but ultimately should be resolved here. This may be a result of our calculations
	 * involving integers and floats combined
	 * 
	 * @param blocks: Calibration blocks for the finger.  These are values determined in the calibration scene for certain 
	 * degrees of bend. At 0, 15, 30, 45, 60, 75, and 90 degrees this raw glove data is collected.
	 */
	float scale_finger(float value, int [] blocks, int scale_factor = 15){
		float degrees = -1;
		int max;
		int min;

		// If we get a raw value higher than our full extension calibrated value, set degrees to 0
		if (value >= blocks[0])
			return 0;

		// If we get a raw value lower than our calibrated closed fist, set degrees to 90
		else if (value <= blocks[6])
			return 90;

		// Cycle through ranges to determine correct scaling
		for (int i = 0; i < 6; i++) {
			// Check if input value is exactly equal to one of our calibration points
			if (value == blocks[i]) {
				degrees = (float) degreeTranslations[i];
				break;
			}
			// Check which range our input value falls into and calculate degrees accordingly
			if ((value < blocks[i]) && (value > blocks[i + 1])) {
				max = Math.Max(blocks[i], blocks[i + 1]);
				min = Math.Min(blocks[i], blocks[i + 1]);
				degrees = get_degrees (value, max, min, degreeTranslations[i + 1], scale_factor);
				break;
			}
		}
		if (degrees == -1) {
			// TODO: Prevent this from happenning. We should always be able to scale a value. If it exceeds our
			// boundaries then we should be setting the value to 0 or 90. 
			Debug.Log("Could not scale this finger. Value didn't fall in any range\n" +
			          "Value: " + value);
		}

		return degrees;
	}
}



