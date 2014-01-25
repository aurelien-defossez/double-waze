using UnityEngine;
using System.Collections;

public class ValveTrigger : MonoBehaviour {
	const float rotationSpeed = 45f;

	private bool pushed = false;
	private GameObject valve;

	// Use this for initialization
	void Start () {
		valve = GameObject.Find ("Valve");
	}
	
	// Update is called once per frame
	void Update () {
		if (pushed) {
			valve.transform.RotateAround (
				valve.transform.position,
				Vector3.back,
				rotationSpeed * Time.deltaTime
			);
		}
	}
	
	void OnTriggerEnter(Collider other) {

	}
	
	void OnTriggerStay(Collider other) {
		if (Input.GetButton("Action")) {
			StartPush();
		} else {
			StopPush();
		}
	}

	void OnTriggerExit(Collider other) {
		StopPush ();
	}
	
	void StartPush() {
		if (!pushed) {
			pushed = true;
		}
	}
	
	void StopPush() {
		if (pushed) {
			pushed = false;
		}
	}
}
