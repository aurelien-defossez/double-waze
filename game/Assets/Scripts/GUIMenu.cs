using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {

	public int connections = 2;
	public int listenPort = 1672;
	public string ipAdress = "127.0.0.1";
	public GUIContent outPut = new GUIContent();

	void Start()
	{
		outPut.text = "Test";
	}
	void OnGUI()
	{
		GUI.Label(new Rect(10, 100, 400, 400), outPut);
		ipAdress = GUI.TextField (new Rect (200, 60, 150, 30), ipAdress);
		if (GUI.Button(new Rect(10, 10, 150, 30), "Host a game"))
		{
			outPut.text = "Host a game";

			Network.InitializeServer(connections, listenPort, false);
			if (Network.isServer)
			{
				outPut.text = "The server is launched";
			}
			//ipAdress =  Network.player.ipAddress;
		}
		if (GUI.Button (new Rect (10, 60, 150, 30), "Join a game"))
		{
			Debug.Log ("Join a game");
			outPut.text = "Join a game at " + ipAdress;
			Network.Connect(ipAdress, listenPort);

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
	void OnPlayerConnected(NetworkPlayer player)
	{
		//outPut.text = "CONNECTION !!!";
		Application.LoadLevel ("Test scene");
	}
}
