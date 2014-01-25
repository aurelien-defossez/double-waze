using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionStay(Collision collider)	{
		Debug.Log (collider);
		if (Input.GetButton ("Action")) { 
			GameObject obj = collider.gameObject;
			if (obj.gameObject.tag == "DynamicObject") {
				Debug.Log ("DynamicObject found");
				obj.transform.parent = gameObject.transform;
				obj.transform.position = gameObject.transform.position - gameObject.transform.forward;
				//pickedUpObject = hit.collider.gameObject;
				//hit.collider.gameObject.transform.parent = paren.transform; //attach the object to the camera so it moves along with it.
				//hit.collider.gameObject.transform.position = transform.position - transform.forward; //might need changing as it's untested.
			}
		}
	}
}
