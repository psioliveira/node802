using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private GameObject pivotPoint;
    [SerializeField]
    private PlayerInput pi;
    internal PlayerControl pc;
    public float speed;
    public Camera cam;
    public GameObject aim;

    private void Awake()
    {
        pc = new PlayerControl();
    }
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        AimCursor();
    }
    void AimCursor()
    {
        if (GetComponentInParent<CharacterMovement>().aimv.x == 0f && GetComponentInParent<CharacterMovement>().aimv.y == 0f)
        {
            Vector3 curRot = pivotPoint.transform.localEulerAngles;
            Vector3 homeRot;
            if (curRot.x > 180f)
            {
                homeRot = new Vector3(359.999f, 0f, 0f); //it doesnt return to perfect zero 
            }
            else
            {                                                                      // otherwise it rotates wrong direction 
                homeRot = Vector3.zero;
            }
            pivotPoint.transform.localEulerAngles = Vector3.Slerp(curRot, homeRot, Time.deltaTime * 4);
        }
        else
        {
            pivotPoint.transform.localEulerAngles = new Vector3(Mathf.Atan2(-GetComponentInParent<CharacterMovement>().aimv.y, GetComponentInParent<CharacterMovement>().aimv.x) * 180 / Mathf.PI, 0f, 0f); // this does the actual rotaion according to inputs
        }
    }
}
