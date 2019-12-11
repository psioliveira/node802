using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Prop : MonoBehaviour
{
    Animator anim;
    Collider myhitbox;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myhitbox = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shot")
        {
            anim.SetTrigger("Hurt");
            myhitbox.enabled = false;
        }
    }
}
