#pragma strict

private var BigCubeOnRails: CubeOnRails;

function Start () {
	var rails: Vector3[] = [Vector3.right, Vector3.left, Vector3.right];
	BigCubeOnRails = CubeOnRails();
	BigCubeOnRails.rails = rails;
}

function Update () {

}

function OnGUI() {
	BigCubeOnRails.gameObject = gameObject;

	if (Input.GetButton("Action")) {
		Debug.Log("Action on Big Button!");
		BigCubeOnRails.move();
	}
}