﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtual_button2_3 : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject anim_object;
    public GameObject man;
    public GameObject man_body;

    public Animator man_ani;
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour vb_behaviour;
        vb_behaviour = this.GetComponent<VirtualButtonBehaviour>();
        vb_behaviour.RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Pressed");

        man_ani.SetBool("Guard", true);
        man_body.GetComponent<BoxCollider>().enabled = false;
        //anim_object.GetComponent<Animation>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Released");

        man_ani.SetBool("Guard", false);
        man_body.GetComponent<BoxCollider>().enabled = true;
        // anim_object.GetComponent<Animation>().Stop();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
