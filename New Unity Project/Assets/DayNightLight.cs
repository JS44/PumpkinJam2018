using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightLight : MonoBehaviour {

    public float rotateSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.left, rotateSpeed*Time.deltaTime);
	}
}
