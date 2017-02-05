using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightableObject : MonoBehaviour {
    /*
        Other classes will inherit from this, yes. However, objects that consist of multiple parts that all have renderers, this specific class will need to be attached to the children
        (example: The door object consists of the Door object and its children; doorframe, Ldoor and Rdoor. the children require this class, the door object will require the class that inherits
        from this class.)

        ***Doors are not planned to have highlighting

        */


    public Material normal;
    public Material glowing;

    public bool isGlowing = false;

   /* void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Highlight();
        }

        if (Input.GetButton("Fire2"))
        {
            Unlight();
        }
    }

    */

    //sets own material to glowing if it has a renderer, then makes all children repeat. if this has no renderer, only make all children repeat.
    public virtual void Highlight()
    {
        if (GetComponent<Renderer>() != null || GetComponent<SkinnedMeshRenderer>() != null)
        {
            if (GetComponent<Renderer>() != null)
            {
                this.GetComponent<Renderer>().material = glowing;
                isGlowing = true;
            }

            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
                this.GetComponent<SkinnedMeshRenderer>().material = glowing;
                isGlowing = true;
            }

            if(this.transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<HighlightableObject>() != null)
                    {
                        child.GetComponent<HighlightableObject>().Highlight();
                    }
                }
            }
        }

        if (GetComponent<Renderer>() == null && GetComponent<SkinnedMeshRenderer>() == null)
        {
            if (this.transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<HighlightableObject>() != null)
                    {
                        child.GetComponent<HighlightableObject>().Highlight();
                    }
                }
            }
        }
    }

    //does the exact same as Highlght(), except, this changes the texture to "normal" instead of "glowing"
    public virtual void Unlight()
    {
        if (GetComponent<Renderer>() != null || GetComponent<SkinnedMeshRenderer>() != null)
        {
            if (GetComponent<Renderer>() != null)
            {
                this.GetComponent<Renderer>().material = normal;
                isGlowing = false;
            }

            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
                this.GetComponent<SkinnedMeshRenderer>().material = normal;
                isGlowing = false;
            }

            if (this.transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<HighlightableObject>() != null)
                    {
                        child.GetComponent<HighlightableObject>().Unlight();
                    }
                }
            }
        }

        if (GetComponent<Renderer>() == null && GetComponent<SkinnedMeshRenderer>() == null)
        {
            if (this.transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<HighlightableObject>() != null)
                    {
                        child.GetComponent<HighlightableObject>().Unlight();
                    }
                }
            }
        }
    }
}
