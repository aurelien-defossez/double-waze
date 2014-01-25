#pragma strict

// var pivot : Transform;
// // this is half the length of the side of the cube
// var halfSideLength : float = 1;
// private var isRotating : boolean = false;
// function Start(){
// //set the pivot to be in the plane the cube is on
// if (!pivot) {
// 	Debug.Log("Assigning pivot variable...");
// 	pivot = transform;
// };
// pivot.position.y = transform.position.y - halfSideLength;
// }
// function Update () {
 
//       if(isRotating == false){
//               rotateRight(360,1);    }
 
// }
// function rotateRight(degrees : float, time : float) {
 
//    var speed = 1.0/time;
//    var initialRotation = Quaternion.identity;
//    pivot.position.x = transform.position.x + halfSideLength;
//    transform.parent = pivot;
//  //  pivot.localEulerAngles.z = -degrees;
//  //  var finalRotation = pivot.transform.rotation;
//    isRotating = true;
//    for (var t = 0.0; t < 1.0; t += Time.deltaTime*speed){
//       //pivot.transform.rotation = Quaternion.Slerp(initialRotation,finalRotation, t);
//       pivot.transform.eulerAngles.z = t*(-degrees); //Mathf.Lerp(0,-degrees,t);
//       yield;
//    }
//    pivot.localEulerAngles.z = -degrees;
//    transform.parent = null;
//    pivot.rotation = Quaternion.identity;
//    isRotating = false;
// }

function Update() {
		
}

function Start () {
	var vertices = GetComponent(MeshFilter).mesh.vertices;
	for (var i = vertices.length - 1; i >= 0; i--) {
		Debug.Log(i + "th:");
		Debug.Log(vertices[i]);
	};
}