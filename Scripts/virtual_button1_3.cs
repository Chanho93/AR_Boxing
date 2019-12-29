using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using DG.Tweening;
public class virtual_button1_3 : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject anim_object;
    public GameObject cy;
    public GameObject cy_body;

    public Animator cy_ani;
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

        cy_ani.SetBool("Guard", true);

        cy_body.GetComponent<BoxCollider>().enabled = false;
        //anim_object.GetComponent<Animation>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Released");

        cy_ani.SetBool("Guard", false);
        cy_body.GetComponent<BoxCollider>().enabled = true;
        cy.transform.DORotate(new Vector3(0f, -90f, 0f), 0.1f).SetEase(Ease.Linear);
        // anim_object.GetComponent<Animation>().Stop();
    }
    // Update is called once per frame
    void Update()
    {

    }
}