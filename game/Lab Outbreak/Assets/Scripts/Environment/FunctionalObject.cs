using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalObject : MonoBehaviour

/*
Operate is meant to be overridden by whatever the object's function is supposed to be.    

*/
{

    public bool operate = false;

    //if operate is true, do Operate(), the set operate to false
    void Update()
    {
        if (operate)
        {
            Operate();
            operate = false;
        }
    }

    //instentionally empty so any class inheriting from this can just read what the method should be called
    public virtual void Operate()
    {

    }
}


