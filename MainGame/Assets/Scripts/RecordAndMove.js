#pragma strict

var moving : boolean;
private var trans : Transform;
static var amount : float = 0.25;

function Start () {
	moving = false;
	trans = transform;
}

function Update () {
	if(Input.GetKeyDown("space") && trans.position.x % 20 == 0) {
		Record();
		moving = true;
	}
	if (moving) {
		trans.position.x = trans.position.x + amount;
		if (trans.position.x % 20 == 0) moving = false;
	}
	
}

function Record() {
	
}
