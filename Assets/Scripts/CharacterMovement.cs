using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float maxForwardAcceleration = 10.0f;

    [SerializeField]
    private float maxBackwardAcceleration = 10.0f;

    [SerializeField]
    private float jumpAcceleration = 25000.0f;

    [SerializeField]
    private float maxForwardVelocity = 12.0f;

    [SerializeField]
    private float maxBackwardVelocity = 12.0f;

    [SerializeField]
    private float maxJumpVelocity = 200.0f;

    [SerializeField]
    private float maxFallVelocity = 120.0f;


    private PhysicObject _phisicObject;
    private CharacterController _controller;
    private Vector3 _acceleration;
    private Vector3 _velocity;
    [SerializeField]
    private float _velocityFactor;
    private bool _jump;



    private void Start()
    {
        _phisicObject = GetComponent<PhysicObject>();
        _controller = GetComponent<CharacterController>();
        _acceleration = Vector3.zero;
        _velocity = Vector3.zero;
        _velocityFactor = 5.0f;
        _jump = false;
    }

    private void Update()
    {
        UpdateJump();
        Debug.Log("gounded " + _phisicObject.IsOnGround());
        Debug.Log("gravity " + _phisicObject.ApplyGravity());

    }

    private void UpdateJump()
    {
        if (_phisicObject.IsOnGround() && Input.GetButtonDown("Jump"))
            _jump = true;
    }


    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }


    private void UpdateAcceleration()
    {
        _acceleration.z = Input.GetAxis("Forward");
        _acceleration.z *= _acceleration.z > 0f ? maxForwardAcceleration * _velocityFactor : maxBackwardAcceleration * _velocityFactor;

        if (_phisicObject.ApplyGravity())
        {
            _acceleration.y = 0f;
            if (_jump && _phisicObject.IsOnGround())
            {
                _jump = false;
                _acceleration.y = jumpAcceleration;
            }
        }
        else
            _acceleration.y =- _phisicObject.gravityModifier;
    }



    private void UpdateVelocity()
    {
        _velocity += _acceleration * Time.fixedDeltaTime;

        _velocity.z = _acceleration.z == 0f ? 0f : Mathf.Clamp(_velocity.z, -maxBackwardVelocity * _velocityFactor, maxForwardVelocity * _velocityFactor);
        _velocity.y = _acceleration.y == 0f ? -0.1f : Mathf.Clamp(_velocity.y, -maxFallVelocity, maxJumpVelocity);
    }

    private void UpdatePosition()
    {
        Vector3 motion = _velocity * Time.fixedDeltaTime;

        _controller.Move(transform.TransformVector(motion));
    }


}
