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

    private Vector3 Safety;

    /// <summary>
    /// Starting state = 0 rotates clock wise.
    /// </summary>
    private int state = 0;
    /// <summary>
    /// Starting location = 0 rotates clock wise.
    /// </summary>
    private int previousLocation = 0;


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
        
        if (progress < 0)
        {
            progress += 2;
        }
        else if(progress > 2)
        {
            progress -= -2;
        }



        if (state == 0)
        {
            if (progress > 1.6f)
            {
                previousLocation = 0;
                state = 3;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
            else if (progress < 0.4f)
            {
                previousLocation = 0;
                state = 1;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
        }
        else if(state == 1)
        {
            if (progress >= 1.1f && progress <= 1.5f)
            {
                previousLocation = 1;
                state = 0;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
            else if(progress <= 1.9f && progress > 1.5f)
            {
                previousLocation = 1;
                state = 2;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
        }
        else if(state == 2)
        {
            if (progress >= 0.6f && progress < 1f)
            {
                previousLocation = 2;
                state = 1;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
            else if(progress <= 1.6f && progress > 1f)
            {
                previousLocation = 2;
                state = 3;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
        }
        else if (state == 3)
        {
            if (progress <= 0.9f && progress >= 0.5F)
            {
                previousLocation = 3;
                state = 0;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }
            else if (progress >= 0.1f && progress < 0.5f)
            {
                previousLocation = 3;
                state = 2;
                StopAllCoroutines();
                StartCoroutine(RotateTo());
            }

        }



        //if (progress < 1.0f)
        //{
        //    //Debug.Log(progress);
        //    Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], progress);
        //    Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], progress);
        //    me.position = Vector3.Lerp(temp1, temp2, progress);
        //    //helpme.position = interpolate[0];
        //    //Debug.Log(me.position);
        //    //Debug.Log(interpolate[0]);
        //}
        //else if (progress < 2.0f)
        //{
        //    Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], progress - 1f);
        //    Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], progress - 1f);
        //    me.position = Vector3.Lerp(temp1, temp2, progress - 1);
        //}
    }

    private IEnumerator RotateTo()
    {
        float desiredTimer = 0.2f;
        float ratio = desiredTimer / 2;
        if(state == 0)
        {
            // ood
            if (previousLocation == 1)
            {
                for (float i = desiredTimer / 2; i < desiredTimer; i += Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
            }
            // correct
            else if (previousLocation == 3)
            {
                for (float i = desiredTimer / 2; i > 0; i -= Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
                Vector3 temp3 = Vector3.Lerp(locations[1], interpolate[1], 0);
                Vector3 temp4 = Vector3.Lerp(interpolate[1], locations[0], 0);
                me.position = Vector3.Lerp(temp3, temp4, 0f);
            }
        }
        else if (state == 1)
        {
            // nice
            if (previousLocation == 0)
            {
                for (float i = desiredTimer; i > desiredTimer/ 2; i -= Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
            }

            else if (previousLocation == 2)
            {
                for (float i = 0; i < desiredTimer/2; i += Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
                Vector3 temp3 = Vector3.Lerp(locations[0], interpolate[0], 0.5f);
                Vector3 temp4 = Vector3.Lerp(interpolate[0], locations[1], 0.5f);
                me.position = Vector3.Lerp(temp3, temp4, 0.5f);
            }
        }
        else if (state == 2)
        {
            // nice
            if (previousLocation == 1)
            {
                for (float i = desiredTimer / 2; i > 0; i -= Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[0], interpolate[0], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[0], locations[1], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
            }
            // nice
            else if (previousLocation == 3)
            {
                for (float i = desiredTimer / 2; i < desiredTimer; i += Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
                Vector3 temp3 = Vector3.Lerp(locations[1], interpolate[1], 1f);
                Vector3 temp4 = Vector3.Lerp(interpolate[1], locations[0], 1f);
                me.position = Vector3.Lerp(temp3, temp4, 1f);
            }
        }
        else if (state == 3)
        {
            // Nice
            if (previousLocation == 2)
            {
                for (float i = desiredTimer; i > desiredTimer / 2; i -= Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
                Vector3 temp3 = Vector3.Lerp(locations[1], interpolate[1], 0.5f);
                Vector3 temp4 = Vector3.Lerp(interpolate[1], locations[0], 0.5f);
                me.position = Vector3.Lerp(temp3, temp4, 0.5f);
            }
            // nice
            else if (previousLocation == 0)
            {
                for (float i = 0; i < desiredTimer/2; i += Time.deltaTime / 2)
                {
                    Vector3 temp1 = Vector3.Lerp(locations[1], interpolate[1], i / desiredTimer);
                    Vector3 temp2 = Vector3.Lerp(interpolate[1], locations[0], i / desiredTimer);
                    me.position = Vector3.Lerp(temp1, temp2, i / desiredTimer);
                    Safety = me.position;
                    yield return new WaitForEndOfFrame();
                }
                Vector3 temp3 = Vector3.Lerp(locations[1], interpolate[1], 0.5f);
                Vector3 temp4 = Vector3.Lerp(interpolate[1], locations[0], 0.5f);
                me.position = Vector3.Lerp(temp3, temp4, 0.5f);
            }
        }

    }

    private void LateUpdate()
    {
        me.position = Safety;
    }

}
