using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar_Player : MonoBehaviour
{
    [SerializeField]
    private Image MainHP, SlideHP;


    [Header("Colors for different HP States")]
    [SerializeField]
    private Color Perfect, BarelyInjured, LightlyInjured, MediumInjured, HeavyInjured, Dead;


    //[Header("Color for Highlight")]
    //[SerializeField]
    //private Color OutlinePerfect, OutlineLightlyInjured, OutlineMediumInjured,
    //    OutlineHeavyInjured, OutlineDead;


    //[Header("Calculate automaticly the border?")]
    //[SerializeField]
    //private bool AutoBorderColor;

    //[Header("Calculate automaticly the 2nd HPBar color?")]
    //[SerializeField]
    //private bool Auto2ndHPColor;



    [Header("Color for Highlight")]
    [SerializeField]
    private Color HighlightBar;
    private Image HighlightBarObj;

    [SerializeField]
    private Image Filter, MainBar, OutlineHP, OutlineGeneral;

    private int MaxHP = 100;
    private int CurrentHP = 100;

    Coroutine change, colorchange;

    private Game_Manager GameManager;

    private int player;

    [SerializeField]
    private Animator SlideHigh, HpHigh, NoHigh;





    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        if(Perfect == null || LightlyInjured == null || MediumInjured == null || HeavyInjured == null || Dead == null || HighlightBar == null || HighlightBarObj == null || Filter == null
            || MainHP == null || SlideHP == null)
        {
            Debug.LogError("An asset in UI_HealthBar_Player has not been setup properly. Issues may rise from this.");
        }
    }

    private void Update()
    {

    }

    internal void SetPlayer(int number)
    {
        player = number;
        MainHP.fillAmount = (float)CurrentHP / (float)MaxHP;
        CheckState(CurrentHP);
    }


    internal bool ChangeHP(int HP)
    {
        MaxHP = GameManager.GetMaxHP(player);
        if(HP > MaxHP)
        {
            return false;
        }
        HP = CurrentHP - HP;
        CheckState(HP);
        if(CurrentHP > HP)
        {
            if (change != null)
            {
                StopCoroutine(change);
            }
            change = StartCoroutine(HPBarChange(CurrentHP, HP));

        }
        CurrentHP = HP;
        if(CurrentHP < 0)
        {
            CurrentHP = 0;
        }
        else if(CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
        MainHP.fillAmount = (float)CurrentHP / (float)MaxHP;
        return true;
    }

    private void CheckState(int HP)
    {
        if (colorchange != null)
        {
            StopCoroutine(colorchange);
        }
        if (HP > 0)
        {
            if (HP >= MaxHP/4)
            {
                if(HP >= MaxHP / 2)
                {
                    if(HP >= MaxHP / 4 *3)
                    {
                        if(HP >= MaxHP)
                        {
                            colorchange = StartCoroutine(ColorChange(Perfect));
                            SlideHigh.SetInteger("State", 5);
                            HpHigh.SetInteger("State", 5);
                            NoHigh.SetInteger("State", 5);
                        }
                        else
                        {
                            colorchange = StartCoroutine(ColorChange(BarelyInjured));
                            SlideHigh.SetInteger("State", 4);
                            HpHigh.SetInteger("State", 4);
                            NoHigh.SetInteger("State", 4);
                        }
                    }
                    else
                    {
                        colorchange = StartCoroutine(ColorChange(LightlyInjured));
                        SlideHigh.SetInteger("State", 3);
                        HpHigh.SetInteger("State", 3);
                        NoHigh.SetInteger("State", 3);
                    }
                }
                else
                {
                    colorchange = StartCoroutine(ColorChange(MediumInjured));
                    SlideHigh.SetInteger("State", 2);
                    HpHigh.SetInteger("State", 2);
                    NoHigh.SetInteger("State", 2);
                }
            }
            else
            {
                colorchange = StartCoroutine(ColorChange(HeavyInjured));
                SlideHigh.SetInteger("State", 1);
                HpHigh.SetInteger("State", 1);
                NoHigh.SetInteger("State", 1);
            }

        }
        else
        {
            colorchange = StartCoroutine(ColorChange(Dead));
            SlideHigh.SetInteger("State", 0);
            HpHigh.SetInteger("State", 0);
            NoHigh.SetInteger("State", 0);
        }
    }

    private IEnumerator ColorChange(Color target)
    {
        float alpha = 150f / 255f;
        float time = 0.3f;
        Color TempColor2 = Filter.color;
        Color TempColor = MainBar.color;
        Color target2 = new Color(target.r, target.g, target.b, Filter.color.a);
        Color target3 = new Color(target.r, target.g, target.b, alpha);

        for (float i = 0; i < time;)
        {
            OutlineHP.color = Color.Lerp(TempColor, target, i / time);
            OutlineGeneral.color = Color.Lerp(TempColor, target3, i / time);
            MainBar.color = Color.Lerp(TempColor, target, i / time);
            Filter.color = Color.Lerp(TempColor2, target2, i / time);
            i += Time.deltaTime;
            yield return 0;
        }
        MainBar.color = Color.Lerp(TempColor, target, 1);
        Filter.color = Color.Lerp(TempColor2, target2, 1);
        OutlineHP.color = Color.Lerp(TempColor, target, 1);
        OutlineGeneral.color = Color.Lerp(TempColor, target3, 1);
    }

    private IEnumerator HPBarChange(int previousHP, int newHP)
    {
        float time = 0.35f;
        float hpDif = (float)previousHP - (float)newHP;

        float ratio = 1 / (float)MaxHP;

        float speed = hpDif / time;

        SlideHP.fillAmount = ((float)previousHP * (float)ratio);
        yield return new WaitForSeconds(0.2f);

        for(float i = 0; i < time;)
        {
            SlideHP.fillAmount -= speed * Time.deltaTime * (float)ratio;
            i +=Time.deltaTime;
            yield return 0;
        }
    }

}
