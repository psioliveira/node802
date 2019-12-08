using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    internal Vector2 movement;
    internal PlayerControl pc;

    private PhysicObject _phisicObject;
    private CharacterController _controller;
    private Vector3 _acceleration;
    private Vector3 _velocity;
    [SerializeField]
    private float _velocityFactor;
    private bool _jump;
    private bool _fastfall;

    private void Awake()
    {
        pc = new PlayerControl();
        pc.Gameplay.walk.performed += ctx => movement = ctx.ReadValue<Vector2>();
        pc.Gameplay.walk.canceled += ctx => movement = Vector2.zero;

        pc.Gameplay.jump.performed += ctx => _jump = _phisicObject.IsOnGround();
        pc.Gameplay.jump.canceled += ctx => _jump = false;

        pc.Gameplay.fastfalling.performed += ctx => _fastfall = !_phisicObject.IsOnGround();
        pc.Gameplay.fastfalling.canceled += ctx => _fastfall = false;

    }

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
        Debug.Log("gounded " + _phisicObject.IsOnGround());
        Debug.Log("gravity " + _phisicObject.ApplyGravity());
    }


    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }


    private void UpdateAcceleration()
    {
        _acceleration.z = movement.x;
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

    private void OnEnable()
    {
        pc.Gameplay.Enable();
    }

    private void OnDisable()
    {
        pc.Gameplay.Disable();
    }

}
