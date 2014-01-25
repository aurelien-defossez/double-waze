using UnityEngine;
using System.Collections;

public class PressureTrigger : MonoBehaviour {
	
	public delegate void PressureActivated(bool active);
	public static event PressureActivated OnPressureActivated = delegate{};

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
		Activate(true);
	}
	
	void OnTriggerStay(Collider other) {

	}
	
	void OnTriggerExit(Collider other) {
		Activate(false);
	}

	void Activate(bool active) {
		OnPressureActivated(active);
	}
}
