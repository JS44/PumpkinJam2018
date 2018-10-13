using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DissapearScript : MonoBehaviour {

    private GameObject player;
    private FirstPersonController playerScript;
    public int cyclesToAppear = 1;

    private DayNightLight dayTimer;
    private MeshRenderer collectibleRender;
    private BoxCollider collectibleCollider;
    private int numCycles;
    private bool addedCycle;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        collectibleRender = this.GetComponent<MeshRenderer>();
        collectibleCollider = this.GetComponent<BoxCollider>();
        dayTimer = GameObject.FindObjectOfType<DayNightLight>();
        numCycles = 0;
        addedCycle = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (dayTimer.IsNight())
        {
            if (!addedCycle)
            {
                addedCycle = true;
                numCycles++;
            }
            if (numCycles >= cyclesToAppear)
            {
                collectibleCollider.enabled = true;
                collectibleRender.enabled = true;
            }
        }
        else
        {
            addedCycle = false;
        }
	}

    void OnMouseOver()
    {

        if (Vector3.Distance(player.transform.position, this.transform.position) < 3 && Input.GetMouseButtonDown(0))
        {
            collectibleCollider.enabled = false;
            collectibleRender.enabled = false;
            numCycles = 0;
            addedCycle = true;
            playerScript.resourceCount++;
        }
    }

}
