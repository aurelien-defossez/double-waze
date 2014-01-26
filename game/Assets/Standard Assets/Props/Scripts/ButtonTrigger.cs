using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {
	
	public delegate void ButtonActivated(bool active);
	private event ButtonActivated OnButtonActivated = delegate{};

	private float duration;
	private float timer = 0.0f;

	public void Init(float duration) {
		this.duration = duration;
		timer = duration;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < duration) {
			timer += Time.deltaTime;

			if (timer >= duration) {
				OnButtonActivated(false);
			}
		}
	}
	
	public void AddEventListener(ButtonActivated listener) {
		OnButtonActivated += listener;
	}

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Action"))
        {
            if (timer >= duration)
            {
                timer = 0.0f;
                OnButtonActivated(true);
                Debug.Log("Button triggered");
            }
        }
    }
}
