using UnityEngine;
using System.Collections;

public class FifthLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (GroupTrigger comp in GetComponentsInChildren<GroupTrigger>()) {
			Debug.Log ("Registering handler for group " + comp.triggeredGroup);
			comp.onTrigger += new GroupTriggerHandler(this, comp.triggeredGroup).enableGroup;
		}
		transform.Find ("levier").GetComponent<Trigger> ().onTrigger += lastLight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void lastLight(bool on) {
		Debug.Log ("Last light on: " + on);
	}


	public class GroupTriggerHandler {

		private int groupId;
		private MonoBehaviour level;

		public GroupTriggerHandler(MonoBehaviour level, int groupId) {
			this.level = level;
			this.groupId = groupId;
		}

		public void enableGroup(bool enable) {
			foreach (GroupProperty comp in level.GetComponentsInChildren<GroupProperty>()) {
				if (comp.group == groupId) {
					Light light = comp.gameObject.GetComponent<Light>();
					if (light) light.enabled = enable;
					
					MeshRenderer renderer = comp.gameObject.GetComponent<MeshRenderer>();
					if (renderer) renderer.enabled = enable;
				}
			}
			
		}
	}

}
