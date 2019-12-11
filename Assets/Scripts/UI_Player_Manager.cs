using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class UI_Player_Manager : MonoBehaviour
{
    int PlayerSlot = 0;
    bool playerSet = false;

    Animator myanimator;

    [SerializeField]
    UI_HealthBar_Player hpBar;

    [SerializeField]
    internal IGrenade_Manager grenades;

    [SerializeField]
    internal IShell_Manager shells;

    [SerializeField]
    private Image flat;
    [SerializeField]
    private RawImage depth;

    private int testvalue = 10;

    private void Start()
    {
        if(hpBar == null)
        {
            Debug.LogError("Setup UI_HealthBar_Player in UI_Player_Manager!");
        }
        myanimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeHP(testvalue);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeHP(-testvalue);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            UseGrenade();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ReloadShell(1);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            UseShell();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddShell(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchPortrait(false);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchPortrait(true);
        }


    }

    private void SwitchPortrait(bool value)
    {
        if (value)
        {
            depth.enabled = true;
            flat.enabled = false;
        }
        else
        {
            depth.enabled = false;
            flat.enabled = true;
        }
    }

    internal void SetPlayer()
    {
        if(grenades != null)
        {
            if(shells != null)
            {
                DefinePlayerSlot(1);
            }
        }
    }


    internal bool UseGrenade()
    {
        if (grenades.UseGrenade())
            return true;
        return false;
    }

    internal bool UseShell()
    {
        if (shells.UseShell())
            return true;
        return false;
    }

    internal void AddShell(int value)
    {
        shells.AddShell(1);
    }

    internal void ReloadShell(float timer)
    {
        shells.ReloadShell(timer);
    }


    private bool DefinePlayerSlot(int number)
    {
        if (playerSet)
        {
            Debug.Log("Something tried to change my player number after being defined.");
            return false;
        }
        PlayerSlot = number;
        playerSet = true;
        hpBar.SetPlayer(number);
        grenades.SetPlayer(number);
        return true;
    }

    public int MyPlayer()
    {
        return PlayerSlot;
    }

    private void ChangeHP(int hpValue)
    {
        if(hpValue >= 0)
        {
            myanimator.SetTrigger("Hurt");
        }
        else
        {
            myanimator.SetTrigger("Heal");
        }
        if (hpBar.ChangeHP(hpValue))
        {
        }
        else
            Debug.LogError("THERE IS A DESYNC OF HP VALUES. PLEASE CHECK THE VALUE" +
                "OR CHANGE THE MAX HP VALUE ON GAME MANAGER.");
    }

}
