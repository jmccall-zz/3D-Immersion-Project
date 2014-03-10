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
		reader.UpdateGestures ();
		if (objectTransform != null) {
			if (left && reader.LeftIsGrab) {
				objectTransform.position = transform.position;
			} else if (right && reader.RightIsGrab) {
				objectTransform.position = transform.position;
			} else {
				objectTransform = null;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.name == "Cylinder" && right && reader.RightIsGrab) {
			objectTransform = collision.transform;
		} else if (collision.transform.name == "Cylinder" && left && reader.LeftIsGrab) {
			objectTransform = collision.transform;
		}
	}
}
