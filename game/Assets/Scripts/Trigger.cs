using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	// Used to subscribe to the trigger. Do trigger += function to be notified when the object is triggered
	public delegate void trigger(bool on); 

	public float disabledAfterSeconds = 3;
	public bool debugRotation = true;

	private bool activated = false;
	public event trigger onTrigger;
	

	void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonUp("Action"))
		{
			Debug.Log ("Hello");
			StartCoroutine(AnimateCube());
		}
		
	}
		
	/* Timer, pour l'animation du cube. Déclenche un truc et l'arrete 3s après.
	 Se lance avec StartCoroutine(AnimateCube(42))*/
	IEnumerator AnimateCube()
	{
		activated = true;
		onTrigger (true);

		if (disabledAfterSeconds > 0)
		{
			yield return new WaitForSeconds(disabledAfterSeconds);
			activated = false;
			onTrigger (false);
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

