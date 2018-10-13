using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traders : MonoBehaviour {

    FirstPersonController player;

    public Text myText;
    public float maxTradeDistance = 69f;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        if (abs(player.transform.position - this.transform.postion) < maxTradeDistance)
        {
            myText.enabled = true;
        }
        else
        {
            myText.enabled = false;
        }
    }

    void OnMouseExit()
    {
        myText.enabled = false;
    }
}
