using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShell_Manager
{

    bool UseShell();
    void AddShell(int numshell);
    void ReloadShell(float timer);
    void StopReload();


}
