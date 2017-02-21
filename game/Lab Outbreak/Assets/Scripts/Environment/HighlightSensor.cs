using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSensor : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>().player)
        {
            GetComponentInParent<InteractibleObject>().playerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exit confirmed");
        if (other.gameObject.GetComponent<Tags>().player)
        {
            //Debug.Log("Exit by player confirmed");
            GetComponentInParent<InteractibleObject>().playerNear = false;
        }
    }
}
