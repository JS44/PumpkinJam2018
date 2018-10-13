using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    public Rigidbody rb;
    public MonsterScript monsterForm;

    bool humanForm = true;
    float transformAttempts = 0, transformAttemptsToday = 0;
    public float morphChance = 1f;

    // Use this for initialization
    void Start() {
        if (humanForm)
            StartCoroutine("Wander");
    }

    IEnumerator Wander()
    {
        bool stop = false;
        for (; ; )
        {
            if (stop)
            {
                stop = false;
            }
            else
            {
                Vector3 force = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
                force.y = 0;
                force = force.normalized * Random.Range(1, 5);
                rb.AddForce(force, ForceMode.Impulse);
                stop = true;
            }
            yield return new WaitForSeconds(Random.Range(.25f, 2f));
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public IEnumerator AttemptTransform()
    {
        print("human form = " +humanForm);
        if (transformAttempts >= 5)
        {
            monsterMorph();
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            if (transformAttemptsToday < 3)
            {
                if (Random.value < morphChance)
                {
                    ++transformAttempts;
                    ++transformAttemptsToday;
                }
                StartCoroutine(AttemptTransform());
            }
            else
                transformAttemptsToday = 0;
        }

    }

    void monsterMorph()
    {
        monsterForm.enabled = true;
        monsterForm.monsterModel.enabled = true;
        monsterForm.monsterModel.transform.position = transform.position;
        monsterForm.monsterModel.transform.rotation = transform.rotation;
        GetComponent<MeshRenderer>().enabled = false;
        humanForm = false;
        StopCoroutine(Wander());
    }

    public void changeForm() { humanForm = true; }
}
