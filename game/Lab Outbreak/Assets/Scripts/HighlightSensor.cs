using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>().Player)
        {
            GetComponentInParent<InteractibleObject>().playerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit confirmed");
        if (other.gameObject.GetComponent<Tags>().Player)
        {
            Debug.Log("Exit by player confirmed");
            GetComponentInParent<InteractibleObject>().playerNear = false;
        }
    }
}
