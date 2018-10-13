using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerScript player;
	public DayNightLight time;
	public GameObject[] npcs;

	//going to be DAWN, DAY, DUSK, DARK
	string timeOfDay;
	
	int numNPCs;

	// Use this for initialization
	void Start () {
		timeOfDay = "DAY";
		numNPCs = npcs.Length;
		npcs = GameObject.FindGameObjectsWithTag("NPCs");
	}
	
	// Update is called once per frames
	void Update () {
		if (timeOfDay != "DARK" && time.IsNight())
			startNight();
		else if (timeOfDay != "DAY" && !time.IsNight())
			endNight();
	}
	
	//called by player death
	public void gameOver()
	{
	}
	
	//Changes the time of day
	void startNight()
	{
		timeOfDay = "DARK";
		foreach (GameObject npc in npcs)
		{
			if (npc != null)
				StartCoroutine(npc.GetComponent<WanderScript>().AttemptTransform());
		}

	}
	void endNight()
	{
		timeOfDay = "DAY";
		foreach (GameObject npc in npcs)
		{
			npc.GetComponent<MonsterScript>().humanMorph();
		}

	}

	//used when the sun hits a horizon box
	public void setToD(string tod) {timeOfDay = tod;}
	public string getToD()	{return timeOfDay;}
	public int getNPCCount()	{return numNPCs;}
}
