using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour {

	public float maxHP = 100, moveSpeed = 1, dps = 10;
	float currHP;
	public WanderScript humanForm;
    private MoveTo enemy;
    private MeshRenderer mesh;
    private NavMeshAgent agent;
	public MeshRenderer monsterModel;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<MoveTo>();
        mesh = GetComponent<MeshRenderer>();

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
        humanForm.enabled = true;
        agent.enabled = false;
        enemy.enabled = false;
		humanForm.changeForm();
		mesh.enabled = true;

		monsterModel.enabled = false;
		this.enabled = false;
    }

	//monster takes damage
	public void takeDamage(float damage){currHP -= damage;}
}
