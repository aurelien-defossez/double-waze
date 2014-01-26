using UnityEngine;
using System.Collections;

public class ButtonToggle : MonoBehaviour
{

    // Use this for initialization
    public GameObject assignedKey;

    private bool activated = false;

    public void Init(float duration)
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;

        if (Input.GetButtonUp("Action"))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 10))
            {
                if (hit.collider.gameObject != null &&
                    hit.collider.gameObject.tag == "ButtonAssignedToKey")
                {
                    if (hit.collider.gameObject == gameObject)
                        assignedKey.GetComponent<keyScript>().OnButtonActivated(true);
                }
            }
        }
    }
}
