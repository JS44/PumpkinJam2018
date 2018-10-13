using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStrengthController : MonoBehaviour {

    public float maxLightStrength = 25;
    private float currentLightStrength;
    private bool isLightOn;
    Light lamp;

	// Use this for initialization
	void Start () {
        lamp = this.GetComponent<Light>();
        currentLightStrength = 25;
        isLightOn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isLightOn)
        {
            lamp.range = currentLightStrength;
        }
        else
        {
            lamp.range = 0;
        }
        
	}

    public float getMaxLight() {return maxLightStrength;}
    public float getCurrentLight() {return currentLightStrength; }
    public void setLight(float change) {currentLightStrength = change * maxLightStrength;}
    public void enableLight(bool enabled) {isLightOn = enabled;}
    public bool isLightEnabled() {return isLightOn;}
}
