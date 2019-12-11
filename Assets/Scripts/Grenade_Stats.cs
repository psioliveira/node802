using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]

public class Grenade_Stats : MonoBehaviour
{
    private Game_Manager gm;

    private float maxTimer;
    private float currentTimer;

    private bool countingdown = false;

    private Animator selfAnimator;

    [SerializeField]
    private Grenade_Manager manager;

    private int slot;


    [SerializeField]
    private Image radial;

    private void Start()
    {
        selfAnimator = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
    }

    private void FixedUpdate()
    {
        if (countingdown)
        {
            if(maxTimer <= currentTimer)
            {
                selfAnimator.SetBool("Cooldown", false);
                countingdown = false;
                manager.TalkBack(slot);
            }
            else
            {
                currentTimer += Time.fixedDeltaTime;
                ChangeRadial();
            }

        }
    }

    internal void SlotMe(int slot)
    {
        this.slot = slot;
    }


    private void ChangeRadial()
    {
        radial.fillAmount = currentTimer / maxTimer;
    }

    internal void StartCooldown(int player)
    {
        maxTimer = gm.GrenadeTimerGet(player);
        countingdown = true;
        selfAnimator.SetBool("Cooldown", true);
        currentTimer = 0;
        ChangeRadial();
    }

    internal void StallCooldown(int player)
    {
        maxTimer = gm.GrenadeTimerGet(player);
        countingdown = false;
        selfAnimator.SetBool("Cooldown", true);
    }

    internal void ResumeCooldown(int player)
    {
        maxTimer = gm.GrenadeTimerGet(player);
        countingdown = true;
    }

    internal void SetCooldown(float value)
    {
        currentTimer = value;
    }


    internal bool CurrentState()
    {
        if (currentTimer == maxTimer)
            return true;
        return false;
    }

    internal float CurrentCooldown()
    {
        return currentTimer;
    }



    internal void EndCooldown()
    {
        countingdown = false;
        selfAnimator.SetBool("Cooldown", false);
    }

    internal bool CheckCooldown()
    {
        return countingdown;
    }

}
