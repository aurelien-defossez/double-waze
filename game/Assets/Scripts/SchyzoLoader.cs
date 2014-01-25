using UnityEngine;
using System.Collections;

/** Takes care of loading the proper element for objects that are not viewed the same way in both worlds*/
public class SchyzoLoader : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Component[] children = this.GetComponentsInChildren<Renderer> ();

		if (children.Length <= 1) return; // To avoid errors and stuff when there are no 2 versions of the object

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
