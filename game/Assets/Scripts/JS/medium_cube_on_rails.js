#pragma strict

private var MediumCubeOnRails: CubeOnRails;
private var OnActivate: function () = function () {} ;
public var speed: float = 1;
public var nextParents: GameObject[];

function Activate() {
	//Debug.Log("Triggering event funtion");
	if (Input.GetButtonUp("Action")) {
		MediumCubeOnRails.nextRail();
		MediumCubeOnRails.move();
	}
}

function Start () {
	var rails: Vector3[] = [Vector3(1.710354, 0, 3.270676), Vector3(5.0, 0, 0)];
	MediumCubeOnRails = CubeOnRails();
	MediumCubeOnRails.rails = rails;
	MediumCubeOnRails.speed = speed;
}

function Update () {
	if (MediumCubeOnRails.IsFinished()) {
		return;
	};
	(OnActivate as Function)();
	if (MediumCubeOnRails.isMoving) {
		if (Vector3.Distance(MediumCubeOnRails.currentDestination, gameObject.transform.parent.position) <= 0.004) {
			MediumCubeOnRails.isMoving = false;
			// End of move, change parent
			MediumCubeOnRails.isMoving = false;
			var formerParent: GameObject = this.transform.parent.parent.gameObject;
			(formerParent.GetComponent("Reveal") as Reveal).boxes = null;
			var newParent: GameObject = nextParents[MediumCubeOnRails.currentRailsIndex];
			this.transform.parent.parent = newParent.transform;
			var revObj: Reveal = (newParent.gameObject.GetComponent("Reveal") as Reveal);
			Debug.Log(Reveal);
			revObj.RefreshBoxes();
		} else {
			MediumCubeOnRails.move();
		}
	}
}

function OnTriggerEnter(collider: Collider) {
	MediumCubeOnRails.gameObject = gameObject;
	if (collider.tag == "Player") {
		OnActivate = Activate;
	}
}
function OnTriggerExit(collider: Collider) {
	if (collider.tag == "Player") {
		OnActivate = function () {};
	}
}