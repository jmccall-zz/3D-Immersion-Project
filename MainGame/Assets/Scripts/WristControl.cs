using UnityEngine;
using System.Collections;


public class WristControl : MonoBehaviour {

	private float wrist_rotation_x;
	private float wrist_rotation_y;
	private float wrist_rotation_z;
	private float rotation_x;
	private float rotation_y;
	private float rotation_z;
	float [] readArray;
	GloveReader reader;
	Transform wrist_transform; 
	public string wrist_name = "RightWrist";


	// Use this for initialization
	void Start () {
		wrist_transform = GameObject.Find(wrist_name).transform;
		//Debug.Log("Rotation x: " + transform.localEulerAngles.x);
		reader = new GloveReader();

	}
	
	// Update is called once per frame
	void Update () {
		readArray = reader.getValues();
		/*for (int i = 0; i < 11; i++) {
			Debug.Log (readArray [i]);
		}*/
		if (readArray != null) {
			if(wrist_name == "RightWrist") {
				wrist_rotation_x = readArray[reader.RH_AccX()];
				wrist_rotation_y = readArray[reader.RH_AccY()];
				wrist_rotation_z = readArray[reader.RH_AccZ()]; 
			} else if (wrist_name == "LeftWrist") {
				wrist_rotation_x = readArray[reader.LH_AccX()];
				wrist_rotation_y = readArray[reader.LH_AccY()];
				wrist_rotation_z = readArray[reader.LH_AccZ()]; 
			}

			float alpha = Mathf.Atan2(wrist_rotation_y, wrist_rotation_z);
			rotation_x = Mathf.Rad2Deg * Mathf.Atan2(wrist_rotation_y, wrist_rotation_z);
			float asinAlph = Mathf.Asin(alpha);
			rotation_z = - Mathf.Rad2Deg * Mathf.Atan2(wrist_rotation_x, wrist_rotation_z);
			//wrist.z = 0;
			//Debug.Log (rotation_x);
			//Debug.Log (rotation_y);
			//Debug.Log (rotation_z);
			float rot_y = wrist_transform.parent.transform.eulerAngles.y;
			wrist_transform.eulerAngles = new Vector3(rotation_x,rot_y, rotation_z);
		}
	}
	
}
