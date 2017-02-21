using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : HighlightableObject
{
    //inherits Highlight() from highlightableObject as well as normal and glowing material vars

    public bool playerNear = false;

    public virtual void Update()
    {

        if (playerNear && !isHighlighted)
        {
            Highlight();
            isHighlighted = true;
        }

        if (!playerNear && isHighlighted)
        {
            //Debug.Log("Using Unlight confirmed");
            Unlight();
            isHighlighted = false;
        }
    }
}
