using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void Action();
	public static event Action OnAction;

	void OnGUI() {
		if (Input.GetKeyDown ("space")) {
			if (OnAction != null) {
				OnAction();
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
