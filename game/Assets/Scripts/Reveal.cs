﻿using UnityEngine;
using System.Collections;

public class Reveal : MonoBehaviour {
	float lightCountdown = 0;
	public float maxCountdown = 0.5f;
	Component[] boxes;
	// Use this for initialization
	void Start () {
		boxes = GetComponentsInChildren<Component>();
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
		foreach (Component box in boxes) {
			if (box is CarryProperties) {
				// If the box has been touched, it stays visible
				box.gameObject.SetActive(state || (box as CarryProperties).touched);
			} else {
				box.gameObject.SetActive(state);
			}
		}
	}
}
