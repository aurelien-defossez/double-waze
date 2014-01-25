using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Vector3 rotationAxis = Vector3.up;
	public float maxRotationSpeed = 20;
	private Vector3 hingePosition;
	private float currentRotationSpeed; // will be null when disabled etc

	// Use this for initialization
	void Start () {
		hingePosition = transform.Find("Hinge").position;
		gameObject.GetComponent<Trigger> ().onTrigger += OnDoorTrigger;
	}
	
	void Update()
	{
		transform.RotateAround(hingePosition, rotationAxis, currentRotationSpeed * Time.deltaTime);
	}

	public void OnDoorTrigger(bool on) {
		Debug.Log ("transform.rotation" + transform.rotation);
		if (on && currentRotationSpeed == 0) currentRotationSpeed = maxRotationSpeed;
		else currentRotationSpeed = 0;
	}
}
