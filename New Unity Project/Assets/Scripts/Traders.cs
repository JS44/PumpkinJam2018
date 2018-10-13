using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Traders : MonoBehaviour {

    private GameObject player;

    public GameObject myText;
    private MeshRenderer textRender;
    private TextMesh textMesh;
    public float maxTradeDistance = 69f;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textRender = myText.GetComponent<MeshRenderer>();
        textMesh = myText.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        
        if (Vector3.Distance(player.transform.position, this.transform.position) < maxTradeDistance)
        {
            textRender.enabled = true;
        }
        else
        {
            textRender.enabled = false;
        }
    }

    void OnMouseExit()
    {
        textRender.enabled = false;
    }
}
