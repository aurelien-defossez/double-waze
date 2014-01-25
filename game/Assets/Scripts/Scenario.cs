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
		pressureTrigger = (PressureTrigger) GameObject.Find("PlaqueMonteCharge").GetComponent(typeof(PressureTrigger));
		platformScript = (PlatformScript) GameObject.Find("MonteCharge").GetComponent(typeof(PlatformScript));
		pressureTrigger.AddEventListener(platformScript.OnPressureActivated);

		// Bind "InterrupteurLumiereGlobale" to "LumiereGlobale"
		leverScript = (LeverScript) GameObject.Find("InterrupteurLumiereGlobale").GetComponent(typeof(LeverScript));
		lightScript = (LightScript) GameObject.Find("LumiereGlobale").GetComponent(typeof(LightScript));
		leverScript.AddEventListener(lightScript.OnLeverActivated);
		
		// Bind "InterrupteurLumiere1-1" to "Lumiere1-1"
		leverScript = (LeverScript) GameObject.Find("InterrupteurLumiere1-1").GetComponent(typeof(LeverScript));
		lightScript = (LightScript) GameObject.Find("Lumiere1-1").GetComponent(typeof(LightScript));
		leverScript.AddEventListener(lightScript.OnLeverActivated);
		
		// Bind "InterrupteurLumiere1-2" to "Lumiere1-2"
		leverScript = (LeverScript) GameObject.Find("InterrupteurLumiere1-2").GetComponent(typeof(LeverScript));
		lightScript = (LightScript) GameObject.Find("Lumiere1-2").GetComponent(typeof(LightScript));
		leverScript.AddEventListener(lightScript.OnLeverActivated);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
