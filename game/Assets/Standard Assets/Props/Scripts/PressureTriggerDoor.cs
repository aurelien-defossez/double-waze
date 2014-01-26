﻿using UnityEngine;
using System.Collections;

public class PressureTriggerDoor : MonoBehaviour {
	public GameObject target;
	
	private int colliderCount = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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
		//Debug.Log ("Activé");
		target.GetComponent<DoorScript>().OnPressureActivated(active);
	}
}