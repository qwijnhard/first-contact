using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMonsterAI : MonoBehaviour {

    private NavMeshAgent nav;

    //object's AI thought process state
    private string state = "Idle";

    private string previousState; //use this if monsters go back to previous state if de-aggroed
    
    //read positions of these objects to set as patrolling markers
    public GameObject[] patrolpoints;

    //object to be chased
    private GameObject target;
    
    //determinants for random waypoint picking (time monster stands still)
    public float idleMin;
    public float idleMax;

    //animation state triggers for the object's child object with an animator
    public bool moving;
    public bool attacking;
    public bool dead;

    //makes the coroutine trigger only once from being idle. without this, it would look for random points untill obj starts moving, causin stuttering.
    private bool coroutineTriggered = false;
    
	void Start () {

        nav = GetComponent<NavMeshAgent>();

	}
	
	void Update ()
    {
        //if you have a target, chase it
        if(target != null)
        {
            nav.SetDestination(target.transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (state == "Idle")
        {
            //[if you're not moving]
            //wait for a random amount of time between "idleMin" & "idleMax"
            //select random waypoint, move to waypoint
            //[if you're not moving]

            if (!moving && !coroutineTriggered)
            {
                coroutineTriggered = true;
                StartCoroutine(RandWait(idleMin, idleMax));
            }

            if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
            {
                moving = false;
            }
            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "hostile"
        }

        if (state == "Searching")
        {
            //set "target" to null
            //start "suspicion" timer, set waypoint near player, go to waypoint, wait, set new waypoint with decreased accuracy, repeat.
            //if "suspicion timer runs out, set state to Idle"
            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "hostile"
        }

        if (state == "Hostile")
        {
            //move to player until in attack range, then attack
            //if player leaves sight radius, start "track" timer
            //if track timer runs out, set state to "searching"
        }

        if (state == "Patrolling")
        {
            //move to each "patrolpoints" array and repeat.
            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "hostile"
        }

        if (state == "Animating")
        {
            //go to specific location with specific rotation
            //play an animation and repeat
            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "hostile"
        }
    }

    IEnumerator RandWait(float min, float max)
    {
        float rand = Random.Range(min, max);
        yield return new WaitForSeconds(rand);
        Vector3 randPos = Random.insideUnitSphere * 5;
        NavMeshHit navHit;
        //input: me+randpos, output to navhit, use area size of 5f, on area of navmesh.allareas
        NavMesh.SamplePosition(transform.position + randPos, out navHit, 10f, NavMesh.AllAreas);
        nav.SetDestination(navHit.position);
        moving = true;
        coroutineTriggered = false;
    }

}
