using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

	public int connections = 2;
	public int listenPort = 1672;
	public string ipAdress = "127.0.0.1";
	public GUIContent outPut = new GUIContent();
	private bool isDream =  false;
	private bool isReal;

	private netManager netManager;

	void Start()
	{
		outPut.text = "Test";
		isReal = !isDream;

		netManager = GameObject.Find ("NetworkManager").GetComponent<netManager>();

	}
	void OnGUI()
	{
		GUI.Label(new Rect(10, 100, 400, 400), outPut);
		isDream = GUI.Toggle (new Rect (200, 10, 100, 30), !isReal, "DreamPlayer");
		isReal = GUI.Toggle (new Rect (350, 10, 100, 30), !isDream, "RealPlayer");
		ipAdress = GUI.TextField (new Rect (200, 60, 150, 30), ipAdress);
		if (GUI.Button(new Rect(10, 10, 150, 30), "Host a game"))
		{

			outPut.text = "Host a game";

			//Network.InitializeServer(connections, listenPort, false);
			GameObject.Find("WorldManager").GetComponent<WorldManager>().world = isDream ? World.Dream : World.Real;

			netManager.initServer(connections, listenPort, false);

			if (netManager.isServer())
			{
				outPut.text = "The server is launched";
			}
			//ipAdress =  Network.player.ipAddress;
		}
		if (GUI.Button (new Rect (10, 60, 150, 30), "Join a game"))
		{
			GameObject.Find("WorldManager").GetComponent<WorldManager>().world = isDream ? World.Real : World.Dream;

			Debug.Log ("Join a game");
			outPut.text = "Join a game at " + ipAdress;
			netManager.Connect(ipAdress, listenPort);

		}
//		if (Network.isServer)
//		{
//			if (Network.connections.Length > 0)
//				outPut.text = "A client is connected";
//			else
//				outPut.text = "Waiting for a client to connect at " + ipAdress;
//		}
//		if (Network.isClient)
//			outPut.text = "The client is connected";
	}

}
