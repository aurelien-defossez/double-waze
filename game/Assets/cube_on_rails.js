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
		Debug.Log(gameObject.name);
		gameObject.transform.position += speed * currentRails;
		Debug.Log(speed);
		Debug.Log(speed * currentRails);
	}
}