using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMonsterAI : MonoBehaviour {

    private NavMeshAgent nav;

    //used to switch between chasing and attacking
    private bool chasing;
    private float attackRange;

    //object's AI thought process state
    public string state = "Idle";
    
    //the eyes child-object
    public Transform eyes;

    //read positions of these objects to set as patrolling markers
    public GameObject[] patrolpoints;
    
    //object to be chased
    public GameObject target;
    
    //determinants for random waypoint picking (time monster stands still)
    public float idleMin;
    public float idleMax;

    //how long after losing sight the target remains targeted
    public float chaseTimer = 3;
    private float baseChaseTimer;
    public float suspicionTimer = 5;
    private float baseSuspicionTimer;

    //animation state triggers for the object's child object with an animator (see MonsterAnimScript.cs)
    public bool moving;
    public bool attacking;
    public bool dead;

    //makes the coroutine trigger only once from being idle. without this, it would look for random points untill obj starts moving, causin stuttering.
    private bool coroutineTriggered = false;
    

    /*
     logic for damage source:
     entity fires bullet. bullet has Tags.cs with string var "source" that gets the shooter's gameObject.name assigned somehow.
     when hit, bullet sets monster's target to the damage source (possible in-game exploit: monster will always switch target to most recent damage source)
         
         */


	void Start () {

        nav = GetComponent<NavMeshAgent>();

        baseChaseTimer = chaseTimer;
        baseSuspicionTimer = suspicionTimer;
        chaseTimer = 0;
        suspicionTimer = 0;

	}

    void Update()
    {
        //if you have a target, chase it 
        if (target != null && chasing)
        {
            nav.SetDestination(target.transform.position);
        }

        if (chaseTimer > 0) {
            chaseTimer -= Time.deltaTime;
        }
        if (suspicionTimer > 0)
        {
            suspicionTimer -= Time.deltaTime;
        }

        if (state == "Hostile")
        {
            chasing = true;
        }
        else { chasing = false; }
    }

    private void FixedUpdate()
    {
        if (state == "Idle")
        {
            //if you're not moving: wait for a random amount of time between "idleMin" & "idleMax", then select random waypoint, move to waypoint
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
            //if player directly damages, set state to "Searching"
            StateSwitch();// <=== method incomplete
        }

        if (state == "Searching")
        {
            //start "suspicion" timer, while suspicion timer > 0: set waypoint near player, go to waypoint, wait, set new waypoint with decreased accuracy, repeat.

            //if "suspicion timer runs out, set state to Idle"
            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "hostile"
            StateSwitch();
        }

        if (state == "Hostile")
        {
            //set "target" to player or w/e, set chasing to true while distance > attackRange
            //if distance <= attackRange set chasing to false and attacking to true
            //while attacking, nav.setDestination(null); transform.LookAt(target.transform);
            //if player leaves sight radius, start "track" timer

            //if track timer runs out, set state to "Searching"
            StateSwitch();
        }

        if (state == "Patrolling")
        {
            //move to each "patrolpoints" array and repeat.

            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "Searching"
            StateSwitch();
        }

        if (state == "Animating")
        {
            //go to specific location with specific rotation
            //play an animation and repeat

            //if player enters sight, set state to "hostile"
            //if player directly damages, set state to "Searching"
            StateSwitch();
        }
    }

    IEnumerator RandWait(float min, float max)
    {
        float rand = Random.Range(min, max);
        yield return new WaitForSeconds(rand);
        Vector3 randPos = Random.insideUnitSphere * 5;
        NavMeshHit navHit;
        //input: me+randpos, output to navhit, use area size of 10f, on area: navmesh.allareas
        NavMesh.SamplePosition(transform.position + randPos, out navHit, 10f, NavMesh.AllAreas);
        nav.SetDestination(navHit.position);
        moving = true;
        coroutineTriggered = false;
    }

    //this function is called by the eyes childobject whenever something collides with it
    public void Sight(GameObject eyesConeInput)
    {

        if (GetComponent<Tags>().alive)
        {
            GameObject suspect;

            //if you see anything, check its faction, then do either nothing or set it as "target"
            if (eyesConeInput.GetComponent<Tags>() != null)
            {
                suspect = eyesConeInput;
                if (eyesConeInput.GetComponent<Tags>().player)
                {
                    //if the object's faction is player, set it as target, then "see" the target
                    RaycastHit rayHit;
                    if (Physics.Linecast(transform.position, suspect.transform.position, out rayHit)) //<======= this is merely a bool. if yes, execute everything below
                    {
                        Debug.Log("looking at "+ rayHit.collider.gameObject.name);  // <==== always correctly displays what is actually being looked at
                        target = eyesConeInput;
                        Debug.Log(target.name + " found"); // <==== always displays player if it is intersecting eyes childobject
                        suspect = null;
                        chaseTimer = baseChaseTimer;
                        suspicionTimer = 0;
                        
                    }
                }
            }
        }

        
    }

    private void StateSwitch()
    {
        //transitions out of "Idle"
        //################################

        //chaseTimer > 0, so i've seen a target. starting chase.
        if(state == "Idle" && target != null && chaseTimer > 0)
        {
            state = "Hostile";
        }

        //chaseTimer <= 0, so i havent seen anything before now but something is there/hurt me.
        if (state == "Idle" && target != null && chaseTimer <= 0)
        {
            //if [damage source] has Tags.player, target = [damage source]
            suspicionTimer = baseSuspicionTimer;
            state = "Searching";
        }

        //transitions out of "Searching"
        //################################

        //huh. must've run off.
        if (state == "Searching" && suspicionTimer <= 0 && chaseTimer <= 0)
        {
            state = "Idle";

            if (target != null)
            {
                target = null;
            }
        }

        //chaseTimer > 0, so i've seen a target. starting chase.
        if (state == "Searching" && chaseTimer > 0)
        {
            state = "Hostile";
            
        }

        //transitions out of "Hostile"
        //################################

        if (state == "Hostile" && chaseTimer <= 0)
        {
            suspicionTimer = baseSuspicionTimer;
            state = "Searching";

        }

    }

}
