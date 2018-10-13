using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour {

    public GameObject tree;
    public int numTrees = 50;
    public float heightOffset = 1;
    public float radius = 1;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numTrees; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));
            RaycastHit hit;
            Physics.SphereCast(pos, radius, Vector3.down, out hit);
            if (hit.collider.tag == "Floor")
            {
                Object.Instantiate(tree, hit.point + Vector3.up*heightOffset, tree.transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
