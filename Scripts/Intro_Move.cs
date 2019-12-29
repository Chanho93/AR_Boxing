using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Intro_Move : MonoBehaviour
{
    public GameObject Cy;
    public Animator Cy_ani;
    // Start is called before the first frame update
    void Start()
    {
        Cy.transform.DOMove(new Vector3(-7f, -6.9f, 18.8f), 10.0f).SetEase(Ease.Linear);
        Cy_ani.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
