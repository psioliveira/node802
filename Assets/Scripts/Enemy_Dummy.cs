using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Dummy : MonoBehaviour
{
    int CurrentDamage = 0;
    Animator anim;
    [SerializeField]
    TextMeshPro HP;


    private void Start()
    {
        anim = GetComponent<Animator>();
        TextChange();
    }

    private void TextChange()
    {
        HP.text = "I have taken: " + CurrentDamage + " HP Damage!";
        if(CurrentDamage >= 10)
        {
            HP.text += ":)";
        }
        if(CurrentDamage >= 15)
        {
            HP.text += "SmileyFace";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shot")
        {
            CurrentDamage += other.GetComponent<Bullet_Stats>().GetDamage();
            anim.SetTrigger("Hurt");
            TextChange();
        }
    }
}
