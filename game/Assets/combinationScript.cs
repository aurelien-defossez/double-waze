using UnityEngine;
using System.Collections;

public class combinationScript : MonoBehaviour {

    public int[] combination;
    public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(GameObject.Find("KeyLeft").GetComponent<keyScript>().selector);
        //Debug.Log(GameObject.Find("KeyMiddle").GetComponent<keyScript>().selector);
        //Debug.Log(GameObject.Find("KeyRight").GetComponent<keyScript>().selector);
      //  Debug.Log(" ");

	    if (GameObject.Find("KeyLeft").GetComponent<keyScript>().selector == combination[0] &&
            GameObject.Find("KeyMiddle").GetComponent<keyScript>().selector == combination[1] &&
            GameObject.Find("KeyRight").GetComponent<keyScript>().selector == combination[2])
        {
           // Debug.Log("found");
        }
	}
}
