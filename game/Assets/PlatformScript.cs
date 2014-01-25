using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
	private float duration;
	private float timer;
	private Vector3 translation;
	private Vector3 origin;
	private Vector3 target;
	private bool activated = false;
	
	public void Init(Vector3 translation, float duration) {
		this.translation = translation;
		this.duration = duration;
	}

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
