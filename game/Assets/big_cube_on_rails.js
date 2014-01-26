#pragma strict

private var BigCubeOnRails: CubeOnRails;
private var OnActivate: function () = function () {} ;
public var speed: float = 1;
function Activate() {
	//Debug.Log("Triggering event funtion");
	if (Input.GetButtonUp("Action")) {
		BigCubeOnRails.nextRail();
		BigCubeOnRails.move();
	}
}

function Start () {
	var rails: Vector3[] = [Vector3(5.4849798, 0, 0)];
	BigCubeOnRails = CubeOnRails();
	BigCubeOnRails.rails = rails;
	BigCubeOnRails.speed = speed;
}

function Update () {
	if (BigCubeOnRails.IsFinished()) {
		return;
	};
	(OnActivate as Function)();
	if (BigCubeOnRails.isMoving) {
		if (Vector3.Distance(BigCubeOnRails.currentDestination, gameObject.transform.parent.position) <= 0.004) {
			BigCubeOnRails.isMoving = false;
		} else {
			BigCubeOnRails.move();
		}
	}
}

function OnTriggerEnter(collider: Collider) {
	BigCubeOnRails.gameObject = gameObject;
	if (collider.tag == "Player") {
		OnActivate = Activate;
	}
}
function OnTriggerExit(collider: Collider) {
	if (collider.tag == "Player") {
		OnActivate = function () {};
	}
}