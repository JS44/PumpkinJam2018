using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Traders : MonoBehaviour {

    private GameObject player;
    private PlayerScript playerScript;

    public GameObject myText;
    private MeshRenderer textRender;
    private TextMesh textMesh;
    public float maxTradeDistance = 69f;

    //0 = Doctor
    //1 = Smith
    //2 = Priest
    public int traderType;

    public float restoreAmount; //Proportion of max HP to heal - .25, for example
    public float tradePrice;    //if we use more resources, just split this into tradePriceWood, tradePriceRock, etc

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textRender = myText.GetComponent<MeshRenderer>();
        textMesh = myText.GetComponent<TextMesh>();
        playerScript = player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void trade()
    {
        textRender.enabled = true;
        if (playerScript.getWood() > tradePrice && Input.GetMouseButtonDown(0))
        {
            playerScript.spendWood(3);
            if (traderType == 0)        //doc
                playerScript.hurtHP(-1f * restoreAmount);
            else if (traderType == 1)   //blacksmith
                playerScript.hurtAxeHP(-1f * restoreAmount);
            else if (traderType == 2)   //priest
                playerScript.hurtSanity(-1f * restoreAmount);
        }
    }

    void OnMouseOver()
    {
        
        if (Vector3.Distance(player.transform.position, this.transform.position) < maxTradeDistance)
        {
            trade();
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
