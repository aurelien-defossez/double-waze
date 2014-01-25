using UnityEngine;
using System.Collections;

public class Hatch : MonoBehaviour {

	public Transform pivot;
	// this is half the length of the side of the cube
	float halfSideLength = 1.0f;
	bool isRotating = false;

	void OnEnable() {
		EventManager.OnAction += Open;
		Debug.Log(GetComponent<MeshFilter>().mesh.bounds);

	}
	void OnDisable() {
		EventManager.OnAction -= Open;
	}

	public void Open() {
		var pos = transform.position;
		pos.x += Random.Range(-10.0f, 30.0f);
		transform.position = pos;
	}

	// Use this for initialization
	void Start () {
		pivot = transform;
		var pos = pivot.position;
		pos.y = transform.position.y - halfSideLength;
		pivot.position = pos;
	}
		
	public IEnumerator rotateRight(float degrees, float time) {
		var speed = 1.0f/time;
		var initialRotation = Quaternion.identity;
		var pos = pivot.position;
		pos.x = transform.position.x + halfSideLength;
		pivot.position = pos;
		transform.parent = pivot;
		pivot.rotation = Quaternion.identity;
		isRotating = true; 
		Debug.Log("Hey....");
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed){
			var tmp = pivot.transform.eulerAngles;
			tmp.z = t*(-degrees);
			pivot.transform.eulerAngles = tmp;
			yield return null;
		}
		var lea = pivot.localEulerAngles;
		transform.parent = null;
		lea.z = -degrees;
		pivot.localEulerAngles = lea;
		isRotating = false; 
	} 


	// Update is called once per frame
	void Update () {
		if (!isRotating) {
			Debug.Log("Rotating...");
			rotateRight(90,1);
		}
	}
}
