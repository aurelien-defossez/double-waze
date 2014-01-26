using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public int numberTrigger;
	// Le prefab de la clé
	public GameObject ClePrefab;
	// Un Empty GameObject qui me sert de position pour le spawn de la clé
	public GameObject CleSpawnPoint;
	private int activated;
	private bool hasSpawned;
	private string keyName = "Key";
	// Use this for initialization
	void Start () {
	
		activated = 0; 
		hasSpawned = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPressureActivated (bool active)
	{
		Debug.Log ("On Pressure Activated");
		activated = active ? activated + 1 : activated - 1;
		Debug.Log (activated);
		if (activated == numberTrigger && !hasSpawned)
		{
			Object cle = Instantiate(ClePrefab, CleSpawnPoint.transform.position, CleSpawnPoint.transform.rotation);
			cle.name = keyName;
			hasSpawned = true;
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("On entre dans le collider");
		Debug.Log (collider.name);
		if (collider.name == keyName)
		{
			Debug.Log ("La cle a été inserré");
			GameObject porte1 = GameObject.Find("Porte01");
			porte1.animation.Play();
			GameObject porte2 = GameObject.Find("Porte02");
			porte2.animation.Play();

		}
	}
}
