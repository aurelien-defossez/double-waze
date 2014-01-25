using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour {
	private bool activated = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other) {
		if (Input.GetButton("Action")) {
			if (!gameObject.animation.isPlaying) {
				activated = !activated;
				gameObject.animation.Play(activated ? "activate" : "deactivate");
			}
		}
	}
}
