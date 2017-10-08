using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesScript : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        
	}

    private void OnTriggerStay(Collider other)
    {
        GetComponentInParent<BasicMonsterAI>().Sight(other.gameObject);
        //Debug.DrawLine(GetComponentInParent<Transform>().position, other.transform.position, Color.blue);
    }
}
