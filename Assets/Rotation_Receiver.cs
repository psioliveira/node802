using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Receiver : MonoBehaviour
{

    private Quaternion childRotation;

    [SerializeField]
    private Rotation_Camera leftChild, rightChild;

    private void Start()
    {
        childRotation = leftChild.transform.rotation;
    }

    internal void ChangeRotation(Quaternion rotation, float value)
    {
        //Vector3 newAngle = rotation.eulerAngles;
        //newAngle.z = -newAngle.x;
        //newAngle.x = 0;
        //newAngle.y = 0;
        //rotation.eulerAngles = newAngle;
        Quaternion oldRotation = transform.rotation;
        //Vector3 leftChildPos, rightChildPos;
        //leftChildPos = leftChild.transform.position;
        //rightChildPos = rightChild.transform.position;
        transform.rotation = rotation;

        transform.Rotate(0, -90, 0);

        //leftChild.transform.position = leftChildPos;
        //rightChild.transform.position = rightChildPos;
        leftChild.transform.rotation = childRotation;
        rightChild.transform.rotation = childRotation;
        leftChild.Rotate(value);
        rightChild.Rotate(value);
    }

}
