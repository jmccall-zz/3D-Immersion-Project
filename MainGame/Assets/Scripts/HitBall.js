#pragma strict

var Magnitude : int = 1;
var Distance : float;
var MaxDistance : float = 1.5;

function Start () {

}

function Update () {
	if (Input.GetButtonDown("Fire1")) {
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit)) {
			Distance = hit.distance;
			if (Distance < MaxDistance) {
				var dir : Vector3 = transform.TransformDirection(Vector3.forward);
				hit.transform.SendMessage("ApplyForce", dir, SendMessageOptions.DontRequireReceiver);	
			}	
		}
	}
}