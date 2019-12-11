using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Player_Stats", order = 1)]
public class Player_Stats : ScriptableObject
{
    public string PlayerName;

    public int MaxHP = 100;
    public int MaxGrenades = 3;
    public float GrenadeTimer = 2;
    public int Damage = 20;
    public float ReloadTime = 0.5f;
    public float HeightJumpMultiplier = 1f;
    public float MovementSpeedMultiplier = 1f;
    public int MaxOverheat = 100;
    public float OverheatSpeedBoost = 1f;
}
