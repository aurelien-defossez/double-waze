using UnityEngine;
using System.Collections;

public class ReflectableLight : MonoBehaviour {

	private GameObject revealedObject;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		Transform blorg = transform.Find ("RevealedObject");
		if (blorg != null && blorg.gameObject != null) {
			revealedObject = blorg.gameObject;
			Reveal results = revealedObject.GetComponent<Reveal> ();
			if (results != null) {
				results.activate(true);
			}
		}
	}
}
