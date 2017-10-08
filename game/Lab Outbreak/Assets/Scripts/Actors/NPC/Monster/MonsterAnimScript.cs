using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimScript : MonoBehaviour {

    private Animator anim;
    private BasicMonsterAI ai;

	void Start () {

        anim = this.GetComponent<Animator>();
        ai = GetComponentInParent<BasicMonsterAI>();


    }
	
	// Update is called once per frame
	void Update () {


        if (ai.moving)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }

        if (ai.attacking)
        {
            anim.SetBool("attacking", true);
        }
        else
        {
            anim.SetBool("attacking", false);
        }

        if (ai.dead)
        {
            anim.SetBool("dead", true);
        }
        else
        {
            anim.SetBool("dead", false);
        }
    }
}
