using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	public enum TriggerType{Action, Presence};
	// Used to subscribe to the trigger. Do trigger += function to be notified when the object is triggered
	public delegate void trigger(bool on); 

	public float disabledAfterSeconds = 3;
	public bool debugRotation = true;
	public TriggerType type = TriggerType.Action;

	private bool activated = false;
	public event trigger onTrigger;



	void OnTriggerStay(Collider other)
	{
		switch(type) {
		case TriggerType.Action:
			if (! Input.GetButtonUp ("Action")) return;
			break;
		default: 
			break; // always allow
		}

		StartCoroutine (AnimateCube ());
		
	}
		
	/* Timer, pour l'animation du cube. Déclenche un truc et l'arrete <disabledAfterSeconds> sec après.
	 Se lance avec StartCoroutine(AnimateCube())*/
	IEnumerator AnimateCube()
	{
		activated = true;
		if (onTrigger != null) {
			onTrigger (true);
		}

		if (disabledAfterSeconds > 0)
		{
			yield return new WaitForSeconds(disabledAfterSeconds);
			activated = false;
			if (onTrigger != null) {
				onTrigger (false);
			}
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

