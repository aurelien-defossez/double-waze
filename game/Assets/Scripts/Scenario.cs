using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LeverScript leverScript;
		SwitchedLight switchedLight;
		LightScript lightScript;
		PressureTrigger pressureTrigger;
		PlatformScript platformScript;

		/*
		// Bind lever1 to light1
		leverScript = (LeverScript) GameObject.Find("lever1").GetComponent(typeof(LeverScript));
		switchedLight = (SwitchedLight) GameObject.Find("light1").GetComponent(typeof(SwitchedLight));
		leverScript.AddEventListener(switchedLight.OnLeverActivated);
		
		// Bind lever2 to light2
		leverScript = (LeverScript) GameObject.Find("lever2").GetComponent(typeof(LeverScript));
		switchedLight = (SwitchedLight) GameObject.Find("light2").GetComponent(typeof(SwitchedLight));
		leverScript.AddEventListener(switchedLight.OnLeverActivated);
		*/

		// Bind "PlaqueMonteCharge" to "MonteCharge"
		GetPressureTrigger("PlaqueMonteCharge").AddEventListener(GetPlatformScript("MonteCharge").OnPressureActivated);

		// Bind "InterrupteurLumiereGlobale" to "LumiereGlobale"
		GetLeverScript("InterrupteurLumiereGlobale").AddEventListener(GetLightScript("LumiereGlobale").OnLeverActivated);

		// Bind "InterrupteurLumiere1-1" to "Lumiere1-1"
		GetLeverScript("InterrupteurLumiere1-1").AddEventListener(GetLightScript("Lumiere1-1").OnLeverActivated);
		
		// Bind "InterrupteurLumiere1-2" to "Lumiere1-2"
		GetLeverScript("InterrupteurLumiere1-2").AddEventListener(GetLightScript("Lumiere1-2").OnLeverActivated);
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
}
