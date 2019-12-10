using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicObject : MonoBehaviour
{
    internal const float minimumMovementDistance = 0.1f;

    internal Vector3 gravityVector = Vector3.zero;
    internal Vector3 gravitySide = Vector3.up;
    internal Vector3 fallVelocity = Vector3.zero;
    internal Rigidbody rigidBody;
    [SerializeField]
    private string layer = "Ground";
    [SerializeField]
    private float gravityFactor = 1;
    [SerializeField]
    internal float groundOfset = 0;
    [SerializeField]
    internal float groundCheckRadius = 0.5f;

    // internal Side ChoosedSide = Side.down;

    //public enum Side
    //{ up, down, left, right }

    private void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }
    // Update is called once per frame
    void Update()
    {
        //switch (ChoosedSide)
        //{
        //    case Side.up:
        //        gravityVector = new Vector3(0, 1F, 0);
        //        gravitySide = Vector3.up;
        //        break;

        //    case Side.down:
        //        gravityVector = new Vector3(0, -1F, 0);
        //        gravitySide = Vector3.up;
        //        break;

        //    case Side.left:
        //        gravityVector = new Vector3(0, 0, -1F);
        //        gravitySide = Vector3.forward;
        //        break;

        //    case Side.right:
        //        gravityVector = new Vector3(0, 0, 1F);
        //        gravitySide = Vector3.forward;
        //        break;

        //    default:
        //        gravityVector = new Vector3(0, -1F, 0);
        //        gravitySide = Vector3.up;
        //        break;
        //}
    }
    private void FixedUpdate()
    {
        rigidBody.AddForce(Physics.gravity * (Mathf.Pow(rigidBody.mass, 2)) * gravityFactor);
    }

    internal bool IsOnGround()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - groundOfset, transform.position.z);
        Collider[] col = Physics.OverlapSphere(pos, groundCheckRadius, LayerMask.GetMask(layer));
        return (col.Length > 0 && col != null);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos1 = new Vector3(transform.position.x, transform.position.y - groundOfset, transform.position.z);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pos1, groundCheckRadius);

    }
}
