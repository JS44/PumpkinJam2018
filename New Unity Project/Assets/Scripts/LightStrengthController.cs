using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStrenghtController : MonoBehaviour {

    public float lightStrength = 0;
    Light lamp;

	// Use this for initialization
	void Start () {
        lamp = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lamp.areaSize = new Vector2(lightStrength, lightStrength);
	}
}
