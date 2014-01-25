using UnityEngine;
using System.Collections;

public class Reveal : MonoBehaviour {

	//bool on = false;
	float lightCountdown = 0;
	float maxCountdown = 0.5f;

	// Use this for initialization
	void Start () {
		EnableLights(false);
	}
	
	// Update is called once per frame
	void Update () {
		// The lights are turned on or off
		if (lightCountdown > 0) {	
			lightCountdown -= Time.deltaTime;

			if (lightCountdown <= 0) {
				EnableLights(false);
			}
		}
	}

	public void activate(bool on) {
		// Never disable the object, to keep the revealed item in the scene
		if (on) gameObject.SetActive (true);
		lightCountdown = maxCountdown;
		EnableLights(true);
	}

	void EnableLights(bool state) {
		Component[] spotlights = GetComponentsInChildren<Light>();
		foreach (Light light in spotlights) {
			light.enabled = state;
		}
	}
}
