using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        StartCoroutine("Wander");
    }

    IEnumerator Wander()
    {
        bool stop = false;
        for(;;)
        {
            if (stop)
            {
                stop = false;
            }
            else
            {
                Vector3 force = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
                force.y = 0;
                force = force.normalized * Random.Range(1,5);
                rb.AddForce(force, ForceMode.Impulse);
                stop = true;
            }
            yield return new WaitForSeconds(Random.Range(.25f, 2f));
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
