#pragma strict
#pragma implicit
#pragma downcast

// Does this script currently respond to input?
// var canControl : boolean = true;

// var useFixedUpdate : boolean = true;

var runMultiplicator : float = 2.0;

// For the next variables, @System.NonSerialized tells Unity to not serialize the variable or show it in the inspector view.
// Very handy for organization!

// The current global direction we want the character to move in.
@System.NonSerialized
var inputMoveDirection : Vector3 = Vector3.zero;

// Is the jump button held down? We use this interface instead of checking
// for the jump button directly so this script can also be used by AIs.
@System.NonSerialized
var inputJump : boolean = false;
var inputRun : boolean = false;
var jumping : boolean = false;
var jumpForce : float = 10.0;
private var previousVelocityY: float;
private var controller : CharacterController;

function Awake () {
	controller = GetComponent (CharacterController);
	tr = transform;
}

function Start () {
	rigidbody.velocity.x = inputMoveDirection.x*10;
	rigidbody.velocity.z = inputMoveDirection.z*10;

}

function Update () {
	if (inputRun) {
		Debug.Log("RUN!");
		inputMoveDirection *= 2;
	};
	// transform.position += inputMoveDirection;
	// Debug.Log(inputMoveDirection.x);
	// Debug.Log(inputMoveDirection.y);
	// Debug.Log(inputMoveDirection.z);
	rigidbody.velocity.x = inputMoveDirection.x*10;
	rigidbody.velocity.z = inputMoveDirection.z*10;
	// controller.Move(inputMoveDirection);
	if (inputJump) {
		// Debug.Log("JUMP!");
		if (jumping) {
			// Debug.Log("Already Jumping"); 
		} else {
			Debug.Log("JUMP SUCCESS!");
			jumping = true;
			rigidbody.velocity.y = 1;
			rigidbody.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
		}
	}
	previousVelocityY = rigidbody.velocity.y;
	// rigidbody.velocity.y = inputMoveDirection.y;
}

function OnCollisionEnter(collision : Collision) {
	Debug.Log("Collision bet. Player and " + collision.gameObject.tag);

/*	for (var contact : ContactPoint in collision.contacts) {
			print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
			// Visualize the contact point
			Debug.Log(contact.normal);
		}
*/
	if (Mathf.Abs(Vector3.Angle(Vector3.up, collision.contacts[0].normal)) <= 45) {
		Debug.Log("Allowing to jump again.");
		jumping = false;
	};
}

// function OnTriggerEnter (collider: Collider) {
// 	Debug.Log("TriggerEnter");
// }

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterController)
@script AddComponentMenu ("Character/Character Motor")
