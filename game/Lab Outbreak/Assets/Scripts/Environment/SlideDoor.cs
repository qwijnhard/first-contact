using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : FunctionalObject
{
    private Animator anim;

    private bool open = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Operate()
    {
        if (open)
        {
            anim.Play("SlideClosed");
            open = false;
        }

        if (!open)
        {
            anim.Play("SlideOpen");
            open = true;
        }
    }
}
