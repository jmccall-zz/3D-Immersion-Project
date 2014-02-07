#pragma strict


function OnCollisionExit(collision : Collision) {
	// On collision with sphere "catch" sphere by zeroing velocity
	// and setting its local position to zero
	if (collision.transform.name == "Sphere") {
		collision.transform.rigidbody.velocity = Vector3(0,0,0);
		Debug.Log(transform.GetChild(3));
		collision.transform.parent = transform.GetChild(3);
		collision.transform.localPosition = Vector3(0,0,0);
		collision.transform.rigidbody.useGravity = false;
	}
}