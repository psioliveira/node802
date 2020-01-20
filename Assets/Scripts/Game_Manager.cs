using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private Player_Stats[] playerList;
    [SerializeField]
    private GameObject playerPrefab1;
    [SerializeField]
    private GameObject playerPrefab2;

    private void Start()
    {

        PlayerInput.Instantiate(playerPrefab1, 0, "KeyboardLeft", 0, Keyboard.current);
        PlayerInput.Instantiate(playerPrefab2, 1, "KeyboardRight", 1);
    }

    public bool CheckPlayer(int player)
    {
        if (playerList[player] == null)
        {
            Debug.LogError("Does not exist such player.");
            return false;
        }
        return true;
    }

    public float GrenadeTimerGet(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].GrenadeTimer;
        else
        {
            return -50;
        }
    }

    public int GetMaxHP(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].MaxHP;
        else
        {
            return -50;
        }
    }

    public int GetDamage(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].Damage;
        else
        {
            return -50;
        }
    }

    public float GetReloadTime(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].ReloadTime;
        else
        {
            return -50;
        }
    }

    public float GetMaxOverheat(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].MaxOverheat;
        else
        {
            return -50;
        }
    }

    public float GetOverheatSpeedBoost(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].OverheatSpeedBoost;
        else
        {
            return -50;
        }
    }

    public float GetJumpHeight(int player)
    {
        player -= 1;
        if (CheckPlayer(player))
            return playerList[player].HeightJumpMultiplier;
        else
        {
            return -50;
        }
    }

}
