using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour {
	private bool activated = false;
	
	public delegate void LeverActivated(bool active);
	private event LeverActivated OnLeverActivated;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddEventListener(LeverActivated listener) {
		OnLeverActivated += listener;
	}
	
	void OnTriggerStay(Collider other) {
		if (Input.GetButton("Action")) {
			if (!gameObject.animation.isPlaying) {
				activated = !activated;
				gameObject.animation.Play(activated ? "activate" : "deactivate");
				OnLeverActivated(activated);
			}
		}
	}
}
