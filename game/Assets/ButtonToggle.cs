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

	public void activate()
	{
       assignedKey.GetComponent<keyScript>().OnButtonActivated(true);
	}

    // Update is called once per frame
    void Update()
    {


    }
}
