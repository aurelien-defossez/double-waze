using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {
	public GameObject target1;
	public GameObject target2;
	public float duration;

	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		timer = duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < duration) {
			timer += Time.deltaTime;

			if (timer >= duration) {
				Activate(false);
			}
		}
	}

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Action"))
        {
            if (timer >= duration)
            {
                timer = 0.0f;
				Activate(true);
            }
        }
	}
	
	void Activate(bool active) {
		target1.GetComponent<PlatformScript>().OnButtonActivated(active);
		target2.GetComponent<PlatformScript>().OnButtonActivated(active);
	}
}
