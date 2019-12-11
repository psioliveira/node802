using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicObject : MonoBehaviour
{

    internal Vector3 gravityVector = Vector3.zero;
    internal Vector3 fallVelocity = Vector3.zero;
    internal Rigidbody rigidBody;
    [SerializeField]
    private string layer = "Ground";
    [SerializeField]
    private float gravityFactor = 1.5f;
    [SerializeField]
    internal float groundOfset = 3.55f;
    [SerializeField]
    internal float groundCheckRadius = 2f;
    [SerializeField]
    private float platformOfset = 5.18f;
    [SerializeField]
    internal float playerHeadOfset = -3.33f;
    [SerializeField]
    private float platformCheckRadius = 0.66f;
    [SerializeField]
    private float headCheckRadius = 2.1f;

    private void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
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

    internal GameObject GetPlatform()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - platformOfset, transform.position.z);
        Collider[] col = Physics.OverlapSphere(pos, platformCheckRadius, LayerMask.GetMask("pass through"));
        if (col.Length == 0)
        { return null; }
        else
        { return col[0].gameObject; }

    }

    internal bool IsOnPassPlatform()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - platformOfset, transform.position.z);
        Collider[] col = Physics.OverlapSphere(pos, platformCheckRadius, LayerMask.GetMask("pass through"));
        return (col.Length > 0 || col != null);
    }

    internal bool playerHeadInside()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - playerHeadOfset, transform.position.z);
        Collider[] col = Physics.OverlapSphere(pos, headCheckRadius, LayerMask.GetMask("pass through"));
        return (col.Length > 0 || col != null);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos1 = new Vector3(transform.position.x, transform.position.y - groundOfset, transform.position.z);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pos1, groundCheckRadius);

        Vector3 pos2 = new Vector3(transform.position.x, transform.position.y - platformOfset, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos2, platformCheckRadius);

        Vector3 pos3 = new Vector3(transform.position.x, transform.position.y - playerHeadOfset, transform.position.z);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pos3, headCheckRadius);

    }
}
