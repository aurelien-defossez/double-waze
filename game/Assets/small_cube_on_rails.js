﻿#pragma strict

private var SmallCubeOnRails: CubeOnRails;
private var OnActivate: function () = function () {} ;
public var speed: float = 1;
function Activate() {
	//Debug.Log("Triggering event funtion");
	if (Input.GetButtonUp("Action")) {
		SmallCubeOnRails.nextRail();
		SmallCubeOnRails.move();
	}
}

function Start () {
	var rails: Vector3[] = [
		Vector3(-3.668279, 0, -1.0638),
		Vector3(-2.75121, 0, 2.31101),
		Vector3(1.660354, 0, 4.670676),
		Vector3(2.0, 0, 0)
	];
	SmallCubeOnRails = CubeOnRails();
	SmallCubeOnRails.rails = rails;
	SmallCubeOnRails.speed = speed;
}

function Update () {
	if (SmallCubeOnRails.IsFinished()) {
		return;
	};
	(OnActivate as Function)();
	if (SmallCubeOnRails.isMoving) {
		if (Vector3.Distance(SmallCubeOnRails.currentDestination, gameObject.transform.parent.position) <= 0.004) {
			SmallCubeOnRails.isMoving = false;
		} else {
			SmallCubeOnRails.move();
		}
	}
}

function OnTriggerEnter(collider: Collider) {
	SmallCubeOnRails.gameObject = gameObject;
	if (collider.tag == "Player") {
		OnActivate = Activate;
	}
}
function OnTriggerExit(collider: Collider) {
	if (collider.tag == "Player") {
		OnActivate = function () {};
	}
}