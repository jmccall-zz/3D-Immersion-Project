using UnityEngine;
using System.Collections;

public class CylinderLogic : MonoBehaviour {

	bool hasHit;

	void Start () {
		hasHit = false;
	}
	
	
	
	void Update () {

	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Bottom" && !hasHit) {
			hasHit = true;
			CylinderCatch temp = collision.gameObject.GetComponent<CylinderCatch>();
			temp.Caught();
		}
	}
}