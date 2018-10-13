using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestController : MonoBehaviour {

    public GameObject tree;
    private GameObject player;
    public int numTrees = 50;
    public float heightOffset = 1;
    public float radius = 1;
    public float raycastDistance = 1;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < numTrees; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));
            RaycastHit hit;
            Physics.SphereCast(pos, radius, Vector3.down, out hit, raycastDistance);

            if(hit.collider != null)
            {
                if (hit.collider.tag == "Ground")
                {
                    GameObject newTree = Instantiate(tree, hit.point + Vector3.up * heightOffset, tree.transform.rotation);
                    newTree.GetComponent<NavMeshObstacle>().carving = true;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
