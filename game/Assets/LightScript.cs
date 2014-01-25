using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnLeverActivated(bool active) {
		print ("onLeverActivated " + active);
		gameObject.light.enabled = active;
	}
}
