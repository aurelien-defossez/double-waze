public class CubeOnRails {
	public var rails: Vector3 [];
	public var lastStartPoint: Vector3;
	public var currentRail: Vector3;
	public var currentDestination: Vector3;
	var currentRailsIndex: int = 0;
	public var speed: float = 0.005;
	public var gameObject: GameObject;
	public var isMoving: boolean = false;

	private var isFinished: boolean = false;
	
	public function nextRail() {
		if (isFinished) {
			return;
		};
		if (currentRailsIndex >= rails.length) {
			isFinished = true;
			return;
		};
		currentRail = rails[currentRailsIndex++];
		lastStartPoint = gameObject.transform.parent.position;
		currentDestination = lastStartPoint + currentRail;
	}

	public function IsFinished () {
		return isFinished;
	}
	
	public function move() {
		isMoving = true;
		var direction_vector: Vector3 = currentDestination - gameObject.transform.parent.position;
		gameObject.transform.parent.position += (direction_vector)*speed;
	}
}