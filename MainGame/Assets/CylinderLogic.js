#pragma strict

private var trans: Transform;
private var rb: Rigidbody;
private var rot: Vector3;
private var scl: Vector3;
private var state: int;
private var grabTrans: Transform;

function Awake () {
	trans = transform;
	rb = rigidbody;
	state = 0;
}



function Update () {
	if(trans.parent != null) {
		rb.velocity = Vector3(0,0,0);
	}
	if (state) {
		trans.position = grabTrans.position;
	}
	
}

function OnCollisionEnter (collision : Collision) {
	Debug.Log(collision.transform.name);
	if(collision.transform.name == "GrabObject") {
		state = 1;
		grabTrans = collision.transform;
	}
}