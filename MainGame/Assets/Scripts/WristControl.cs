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
	public string wrist_name = "RightHand";


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
			wrist_rotation_x = readArray[reader.LH_AccX()];
			wrist_rotation_y = readArray[reader.LH_AccY()];
			wrist_rotation_z = readArray[reader.LH_AccZ()]; 
			/*Debug.Log (wrist_rotation_x);
			Debug.Log (wrist_rotation_y);
			Debug.Log (wrist_rotation_z);*/

			//float mag = Mathf.Sqrt((wrist_rotation_x*wrist_rotation_x) + (wrist_rotation_y*wrist_rotation_y) + (wrist_rotation_z*wrist_rotation_z));
			/*if (wrist_rotation_x < 0) {
				wrist.x =  Mathf.PI + Mathf.Acos(wrist_rotation_x/mag);
			} else {
				wrist.x =  Mathf.Acos(wrist_rotation_x/mag);
			}
			if (wrist_rotation_x < 0) {
				wrist.y =  Mathf.PI + Mathf.Acos(wrist_rotation_y/mag);
			} else {
				wrist.y =  Mathf.Acos(wrist_rotation_y/mag);
			}
			if (wrist_rotation_z < 0) {
				wrist.z =  Mathf.PI + Mathf.Acos(wrist_rotation_z/mag);
			} else {
				wrist.z =  Mathf.Acos(wrist_rotation_z/mag);
			}*/
			float alpha = Mathf.Atan2(wrist_rotation_y, wrist_rotation_z);
			rotation_x = Mathf.Rad2Deg * Mathf.Atan2(wrist_rotation_y, wrist_rotation_z);
			float asinAlph = Mathf.Asin(alpha);
			rotation_z = -Mathf.Rad2Deg * Mathf.Atan2(wrist_rotation_x, wrist_rotation_z);
			//wrist.z = 0;
			//Debug.Log (rotation_x);
			//Debug.Log (rotation_y);
			//Debug.Log (rotation_z);
			float rot_y = 180 + wrist_transform.parent.transform.eulerAngles.y;
			wrist_transform.eulerAngles = new Vector3(rotation_x,rot_y, rotation_z);
		}
	}
	
}
