using UnityEngine;
using System.Collections;

/** Takes care of loading the proper element for objects that are not viewed the same way in both worlds*/
public class SchyzoLoader : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Component[] children = this.GetComponentsInChildren<Renderer> ();
		foreach (Component comp in children)
		{
			if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().world == World.Real)
			{
				comp.renderer.enabled = (comp.name == "Real Mesh");
			} 
			else
			{
				comp.renderer.enabled = (comp.name == "Dream Mesh");
			}
		}
	}

}
