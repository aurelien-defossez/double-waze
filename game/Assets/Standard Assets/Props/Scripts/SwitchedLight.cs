using UnityEngine;
using System.Collections;

public class SwitchedLight : MonoBehaviour {
	private Color RED = new Color(1, 0, 0);
	private Color GREEN = new Color(0.25f, 1, 0.25f);

	// Use this for initialization
	void Start () {
		OnLeverActivated(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLeverActivated(bool active) {
		gameObject.light.color = active ? GREEN : RED;
	}
}
