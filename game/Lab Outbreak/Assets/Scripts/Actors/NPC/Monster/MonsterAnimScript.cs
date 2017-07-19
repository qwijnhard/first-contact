using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimScript : MonoBehaviour {

    private Animator anim;

	void Start () {

        anim = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {


        if (GetComponentInParent<BasicMonsterAI>().moving)
        {
            anim.SetBool("moving", true);
        }

        if (!GetComponentInParent<BasicMonsterAI>().moving)
        {
            anim.SetBool("moving", false);
        }

        if (!GetComponentInParent<BasicMonsterAI>().attacking)
        {
            anim.SetBool("attacking", true);
        }

        if (!GetComponentInParent<BasicMonsterAI>().attacking)
        {
            anim.SetBool("attacking", false);
        }

        if (!GetComponentInParent<BasicMonsterAI>().dead)
        {
            anim.SetBool("dead", true);
        }

        if (!GetComponentInParent<BasicMonsterAI>().dead)
        {
            anim.SetBool("dead", false);
        }
    }
}
