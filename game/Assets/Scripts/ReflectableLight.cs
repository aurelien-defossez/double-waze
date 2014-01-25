using UnityEngine;
using System.Collections;

public class ReflectableLight : MonoBehaviour {

	private GameObject revealedObject;
	

	// Use this for initialization
	void Start () {
		revealedObject = transform.Find ("RevealedObject").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		revealedObject.GetComponent<Reveal>().activate(true);
	}
}
