using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	public enum TriggerType{Action, Presence};
	// Used to subscribe to the trigger. Do trigger += function to be notified when the object is triggered
	public delegate void trigger(bool on); 

	public float disabledAfterSeconds = 0;
	public bool debugRotation = false;
	public TriggerType type = TriggerType.Action;
	private bool activated = false;
	public event trigger onTrigger;

	void OnTriggerEnter(Collider other) {
		if (type == TriggerType.Presence) {
			activate (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (type == TriggerType.Presence) {
			activate (false);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (type == TriggerType.Action) {
			if (Input.GetButtonUp ("Action")) {
				StartCoroutine (DoStuff ());
			}
		
		}
	}
		
	/* Timer, pour l'animation du cube. Déclenche un truc et l'arrete <disabledAfterSeconds> sec après.
	 Se lance avec StartCoroutine(DoStuff())*/
	IEnumerator DoStuff()
	{
		activate (true);
		if (disabledAfterSeconds > 0)
		{
			yield return new WaitForSeconds(disabledAfterSeconds);
			activate (false);
		}
	}

	public void activate(bool activated ) {
		this.activated = activated;
		if (onTrigger != null) {
			onTrigger (activated);
		}
	}

	void Update()
	{
		if (activated && debugRotation)
		{
			transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
		}
	}
}

