using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalObject : MonoBehaviour

    /*
Operate is meant to be overridden by whatever the object's function is supposed to be.    

*/
{

    public bool operate = false;
    
    void Update()
    {
        if (operate)
        {
            Operate();
            operate = false;
        }
    }

    public virtual void Operate()
    {
        
    }
}

    
