using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStrengthController : MonoBehaviour {

    public float maxLightStrength = 25;
    Light lamp;

	// Use this for initialization
	void Start () {
        lamp = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lamp.range = maxLightStrength;
	}
}
