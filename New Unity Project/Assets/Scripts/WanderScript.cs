using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    //this is actually the NPC script in general, not just wandering
    public Rigidbody rb;
    public MonsterScript monsterForm;
    public float transformChance = .25f;    //Default to 25% change to transform into a monster 4 seconds into night 2
    bool humanForm = true;

    int transformSuccessTotal = 0, transformAttemptTonight = 0;

	// Use this for initialization
	void Start () {
        monsterForm = this.GetComponent<MonsterScript>();
        StartCoroutine("Wander");
    }

    //Randomly wander around
    IEnumerator Wander()
    {
        if (humanForm)
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
    }

    //Coroutine that every 2 seconds for the first 6 seconds of night randomly determines if an NPC will turn into monster
    public IEnumerator AttemptTransform()
    {
        if (transformSuccessTotal >= 5)
        {
            monsterMorph();
            yield return new WaitForSeconds(0f);
        }
        else
        {
            yield return new WaitForSeconds(2f);
            if (transformSuccessTotal < 5 && transformAttemptTonight < 3)
            {
                //attempt a transform and rerun the coroutine
                //Transform after 5 attempts total, but only attempt 3 times per night
                if (Random.value < .5f) //50% change to increase odds
                    transformSuccessTotal++;
                transformAttemptTonight++;
                StartCoroutine(AttemptTransform());
            }
            else if (transformSuccessTotal >= 5)
                monsterMorph();
            else if (transformAttemptTonight >= 3)
                transformAttemptTonight = 0;
        }
    }

    void monsterMorph()
    {
        monsterForm.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        monsterForm.monsterModel.transform.position = transform.position;
        monsterForm.monsterModel.transform.rotation = transform.rotation;
        monsterForm.monsterModel.enabled = true;
        humanForm = false;
        print("transforming into monster");
    }
    // Update is called once per frame
    void Update () {
        
    }

    public void changeForm(){humanForm = true;}
}
