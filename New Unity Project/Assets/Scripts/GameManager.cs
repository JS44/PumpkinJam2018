using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerScript player;

	//going to be DAWN, DAY, DUSK, DARK
	string timeOfDay;
	
	int numNPCs;

	// Use this for initialization
	void Start () {
		timeOfDay = "DAY";
	}
	
	// Update is called once per frames
	void Update () {
		
	}
	
	//called by player death
	public void gameOver()
	{
	}

	//used when the sun hits a horizon box
	public void setToD(string tod) {timeOfDay = tod;}
	public string getToD()	{return timeOfDay;}
	public int getNPCCount()	{return numNPCs;}
}
