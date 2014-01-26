using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Bind "PlaqueMonteCharge" to "MonteCharge"
		GetPlatformScript("MonteCharge").Init(new Vector3(0, 4.7f, 0), 1.0f);
		GetPressureTrigger("PlaqueMonteCharge").AddEventListener(GetPlatformScript("MonteCharge").OnPressureActivated);

		// Bind "InterrupteurLumiereGlobale" to "LumiereGlobale"
		GetLeverScript("InterrupteurLumiereGlobale").AddEventListener(GetLightScript("LumiereGlobale").OnLeverActivated);

		// Bind "InterrupteurLumiere1-1" to "Lumiere1-1"
		GetLeverScript("InterrupteurLumiere1-1").AddEventListener(GetLightScript("Lumiere1-1").OnLeverActivated);
		
		// Bind "InterrupteurLumiere1-2" to "Lumiere1-2"
		GetLeverScript("InterrupteurLumiere1-2").AddEventListener(GetLightScript("Lumiere1-2").OnLeverActivated);
		
		// Bind "Bouton1" to "Escalier1"
		GetButtonTrigger("Bouton1").Init(3.0f);
		GetPlatformScript("Escalier1").Init(new Vector3(2.0f, 0, 0), 1.0f);
		GetButtonTrigger("Bouton1").AddEventListener(GetPlatformScript("Escalier1").OnButtonActivated);
		
		// Bind "Bouton2" to "Escalier2"
		GetButtonTrigger("Bouton2").Init(3.0f);
		GetPlatformScript("Escalier2").Init(new Vector3(2.0f, 0, 0), 1.0f);
		GetButtonTrigger("Bouton2").AddEventListener(GetPlatformScript("Escalier2").OnButtonActivated);

		// Bind "Bouton3" to "Escalier3"
		GetButtonTrigger("Bouton3").Init(3.0f);
		GetPlatformScript("Escalier3").Init(new Vector3(2.0f, 0, 0), 1.0f);
		GetButtonTrigger("Bouton3").AddEventListener(GetPlatformScript("Escalier3").OnButtonActivated);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	PressureTrigger GetPressureTrigger(string name) {
		return  (PressureTrigger) GameObject.Find(name).GetComponent(typeof(PressureTrigger));
	}
	
	PlatformScript GetPlatformScript(string name) {
		return  (PlatformScript) GameObject.Find(name).GetComponent(typeof(PlatformScript));
	}
	
	LeverScript GetLeverScript(string name) {
		return  (LeverScript) GameObject.Find(name).GetComponent(typeof(LeverScript));
	}
	
	LightScript GetLightScript(string name) {
		return  (LightScript) GameObject.Find(name).GetComponent(typeof(LightScript));
	}
	
	ButtonTrigger GetButtonTrigger(string name) {
		return  (ButtonTrigger) GameObject.Find(name).GetComponent(typeof(ButtonTrigger));
	}


    keyScript GetKeyScript(string name)
    {
        return (keyScript)GameObject.Find(name).GetComponent(typeof(keyScript));
    }
}
