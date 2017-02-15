using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : HighlightableObject {
    //inherits Highlight() from highlightableObject as well as normal and glowing material vars
    
    public bool playerNear = false;
    
	void Update () {

        if(playerNear && !isHighlighted)
        {
            Highlight();
            isHighlighted = true;
        }

        if(!playerNear && isHighlighted) //this isn't triggering. why isn't this triggering? im so triggered...
        {
            Debug.Log("Using Unlight confirmed");
            Unlight();
            isHighlighted = false;
        }
	}
}
