using UnityEngine;
using System.Collections;

public class LadderTrigger : Trigger {

	public GameObject ladder;

	// Use this for initialization
	void Start () {
		onTrigger += ladder.GetComponent<Ladder>().deploy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
