using UnityEngine;
using System.Collections;

public class GrabLogic : MonoBehaviour {

	public string hand = "RightOrLeft";
	private bool right;
	private bool left;
	Transform objectTransform;
	GloveReader reader;
	// Use this for initialization
	void Start () {
		left = (hand == "Left");
		right = (hand == "Right");
		reader = new GloveReader ();
		objectTransform = null;
	}
	
	// Update is called once per frame
	void Update () {

		if (objectTransform != null) {
			if (left && reader.LeftIsGrab) {
				objectTransform.position = transform.position;
			} else if (right && reader.RightIsGrab) {
				objectTransform.position = transform.position;
			} else {
				objectTransform = null;
			}
		}
		//Debug.Log (reader.leftFingerZones[3]);
		//Debug.Log (reader.LeftIsGrab);
		reader.UpdateGestures ();
	}

	void OnCollisionEnter(Collision collision) {
		reader.UpdateGestures ();
		if (collision.transform.name == "Cylinder" && right && reader.RightIsGrab) {
			objectTransform = collision.transform;
		} else if (collision.transform.name == "Cylinder" && left && reader.LeftIsGrab) {
			objectTransform = collision.transform;
		}
	}
}
