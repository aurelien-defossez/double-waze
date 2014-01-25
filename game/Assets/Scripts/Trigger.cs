using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	bool activated = false;
	public int duration = 3;
	public delegate void callback();
	
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
		yield return new WaitForSeconds(duration);
		activated = false;
	}
	
	void Update()
	{
		if (activated)
		{
			transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		}
	}
}

