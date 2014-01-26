#pragma strict

private var BigCubeOnRails: CubeOnRails;
private var OnActivate: function () = function () {} ;

function Activate() {
	//Debug.Log("Triggering event funtion");
	if (Input.GetButton("Action")) {
		Debug.Log("Action on Big Button!");
		BigCubeOnRails.move();
	}
}

function Start () {
	var rails: Vector3[] = [Vector3.right, Vector3.left, Vector3.right];
	BigCubeOnRails = CubeOnRails();
	BigCubeOnRails.rails = rails;
	BigCubeOnRails.nextRail();
}

function Update () {

}

function OnTriggerEnter(collider: Collider) {
	Debug.Log("OnTriggerEnter on BigCube");
	Debug.Log("Adding function to event trigger");
	if (collider.tag == "Player") {
		OnActivate = Activate;
	} else {
		Debug.Log("This was not the player.");
	}
}
function OnTriggerExit(collider: Collider) {
	Debug.Log("OnTriggerExit on BigCube");
	if (collider.tag == "Player") {
		Debug.Log("Removing function from event trigger");
		OnActivate = function () {};
	} else {
		Debug.Log("This was not the player.");
	}
}

function OnGUI() {
	BigCubeOnRails.gameObject = gameObject;
	(OnActivate as Function)();
}