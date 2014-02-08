#pragma strict

private var sphereChild : Transform;
var Magnitude : int = 5;

function Start () {
	sphereChild = transform.GetChild(0);
}

function Update () {
	if (Input.GetButtonDown("Fire1")) {
		
		throwBall(transform.parent.transform.TransformDirection(Vector3.forward), sphereChild);
	}	
}

function throwBall(direction : Vector3, obj : Transform) {
	if (obj.parent != null) {
		obj.parent = null;
		obj.rigidbody.useGravity = (true);
		obj.rigidbody.AddForce(direction * Magnitude, ForceMode.Impulse);
	}
}

