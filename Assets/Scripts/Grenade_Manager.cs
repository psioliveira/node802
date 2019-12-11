using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Manager : MonoBehaviour, IGrenade_Manager
{
    private int player;
    [SerializeField]
    private Grenade_Stats[] Grenades;

    [SerializeField]
    private UI_Player_Manager uiplayer;

    private int lastFinishedSlot = 0;

    private void Start()
    {
        uiplayer.grenades = this;
        for(int i = 0; i < Grenades.Length; i++)
        {
            Grenades[i].SlotMe(i);
        }
        uiplayer.SetPlayer();
    }

    private void Update()
    {
    }

    public bool UseGrenade()
    {
        if (lastFinishedSlot < Grenades.Length)
        {
            Grenades[lastFinishedSlot].StartCooldown(player);
            if(lastFinishedSlot - 1 >= 0)
            {
                Grenades[lastFinishedSlot].SetCooldown(Grenades[lastFinishedSlot - 1].CurrentCooldown());
                Grenades[lastFinishedSlot - 1].StartCooldown(player);
                Grenades[lastFinishedSlot - 1].StallCooldown(player);
            }
            lastFinishedSlot += 1;
            return true;
        }
        return false;
    }


    public void SetPlayer(int value)
    {
        player = value;
    }

    public bool CheckCD(int slot)
    {
        if (!CheckSlot(slot))
        {
            return false;
        }
        Grenades[slot - 1].CheckCooldown();
        return true;
    }

    public bool CheckSlot(int value)
    {
        if (Grenades.Length < (value) || Grenades[0] == null)
        {
            Debug.LogError("THERE IS NO SUCH GRENADE SLOT AS " + value.ToString() + ".");
            return false;
        }
        return true;
    }


    /// <summary>
    /// No need to start from 0, 1 is fine to start with. Grenade1 = 1 etc.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool StartCooldown(int slot)
    {
        if (!CheckSlot(slot))
        {
            return false;
        }
        Grenades[slot - 1].StartCooldown(player);
        return true;
    }

    public bool EndCooldown(int slot)
    {
        if (!CheckSlot(slot))
        {
            return false;
        }
        Grenades[slot - 1].EndCooldown();
        return true;
    }

    internal void TalkBack(int slot)
    {
        lastFinishedSlot = slot;
        if(lastFinishedSlot > 0)
        {
            Grenades[lastFinishedSlot - 1].ResumeCooldown(player);
        }

    }


}
