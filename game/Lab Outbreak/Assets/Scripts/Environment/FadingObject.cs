using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour {

    /*
    this class needs to be given to a walls object and all its wall children

        if this collides with the WallVisionObject (player child), it sends a signal to its walls parent if it has one
        if this object is the walls parent, make all children run Fade()
    */

    public Material normal;
    public Material transparant;

    private Renderer rend;

    public bool faded = false;
    public bool needsToToggle = false;

	void Start () {

        //got a renderer? cool. rend is now that renderer
        if (this.gameObject.GetComponent<Renderer>() != null) {
            rend = this.gameObject.GetComponent<Renderer>();
        }
	}
	
	void Update () {

        //if needstotoggle, check which action you need to perform
		if(!faded && needsToToggle)
        {
            FadeAll();
        }

        if(faded && needsToToggle)
        {
            UnfadeAll();
        }
	}

    void Fade()
    {
        rend.material = transparant;
        //Debug.Log("material set to trans");
        faded = true;
        //Debug.Log(faded);
        needsToToggle = false;
    }

    void Unfade()
    {
        rend.material = normal;
        //Debug.Log("material set to norm");
        faded = false;
        needsToToggle = false;
    }

    void FadeAll()
    {
        if (this.transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<FadingObject>() != null)
                {
                    child.GetComponent<FadingObject>().Fade();
                }
            }
            faded = true;
            needsToToggle = false;
        }

        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            Fade();
        }
    }

    void UnfadeAll()
    {
        if (this.transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<FadingObject>() != null)
                {
                    child.GetComponent<FadingObject>().Unfade();
                }
            }
            faded = false;
            needsToToggle = false;
        }

        if (this.gameObject.GetComponent<Renderer>() != null)
        {
            Unfade();
        }
    }
}
