using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private GameObject pivotPoint;
    internal PlayerControl pc;
    Vector2 aimMove;
    public float speed;
    [SerializeField]
    private Vector3 analog = new Vector3();
    public Camera cam;
    public GameObject aim;
    private Rigidbody rigidBody;

    private void Awake()
    {
        pc = new PlayerControl();
        pc.Gameplay.walk.performed += ctx => aimMove = ctx.ReadValue<Vector2>();
        pc.Gameplay.walk.canceled += ctx => aimMove = Vector2.zero;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        analog.y = aimMove.y;
        analog.z = aimMove.x;
        AimCursor();
        pivotPoint.transform.LookAt(this.transform);
    }



    void AimCursor()
    {

        float _horizontal = aimMove.x;
        float _vertical = aimMove.y;
        rigidBody.velocity = new Vector3(0, _vertical * speed * -1, _horizontal * speed);

        //manter na camera


        if (transform.position.z > cam.transform.position.z + 100f)
        {
            aim.transform.position = new Vector3(aim.transform.position.x, aim.transform.position.y, (cam.transform.position.z + 100f));
        }

        if (transform.position.z < cam.transform.position.z - 100f)
        {
            aim.transform.position = new Vector3(aim.transform.position.x, aim.transform.position.y, (cam.transform.position.z - 100f));
        }

        if (transform.position.y > cam.transform.position.y + 100f)
        {
            aim.transform.position = new Vector3(aim.transform.position.x, (cam.transform.position.y + 0.6f), aim.transform.position.z);
        }

        if (transform.position.y < cam.transform.position.y - 100f)
        {
            aim.transform.position = new Vector3(aim.transform.position.x, (cam.transform.position.y - 100f), aim.transform.position.z);
        }

    }


    private void OnEnable()
    {
        pc.Gameplay.Enable();
    }

    private void OnDisable()
    {
        pc.Gameplay.Disable();
    }
}
