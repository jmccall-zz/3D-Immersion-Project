using UnityEngine;
using System.Collections;

public class CylinderLogic : MonoBehaviour {
	private Transform trans;
	private Rigidbody rb;
	private Vector3 rot;
	private Vector3 scl;
	private int state;
	private Transform grabTrans;
	GloveReader GloveData;
	
	void Start () {
		trans = transform;
		rb = rigidbody;
		state = 0;
		GloveData = new GloveReader();
	}
	
	
	
	void Update () {
		if(trans.parent != null) {
			Vector3 vel = new Vector3(0,0,0);
			rigidbody.velocity = vel;
		}
		if (state == 1) {
			trans.position = grabTrans.position;
		}
		
		if(!GloveData.IsGrab) {
			state = 0;
		}
		GloveData.UpdateGestures();	
		Debug.Log (GloveData.IsGrab);
	}
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log(collision.transform.name);
		if(collision.transform.name == "GrabObject" && GloveData.IsGrab) {
			state = 1;
			grabTrans = collision.transform;
		}
	}
}