using UnityEngine;
using System.Collections;

/** Add Constants and stuff like that here */
public class Player : MonoBehaviour
{
	public World world = World.Real;
	
	private GameObject pickedUpObject;
	

	public void Update()
	{
		if (Input.GetButton ("Action"))
		{ 
			RaycastHit hit;

			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

			if (Physics.Raycast (ray.origin, ray.direction,  out hit, 10))
			{ 
				if (hit.collider.gameObject != null && 
				    hit.collider.gameObject.tag == "DynamicObject")
				{
					Debug.Log("DynamicObject found");
					pickedUpObject = hit.collider.gameObject;
					pickedUpObject.transform.parent = transform; //attach the object to the camera so it moves along with it.
					pickedUpObject.transform.position = transform.position + (transform.forward * 1.1f); // put the box far enough not to collide it

					CarryProperties prop = pickedUpObject.GetComponent<CarryProperties>();
					if (prop != null) prop.touched = true;

				}
			}
		}
		else if (pickedUpObject != null)
		{ //if player is not holding E but was picking up an object last frame
			pickedUpObject.transform.parent = null; //drop the object
			pickedUpObject = null; //and nullify the object pointer
		}
	}

}

