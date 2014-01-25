using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
	private float duration;
	private float timer;
	private Vector3 translation;
	private Vector3 origin;
	private Vector3 target;
	private bool initialized = false;
	private bool started = false;
	private bool activated = false;
	
	public void Init(Vector3 translation, float duration) {
		this.translation = translation;
		this.duration = duration;
		initialized = true;
		CheckInit();
	}

	// Use this for initialization
	void Start () {
		started = true;
		CheckInit();
	}

	void CheckInit() {
		if (initialized && started) {
			origin = gameObject.transform.position;
			target = origin + translation;
			timer = duration;
		}
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

	public void OnButtonActivated(bool active) {
		OnPressureActivated(active);
	}
}
