using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public float climbSpeed = 0.05f;
	public Vector3 top;
	public Vector3 bottom;

	public bool deployed; 

	// current position on the ladder, from  0 to 1
	private float position = 0.1f;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<BoxCollider> ().enabled = deployed;

		if (gameObject.GetComponent<Trigger> ())
			gameObject.GetComponent<Trigger> ().onTrigger += onTrigger;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTrigger(bool on) {
		Debug.Log ("ladder activated: " + on);
		gameObject.GetComponent<Animation> ().Play ("Take 001"); // Doesn't work?!?

	}

	void OnTriggerStay(Collider other) {
		if (Input.GetButton ("Action")) {
			Component[] comps = GetComponentsInChildren<Transform> ();
			foreach (Transform t in comps) {
				if (t.gameObject.name == "Top Anchor") top = t.position;
				else if (t.gameObject.name == "echelle014") bottom = t.position;
				//else Debug.Log(t.gameObject.name);
			}

			position += climbSpeed;
			other.gameObject.transform.position = Vector3.Lerp (bottom, top, position);
		} else {
			position = 0.1f;
		}
	}

	public void deploy(bool bleh) {
		GetComponent<Animation> ().Play ();
		gameObject.GetComponent<BoxCollider> ().enabled = true;
	}


}
