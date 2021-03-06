﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtual_button_movingright : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject anim_object;
    public GameObject athlete;

    public Animator athlete_ani;

    public float moveSpeed = 5f;
    bool right = false;
 
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

        right = true;
       
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Released");

        right = false;
        athlete_ani.SetBool("Walk", false);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(right == true)
        {
            Move();
        }
    
    }

    void Update()
    {

    }

    void Move()
    {
        athlete_ani.SetBool("Walk", true);

        Vector3 moveDistance = transform.right * moveSpeed * Time.deltaTime;
        athlete.transform.position = athlete.transform.position+ moveDistance;

    }
}
