using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationSensor : MonoBehaviour {
    
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>() != null)
        {
            if (other.gameObject.GetComponent<Tags>().player || other.gameObject.GetComponent<Tags>().enemy)
            {
                this.transform.parent.GetComponent<HoloSwitch>().stateToggle = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>() != null)
        {
            if (other.gameObject.GetComponent<Tags>().player || other.gameObject.GetComponent<Tags>().enemy)
            {
                this.transform.parent.GetComponent<HoloSwitch>().stateToggle = true;
            }
        }
    }
}
