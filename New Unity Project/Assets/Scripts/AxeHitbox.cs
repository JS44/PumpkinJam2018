using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitbox : MonoBehaviour {
	public float damage;


	//axe hitbox is on a layer that only collides with enemies
	void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponent<MonsterScript>().dealDamage(damage);
	}
}
