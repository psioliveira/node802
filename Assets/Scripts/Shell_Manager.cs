using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Rewrite this later, make it so on every use it readjust the 
/// UI of all the bars accordingly thank. Want to make this class the least bit
/// requiring to be 100% in sync with the other script to work properly.
/// </summary>
public class Shell_Manager : MonoBehaviour, IShell_Manager
{
    [SerializeField]
    private Image[] shellArray;

    private int LastShell = 0;

    private Coroutine reload;

    private Coroutine[] currentReload;

    float shellUnload = 0.05f;

    private bool reloading = false;

    [SerializeField]
    private UI_Player_Manager uiplayer;

    private void Start()
    {
        uiplayer.shells = this;
        uiplayer.SetPlayer();
        for (int i = 0; i < shellArray.Length; i++)
        {
            shellArray[i].fillAmount = 1f;
        }
    }

    private void Update()
    {

    }



    /// <summary>
    /// Consumes shells.
    /// </summary>
    /// <returns></returns>
    public bool UseShell()
    {
        if (!reloading)
        {
            if (LastShell < shellArray.Length)
            {
                StartCoroutine(ShellUseAnimation(LastShell, shellUnload, false));
                LastShell++;
                return true;
            }
        }
        return false;
    }

    public void AddShell(int numshell)
    {
        if (!reloading)
        {
            for (int i = 0; i < numshell; i++)
            {
                if (LastShell > 0)
                {
                    LastShell--;
                    StartCoroutine(ShellGiveAnimation(LastShell, 0.1f));
                }
            }
        }
    }


    /// <summary>
    /// Starts the in ui animation of reloading the shells.
    /// </summary>
    /// <param name="timer"></param>
    public void ReloadShell(float timer)
    {
            StopAllCoroutines();
        StartCoroutine(ReloadShellAnim(timer));

    }

    public void StopReload()
    {
        if(reload != null)
        {
            StopCoroutine(reload);
            if(currentReload != null)
            {
                StopAllCoroutines();
                shellArray[LastShell].fillAmount = 0;
            }
        }
    }

    /// <summary>
    /// Coroutine that will handle the setup and managment of shells being reloaded.
    /// </summary>
    /// <param name="timer"></param>
    /// <returns></returns>
    private IEnumerator ReloadShellAnim(float timer)
    {
        LastShell = 0;
        float temp = 0f;
        timer -= (shellUnload * shellArray.Length);
        for (int i = 0; i < shellArray.Length; i++)
        {
            StartCoroutine(ShellUseAnimation(i, shellUnload, false));
            yield return new WaitForSeconds(shellUnload);
            temp += shellUnload;
        }

        timer /= shellArray.Length;
        for(int i = 0; i < shellArray.Length; i++)
        {
            StartCoroutine(ShellGiveAnimation(shellArray.Length - i - 1, timer));
            shellArray[i].color = new Color(shellArray[i].color.r,
                shellArray[i].color.g, shellArray[i].color.b, 1f);
            yield return new WaitForSeconds(timer);
            temp += timer;
        }
        Debug.Log(temp);
    }




    /// <summary>
    /// Coroutine that handles the animation of filling the shells.
    /// </summary>
    /// <param name="shell"></param>
    /// <param name="timer"></param>
    /// <returns></returns>
    private IEnumerator ShellGiveAnimation(int shell, float timer)
    {
        shellArray[shell].fillAmount = 0;
        float ratio = 1 / timer;
        for (float i = 0; i < timer;)
        {
            shellArray[shell].fillAmount += Time.deltaTime * ratio;
            i += Time.deltaTime;
            yield return 0;
        }
    }

    private IEnumerator ShellUseAnimation(int shell, float timer, bool add)
    {
            shellArray[shell].fillAmount = 1;
        float ratio = 1 / timer;
        for (float i = 0; i < timer;)
        {
            shellArray[shell].fillAmount -= Time.deltaTime * ratio;
            i += Time.deltaTime;
            yield return 0;
        }
        if(add)
        LastShell++;
    }

}
