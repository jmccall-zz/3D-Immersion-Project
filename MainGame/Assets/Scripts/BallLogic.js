#pragma strict

var maxVelocity : float = 20;

var Magnitude : float = 100000;
var vec : Vector3;

private var rb : Rigidbody;
private var trans : Transform;
private var sqrMaxVelocity : float;
private var isMoving : boolean = false;
// Awake is a built-in unity function that is called called
// only once during the lifetime of the script instance.
// It is called after all objects are initialized.
function Awake() {
	rb = rigidbody;
	trans = transform;
	SetMaxVelocity(maxVelocity);
}

function SetMaxVelocity(maxVelocity : float){
	this.maxVelocity = maxVelocity;
	sqrMaxVelocity = maxVelocity * maxVelocity;
}

function Start () {
	//rigidbody.AddForce(1, -1, 1, ForceMode.Impulse);
}


function FixedUpdate () {
	// 
	if (trans.parent == null) {	
		var v = rb.velocity;
		if (v.sqrMagnitude > sqrMaxVelocity) {
			rb.velocity = v.normalized * maxVelocity;
		}
	} else {
		rb.velocity = Vector3(0,0,0);
	}
}

function ApplyForce (dir : Vector3) {
	vec = dir * Magnitude;
	rb.AddForce(vec, ForceMode.Impulse);
	Debug.Log(vec);
}

function OnCollisionEnter (collision : Collision) {
	if (trans.parent == null) {
		rb.AddForce(collision.contacts[0].normal, ForceMode.VelocityChange);
	} else {
		rb.velocity = Vector3(0,0,0);
	}
}