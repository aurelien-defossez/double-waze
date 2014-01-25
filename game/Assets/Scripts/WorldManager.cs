using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	// Use this for initialization
	public World world;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
