using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public int numberTrigger;
	public GameObject ClePrefab;
	public GameObject CleSpawnPoint;
	private int activated;
	// Use this for initialization
	void Start () {
	
		activated = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPressureActivated (bool active)
	{
		activated = active ? activated + 1 : activated - 1;
		if (active)
			Debug.Log ("Un trigger a été activé");
		Debug.Log (activated);
		if (activated == numberTrigger)
		{
			Debug.Log ("Tous les triggers sont activés");
			Instantiate(ClePrefab, CleSpawnPoint.transform.position, CleSpawnPoint.transform.rotation);
		}
	}
}
