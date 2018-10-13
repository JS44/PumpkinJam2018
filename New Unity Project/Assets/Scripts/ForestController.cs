using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour {

    public GameObject tree;
    public int numTrees = 50;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numTrees; i++)
        {
            Object.Instantiate(tree, new Vector3(Random.Range(-100, 100), 1f, Random.Range(-100, 100)), tree.transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
