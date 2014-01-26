using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public float playButtonY = Screen.height * .5f;

	public AudioClip buttonSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);

		if (GUI.Button (new Rect (
			Screen.width * .25f, playButtonY, 
			Screen.width * .5f, Screen.height * .1f), "Play Game")) {
			yield return new WaitForSeconds(1);
			Application.LoadLevel(1);
		}
	}
}
