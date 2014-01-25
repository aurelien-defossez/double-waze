using UnityEngine;
using System.Collections;

public class netManager : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initServer(int connections, int listenPort, bool nat)
	{
		Network.InitializeServer(connections, listenPort, nat);
	}

	public bool isServer()
	{
		return Network.isServer;
	}

	public void Connect(string ipAdress, int listenPort)
	{
		Network.Connect(ipAdress, listenPort);
	}


	public Transform playerPrefab;
	
	void spawnPlayer()
	{
		Debug.Log ("zezefzefzf");
		Object myTransform = Network.Instantiate(playerPrefab, new Vector3(0,3,0), Quaternion.identity, 0);
	}

	
	IEnumerator loadcoroutine()
	{
		yield return Application.LoadLevelAsync("Test scene");
		spawnPlayer ();
	}
	void OnServerInitialized()
	{
		//Application.LoadLevel("Test scene");
		StartCoroutine(loadcoroutine ());
	}
	
	void OnConnectedToServer()
	{
		StartCoroutine(loadcoroutine ());
	}
}
