using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation_Camera : MonoBehaviour
{
    public RectTransform helpme;

    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform goal1;

    private RectTransform me;

    [SerializeField]
    private bool rightSide;

    private Vector3[] locations;
    private Vector3[] interpolate;

    private float progress = 0;
    public float offset = 50f;


    private void Start()
    {
        me = GetComponent<RectTransform>();
        if (start == null || goal1 == null)
        {
            Debug.LogError("A location isn't defined.");
        }

        locations = new Vector3[2];

        locations[0] = start.GetComponent<RectTransform>().position;
        locations[1] = goal1.GetComponent<RectTransform>().position;

        interpolate = new Vector3[2];
        if (rightSide)
        {
            interpolate[0] = locations[0] + (locations[1] - locations[0]) / 2 + Vector3.up * offset;
            interpolate[1] = locations[1] + (locations[0] - locations[1]) / 2 + Vector3.down * offset;
        }
        else
        {
            interpolate[0] = locations[0] + (locations[1] - locations[0]) / 2+ Vector3.down * offset;
            interpolate[1] = locations[1] + (locations[0] - locations[1]) / 2 + Vector3.up * offset;
        }

        Debug.Log(interpolate[1]);
    }

    internal void Rotate(float rotation)
    {
        progress = rotation/180f;
        Debug.Log(progress);
        if (progress < 0)
        {
            progress += 2;
        }
        else if(progress > 2)
        {
            progress = -2;
        }

        if (progress < 1.0f)
        {
            //Debug.Log(progress);
            Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], progress);
            Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], progress);
            me.position = Vector3.Lerp(temp1, temp2, progress);
            //helpme.position = interpolate[0];
            //Debug.Log(me.position);
            //Debug.Log(interpolate[0]);
        }
        else if (progress < 2.0f)
        {
            Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], progress - 1f);
            Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], progress - 1f);
            me.position = Vector3.Lerp(temp1, temp2, progress - 1);
        }
    }

}
