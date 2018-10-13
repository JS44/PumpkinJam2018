using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameManager gm;
	public GameObject axeHit;
    private MeshRenderer axeHitMesh;
    private SphereCollider axeHitCollider;
	//Vars for the drainables
	public float maxHP, maxSanity, maxAxeHP, maxOil;
	[SerializeField] float currHP, currSanity, currAxeHP, currOil, currWood;
	public float maxAxeDPS, axeDegradation, sanityDrain;
	public float maxBrightness, oilBurnRate, currDrain;
	float currAxeDPS, currBrightness;

	bool attacking;

	void Start () {
		//intialize
		currHP = maxHP;
		currSanity = maxSanity;
		currAxeHP = maxAxeHP;
		currOil = maxOil;
		currAxeDPS = maxAxeDPS;
		currBrightness = maxBrightness;
		currDrain = sanityDrain;

        axeHitMesh = axeHit.GetComponent<MeshRenderer>();
        axeHitCollider = axeHit.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		//check if you're still alive
		if (currHP <= 0) die();
		//Then check for attacking
		if (Input.GetMouseButtonDown(0) && !attacking)
		{
			Attack();
		}
		//Sanity gain/drain
		//Get sanity drain/gain based on day, number of npcs alive, HP, axe condition, lantern oil, etc
		currDrain = sanityDrain / gm.getNPCCount();	//<- this is just an example
		if (currSanity > 0)
		{
			if (gm.getToD() == "DAY")
				currSanity += currDrain * .75f;
			else if (gm.getToD() == "DARK")
				currSanity -= currDrain;
		}
	}

	//Starts the attack
	void Attack()
	{
		StartCoroutine(AttackHitBox());
	}

	void die()
	{
		gm.gameOver();
	}

	//Spawns the attack hitbox
	IEnumerator AttackHitBox()
	{
		attacking = true;
		yield return new WaitForSeconds(.1f);
        axeHitMesh.enabled = true;
        axeHitCollider.enabled = true;
        axeHit.GetComponent<AxeHitbox>().damage = currAxeDPS;
		yield return new WaitForSeconds(0.2f);
        axeHitMesh.enabled = false;
        axeHitCollider.enabled = false;
		attacking = false;
	}

	//Gets/Sets
	public void hurtHP(float damageReceived) {currHP -= damageReceived;}
	public void hurtSanity(float sanityLost) {currSanity -= sanityLost;}
    public void hurtAxeHP(float axeDamage) {currAxeHP = Mathf.Min(1,Mathf.Max(0,currAxeHP - axeDamage));}
    public void spendWood(float woodAmount) {currWood = currWood - woodAmount;}
    public float getHP() {return currHP;}
	public float getSanity() {return currSanity;}
    public float getAxeHP() {return currAxeHP;}
    public float getWood() {return currWood;}
}
