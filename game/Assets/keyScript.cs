using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour
{

    public Material blueMat;
    public Material redMat;
    public Material greenMat;
    public int selector = 0;

    // Use this for initialization
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {

    }



    public void OnButtonActivated(bool active)
    {
        if (selector == 0)
            renderer.material = blueMat;
        else if (selector == 1)
            renderer.material = redMat;
        else
            renderer.material = greenMat;
        ++selector;
        if (selector > 2)
            selector = 0;
    }

}