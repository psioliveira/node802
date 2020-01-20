using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation_Receiver : MonoBehaviour
{

    private Quaternion childRotation;
    private int state = 2;
    private RectTransform me;
    Vector3 currentVector;
    Animator animMe;

    [SerializeField]
    private Rotation_Camera leftChild, rightChild;

    private int previousLocation = 0;

    private void Start()
    {
        animMe = GetComponent<Animator>();
        childRotation = leftChild.transform.rotation;
        me = GetComponent<RectTransform>();
        currentVector = transform.localRotation.eulerAngles;
        animMe.SetInteger("State", state);
    }

    internal void ChangeRotation(Quaternion rotation, float value)
    {
        float currentRotation = value / 180f;
        if (currentRotation < 0)
        {
            currentRotation += 2;
        }
        else if (currentRotation > 2)
        {
            currentRotation = -2;
        }

        if (state == 0)
        {
            if (currentRotation > 1.6f)
            {
                Debug.Log("HEY1");
                state = 3;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
            else if (currentRotation < 0.4f)
            {
                Debug.Log("HEY2");
                state = 1;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
        }
        else if (state == 1)
        {
            if (currentRotation >= 1.1f && currentRotation <= 1.5f)
            {
                Debug.Log("HEY3");
                state = 0;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
            else if (currentRotation <= 1.9f && currentRotation > 1.5f)
            {
                Debug.Log("HEY4");
                state = 2;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
        }
        else if (state == 2)
        {
            if (currentRotation >= 0.6f && currentRotation < 1f)
            {
                Debug.Log("HEY5");
                state = 1;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
            else if (currentRotation <= 1.6f && currentRotation > 1f)
            {
                Debug.Log("HEY6");
                state = 3;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
        }
        else if (state == 3)
        {
            if (currentRotation <= 0.9f && currentRotation >= 0.5F)
            {
                Debug.Log("HEY7");
                state = 0;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }
            else if (currentRotation >= 0.1f && currentRotation < 0.5f)
            {
                Debug.Log("HEY8");
                state = 2;
                animMe.SetInteger("State", state);
                //StopAllCoroutines();
                //StartCoroutine(RotateTo());
            }

        }
        leftChild.Rotate(value);
        rightChild.Rotate(value);
    }

    // Bandaid fix switchin this to hard animated.
    private void LateUpdate()
    {
        leftChild.transform.rotation = childRotation;
        rightChild.transform.rotation = childRotation;

    }

    //IEnumerator RotateTo()
    //{
    //    Vector3 angleToUse;

    //    float speed = 0.2f;
    //    if(state == 0)
    //    {
    //        angleToUse = new Vector3(0, 0, 0);
    //        Quaternion 
    //        for (float i = 0; i < speed; i += Time.deltaTime)
    //        {
    //            currentVector = Vector3.Lerp(angleToUse, angleToUse, i / speed);
    //            transform.eulerAngles = currentVector;
    //            leftChild.transform.rotation = childRotation;
    //            rightChild.transform.rotation = childRotation;
    //            yield return null;
    //        }
    //        currentVector = Vector3.Lerp(angleToUse, angleToUse, 1);
    //        transform.eulerAngles = currentVector;
    //        leftChild.transform.rotation = childRotation;
    //        rightChild.transform.rotation = childRotation;
    //    }
    //    else if (state == 1)
    //    {
    //        angleToUse = new Vector3(0, 90, 0);
    //        for (float i = 0; i < speed; i += Time.deltaTime)
    //        {
    //            currentVector = Vector3.Lerp(angleToUse, angleToUse, i / speed);
    //            transform.eulerAngles = currentVector;
    //            leftChild.transform.rotation = childRotation;
    //            rightChild.transform.rotation = childRotation;
    //            yield return null;
    //        }
    //        currentVector = Vector3.Lerp(angleToUse, angleToUse, 1);
    //        transform.eulerAngles = currentVector;
    //        leftChild.transform.rotation = childRotation;
    //        rightChild.transform.rotation = childRotation;
    //    }
    //    else if (state == 2)
    //    {

    //        angleToUse = new Vector3(0, 180, 0);
    //        for (float i = 0; i < speed; i += Time.deltaTime)
    //        {
    //            currentVector = Vector3.Lerp(angleToUse, angleToUse, i / speed);
    //            transform.eulerAngles = currentVector;
    //            leftChild.transform.rotation = childRotation;
    //            rightChild.transform.rotation = childRotation;
    //            yield return null;
    //        }
    //        currentVector = Vector3.Lerp(angleToUse, angleToUse, 1);
    //        transform.eulerAngles = currentVector;
    //        leftChild.transform.rotation = childRotation;
    //        rightChild.transform.rotation = childRotation;
    //    }
    //    else if (state == 3)
    //    {
    //        angleToUse = new Vector3(0, 270, 0);
    //        for (float i = 0; i < speed; i += Time.deltaTime)
    //        {
    //            Debug.Log(i);
    //            currentVector = Vector3.Lerp(angleToUse, angleToUse, i / speed);
    //            transform.eulerAngles = currentVector;
    //            leftChild.transform.rotation = childRotation;
    //            rightChild.transform.rotation = childRotation;
    //            yield return null;
    //        }
    //        currentVector = Vector3.Lerp(angleToUse, angleToUse , 1);
    //        transform.eulerAngles = currentVector;
    //        leftChild.transform.rotation = childRotation;
    //        rightChild.transform.rotation = childRotation;
    //    }
    //    yield return null;
}

