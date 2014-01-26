using UnityEngine;
using System.Collections;

public class PressureTrigger : MonoBehaviour {
	
	public delegate void PressureActivated(bool active);
	public static event PressureActivated OnPressureActivated = delegate{};

	public int colliderCount = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddEventListener(PressureActivated listener) {
		OnPressureActivated += listener;
	}
	
	void OnTriggerEnter(Collider other) {
		if (colliderCount == 0) {
			Activate(true);
		}

		colliderCount ++;
	}
	
	void OnTriggerStay(Collider other) {

	}
	
	void OnTriggerExit(Collider other) {
		colliderCount --;

		if (colliderCount == 0) {
			Activate(false);
		}
	}

	void Activate(bool active) {
		OnPressureActivated(active);
	}
}
