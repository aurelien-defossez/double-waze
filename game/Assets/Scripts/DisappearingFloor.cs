using UnityEngine;
using System.Collections;

public class DisappearingFloor : MonoBehaviour {

	public int disappearsForSeconds = 1;

	private GameObject floor;
	private GameObject lights;

	// Use this for initialization
	void Start () {
		floor = transform.Find ("Sol").gameObject;
		lights = transform.Find ("Lumières").gameObject;

		foreach (Trigger t in lights.GetComponentsInChildren<Trigger>()) {
			t.onTrigger += disableFloor;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	/*
	public void onFloorTrigger() {
		StartCoroutine(trigger());
	}*/

	/* Diables the colliders and then enables them after a few seconds */
	void disableFloor(bool disabled) {
		Debug.Log ("Floor disabled: " + disabled);
		Collider[] colliders = floor.GetComponentsInChildren<BoxCollider> ();
		foreach (BoxCollider collider in colliders) {
			collider.enabled = !disabled;
		}/*
		yield return new WaitForSeconds(disappearsForSeconds);
		foreach (BoxCollider collider in colliders) {
			collider.enabled = true;
		}*/
	}
}
