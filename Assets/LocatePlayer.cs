using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatePlayer : MonoBehaviour
{
    Transform partner;

    [SerializeField]
    Rotation_Receiver ui;

    Quaternion temp2;

    float counter = 60;
    float maxCounter = 1f;
    
    // Start is called before the first frame update
    void Start()
    {


        GameObject[] playerArray;
        Transform father = GetComponentInParent<Transform>();
        playerArray = GameObject.FindGameObjectsWithTag("Player");
        int location = 1000;
        for(int i = 0; i < playerArray.Length; i++)
        {
            if(playerArray[i].transform != father)
            {
                partner = playerArray[i].transform;
                i = 10000;
            }
        }
        Vector3 temp = partner.position;

        temp.x = 0;
        transform.LookAt(temp);
    }

    private void FixedUpdate()
    {
        //if (counter >= (float)maxCounter)
        //{

        Vector3 difference = partner.position - transform.position;
        float rotationX = Mathf.Atan2(difference.y, difference.z) * Mathf.Rad2Deg;
        rotationX = Mathf.Round(rotationX);
        transform.rotation = Quaternion.Euler(-rotationX, 0.0f, 0f);




        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        ui.ChangeRotation(transform.rotation, rotationX);
        //counter = 0f;
        //}

        //ui.ChangeRotation(temp);
        //Quaternion temp = Quaternion.LookRotation(partner.position);
        //transform.eulerAngles = new Vector3(temp.eulerAngles.x, 0, 0);
    }

    //private void Update()
    //{

    //    transform.rotation = Quaternion.Slerp(transform.rotation, temp2, counter);
    //    counter += Time.deltaTime;
    //}

}
