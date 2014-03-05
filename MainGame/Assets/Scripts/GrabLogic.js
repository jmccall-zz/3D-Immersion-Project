﻿#pragma strict

private var rb : Rigidbody;
private var trans : Transform;
private var childTrans : Transform;

function Awake() {
	rb = rigidbody;
	trans = transform;
	childTrans = null;
}

function Start () {

}

function Update () {
	childTrans = trans.GetChild(0);
	if (childTrans) {
		childTrans.rigidbody.velocity = Vector3(0,0,0);
		childTrans.localPosition = Vector3(0,0,0);
		childTrans.rigidbody.angularVelocity = (Vector3(0,0,0));
	}
}

function OnCollisionEnter (collision : Collision) {
	Debug.Log(collision.transform.name);
	if(collision.transform.name == "Cylinder") {
		collision.transform.parent = trans;
		collision.transform.rigidbody.velocity = Vector3(0,0,0);
		collision.transform.rigidbody.angularVelocity = (Vector3(0,0,0));
		collision.transform.localPosition = Vector3(0,0,0);
	}
}