using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallvisionObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>() != null && other.transform.parent != null)
        {
            if (other.gameObject.GetComponent<Tags>().Wall)
            {
                other.GetComponentInParent<FadingObject>().needsToToggle = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>() != null && other.transform.parent != null)
        {
            if (other.gameObject.GetComponent<Tags>().Wall)
            {
                other.GetComponentInParent<FadingObject>().needsToToggle = true;
            }
        }
    }
}
