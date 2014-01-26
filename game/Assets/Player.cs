using UnityEngine;
using System.Collections;

/** Add Constants and stuff like that here */
public class Player : MonoBehaviour
{
    public World world = World.Real;

    private GameObject pickedUpObject;
    public Camera camera;

    public string action;

    private bool canAction = false;

    public void Update()
	{
        canAction = false;
        if (action == "Action")
        {
            if (Input.GetButton("Action"))
            {
                canAction = true;
            }
        }
        else if (action == "Action2")
        {
            if (Input.GetAxis("Action2") > 0.1)
                canAction = true;
        }
        if (canAction)
		{ 
			RaycastHit hit;

			Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			//Debug.DrawRay(ray.origin, ray.direction, Color.red);


			if (Physics.Raycast (ray.origin, ray.direction,  out hit, 10))
			{ 
				if (hit.collider.gameObject != null)
				{
					Debug.Log("Object not found");
				}

				if (hit.collider.gameObject.tag == "DynamicObject")
				{
					Debug.Log("DynamicObject found");
					pickedUpObject = hit.collider.gameObject;
					pickedUpObject.transform.parent = transform; //attach the object to the camera so it moves along with it.
					pickedUpObject.transform.position = transform.position + (transform.forward * 1.1f); // put the box far enough not to collide it
				}
                else if (hit.collider.gameObject.tag == "ButtonAssignedToKey")
                {
                    hit.collider.gameObject.GetComponent<ButtonToggle>().activate();
                }
				else
				{
					Debug.Log("DynamicObject not found");
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

