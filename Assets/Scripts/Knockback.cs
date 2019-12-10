using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    internal float knockback_y = 1;
    [SerializeField]
    internal float knockback_z = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.collider.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction = direction.normalized;
            direction.x = 0;
            direction.y *= knockback_y;
            direction.z *= knockback_z;

            rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}
