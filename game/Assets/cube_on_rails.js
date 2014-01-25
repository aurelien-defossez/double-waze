public class CubeOnRails {
	public var rails: Vector3 [];
	public var currentRails: Vector3;
	var currentRailsIndex: int = 0;
	public var speed: int = 100;
	public var gameObject: GameObject;
	
	public function nextRail() {
		Debug.Log("nextRail");
		currentRails = rails[currentRailsIndex++];
	}
	
	public function move() {
		Debug.Log("move");
		gameObject.transform.position += speed * currentRails;
	}
}