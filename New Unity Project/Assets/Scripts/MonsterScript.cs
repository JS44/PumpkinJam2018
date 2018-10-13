using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

	float maxHP, moveSpeed, dps;
	float currHP;

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

	}


	//monster takes damage
	public void takeDamage(float damage){currHP -= damage;}
}
