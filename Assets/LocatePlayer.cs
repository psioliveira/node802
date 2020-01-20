using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatePlayer : MonoBehaviour
{
    Transform partner;
    [SerializeField]
    bool isplayer1 = false;

    [SerializeField]
    Rotation_Receiver ui;

    Quaternion temp2;

    float counter = 60;
    float maxCounter = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isplayer1)
        {
            ui = GameObject.FindGameObjectWithTag("UI_Rotation").GetComponent<Rotation_Receiver>();
        }

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
    }

    private void FixedUpdate()
    {
        //if (counter >= (float)maxCounter)
        //{
        if(partner == null)
        {
            if (isplayer1)
                partner = GameObject.FindGameObjectWithTag("Player2").transform;
            else
                partner =  GameObject.FindGameObjectWithTag("Player1").transform;
        }
        float rotationX = 0;
        if(partner != null)
        {
            Vector3 difference = partner.position - transform.position;
            rotationX = Mathf.Atan2(difference.y, difference.z) * Mathf.Rad2Deg;
            rotationX = Mathf.Round(rotationX);
            transform.rotation = Quaternion.Euler(-rotationX, 0.0f, 0f);
            if (isplayer1)
                ui.ChangeRotation(transform.rotation, rotationX);
        }





        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);

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
