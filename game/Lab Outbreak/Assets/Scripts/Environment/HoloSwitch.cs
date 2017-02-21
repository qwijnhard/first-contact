using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloSwitch : Switch
{

    public Animator anim;
    public bool isActive = false;
    public bool stateToggle = false;

    public override void Start()
    {
        base.Start();
        anim = this.GetComponent<Animator>();
    }

    public override void Update()
    {
        base.Update();

        if (stateToggle && !isActive)
        {
            Activate();
        }

        if (stateToggle && isActive)
        {
            Deactivate();
        }
    }

    
    public void Activate()
    {
        anim.Play("Activate");
        isActive = true;
        stateToggle = false;
    }

    public void Deactivate()
    {
        anim.Play("Deactivate");
        isActive = false;
        stateToggle = false;
    }
}
