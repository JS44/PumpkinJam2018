using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    private GameObject player;
    public float maxNoticeDistance = 20f;
    public float timeBetweenSearch = 10f;
    private NavMeshAgent agent;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < maxNoticeDistance)
        {
            agent.destination = player.transform.position;
        }
        StartCoroutine("SearchForPlayer");
    }


    IEnumerator SearchForPlayer()
    {
        agent.destination = player.transform.position;
        yield return new WaitForSeconds(timeBetweenSearch);
    }
    
}
