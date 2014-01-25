using UnityEngine;
using System.Collections;

public class ValveListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ValveTrigger.OnValveActivated += OnValveActivated;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnValveActivated(string phase, float rotation) {
		gameObject.transform.localEulerAngles = new Vector3 (0, rotation * 2, 0);
	}
}
