using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Traders : MonoBehaviour {

    public GameObject player;

    public Text myText;
    public float maxTradeDistance = 69f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        
        if (Vector3.Distance(player.transform.position, this.transform.position) < maxTradeDistance)
        {
            myText.enabled = true;
            Debug.Log("Enter");
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
