using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Move_Test : MonoBehaviour
{
    public GameObject[] fighter;
   

    public Animator[] motion;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(ready());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
   
    IEnumerator ready()
    {
        yield return new WaitForSeconds(3.0f);

        motion[0].SetBool("Walk", true);

       // fighter[0].transform.DOMove(new Vector3(-20.3f, 0f, 0f), 3f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(3.0f);

        motion[0].SetBool("Walk", false);
        // cube1[1].transform.DOMove(new Vector3(2.142f, 0.215f, 1.887f), 10f).SetEase(Ease.Linear);
    }
}
