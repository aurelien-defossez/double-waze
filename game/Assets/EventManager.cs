using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
	public delegate void ActivateDoor1();
	public event ActivateDoor1 OnActivateDoor1;

	public void Update() {
		if (true) {
			OnActivateDoor1();
		}
	}
}