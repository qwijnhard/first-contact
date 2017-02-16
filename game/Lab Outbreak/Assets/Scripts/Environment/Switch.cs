using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InteractibleObject {

    public GameObject linked;
	
    void Start()
    {
        if (linked == null)
        {
            Debug.Log(this.gameObject.name +" is not linked to a functional object!");
        }
    }

	public override void Update () {
        base.Update();

		if(isHighlighted && playerNear)
        {
            if (Input.GetButtonDown("Interact"))
            {
                linked.GetComponent<FunctionalObject>().operate = true;
            }
        }
	}
}
