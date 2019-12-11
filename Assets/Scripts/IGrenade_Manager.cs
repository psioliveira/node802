using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrenade_Manager
{
    bool UseGrenade();
    void SetPlayer(int value);
    bool CheckCD(int slot);
    bool CheckSlot(int value);
    bool StartCooldown(int slot);
    bool EndCooldown(int slot);

}
