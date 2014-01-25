using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
	private Vector3 translation = new Vector3(0, 4.7f, 0);
	private float duration = 1.0f;

	private bool activated = false;
	private float timer;
	private Vector3 origin;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		origin = gameObject.transform.position;
		target = origin + translation;
		timer = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < duration) {
			timer = Mathf.Min (timer + Time.deltaTime, duration);

			if (activated) {
				gameObject.transform.position = Vector3.Lerp (origin, target, timer / duration);
			} else {
				gameObject.transform.position = Vector3.Lerp (target, origin, timer / duration);
			}
		}
	}
	
	public void OnPressureActivated(bool active) {
		activated = active;
		timer = duration - timer;
	}
}
