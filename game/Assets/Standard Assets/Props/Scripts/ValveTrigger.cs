using UnityEngine;
using System.Collections;

public class ValveTrigger : MonoBehaviour {
	const float rotationSpeed = 45f;

	public delegate void ValveActivated(string phase, float rotation);
	public static event ValveActivated OnValveActivated;

	private bool pushed = false;
	private float rotation = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (pushed) {
			float deltaRotation = rotationSpeed * Time.deltaTime;
			rotation += deltaRotation;

			gameObject.transform.RotateAround (
				gameObject.transform.position,
				Vector3.back,
				deltaRotation
			);

			SendEvent("activated");
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
			SendEvent("began");
		}
	}
	
	void StopPush() {
		if (pushed) {
			pushed = false;
			SendEvent("ended");
		}
	}

	void SendEvent(string phase) {
		OnValveActivated (phase, rotation);
	}
}
	