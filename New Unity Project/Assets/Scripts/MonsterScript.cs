using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

	public float maxHP, moveSpeed, dps;
	float currHP;
	public WanderScript humanForm;
	public MeshRenderer monsterModel;

	// Use this for initialization
	void Start () {
		currHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (currHP <= 0) die();
	}
	
	//monster death - maybe play animation and then destroy object?
	void die()
	{
		Destroy(this.gameObject);
	}

    public void humanMorph()
    {
        //Turn back into human after the sun rises
		humanForm.changeForm();
		GetComponent<MeshRenderer>().enabled = true;
		monsterModel.enabled = false;
		this.enabled = false;
    }

	//monster takes damage
	public void takeDamage(float damage){currHP -= damage;}
}
