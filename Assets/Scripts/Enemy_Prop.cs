using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Prop : MonoBehaviour
{
    Animator anim;
    Collider myhitbox;

    [SerializeField]
    Animator reactant;

    [SerializeField]
    Material usedUp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myhitbox = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shot")
        {
            GetComponent<Renderer>().material = usedUp;
            anim.SetTrigger("Hurt");
            reactant.SetTrigger("Go");
        }
    }
}
