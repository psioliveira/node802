using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_Parser : MonoBehaviour
{
    Queue<string> textBuffer;
    private string currentString;
    private int stringIndex;
    Queue<float> speeds;
    Queue<int> styles;

    List<Transform> row;
    int currentRow;

    [SerializeField]
    Transform line;

    [SerializeField]
    private int maxSize = 30;
    int currentLocation;

    Coroutine coroutine;

    float defspeed = 0.05f;

    [SerializeField]
    private GameObject rowPrefab;
    [SerializeField]
    private GameObject textPrefab;

    [SerializeField]
    private Text_Styles styleIndex;


    /// <summary>
    /// Doesn't work so far.
    /// </summary>
    /// <returns></returns>

    void Start()
    {
        row = new List<Transform>();
        textBuffer = new Queue<string>();
        speeds = new Queue<float>();
    }


    internal void ParseString(string[] text, float[] speeds, int[] style)
    {
        for(int i = 0; text.Length > i; i++)
        {
            this.textBuffer.Enqueue(text[i]);
        }
        for (int i = 0; text.Length > i; i++)
        {
            this.speeds.Enqueue(speeds[i]);
        }
        for (int i = 0; text.Length > i; i++)
        {
            this.styles.Enqueue(style[i]);
        }
        currentRow = -1;
        coroutine = StartCoroutine(ParseRow());
        
    }

    /// <summary>
    /// Doesn't work so far.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ParseRow()
    {
        currentRow++;
        row.Add(Instantiate(rowPrefab, line).GetComponent<Transform>());
        yield return new WaitForEndOfFrame();

    } 

}
