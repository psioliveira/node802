using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float jumpAcceleration = 25.0f;
    internal Vector2 movement;
    internal PlayerControl pc;
    private PhysicObject _phisicObject;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float accelerationFactor = 1f;
    private bool _jump;
    private bool _fastfall;
    private bool _pass;

    private void Awake()
    {
        pc = new PlayerControl();
        pc.Gameplay.walk.performed += ctx => movement = ctx.ReadValue<Vector2>();
        pc.Gameplay.walk.canceled += ctx => movement = Vector2.zero;

        pc.Gameplay.jump.performed += ctx => _jump = _phisicObject.IsOnGround();
        pc.Gameplay.jump.canceled += ctx => _jump = false;

        pc.Gameplay.fastfalling.performed += ctx => _fastfall = (!_phisicObject.IsOnGround() || !_phisicObject.IsOnPassPlatform());
        pc.Gameplay.fastfalling.canceled += ctx => _fastfall = false;

        pc.Gameplay.passthrough.performed += ctx => _pass = _phisicObject.IsOnPassPlatform();
        pc.Gameplay.fastfalling.canceled += ctx => _pass = false;

    }

    private void Start()
    {
        _phisicObject = GetComponent<PhysicObject>();
        _rigidbody = GetComponent<Rigidbody>();
        _jump = false;
    }

    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdatePosition();
        UpdatePassThrough();
    }
    private void UpdateAcceleration()
    {
        if (_jump && _phisicObject.IsOnGround())
        {
            _rigidbody.AddForce(Vector3.up * jumpAcceleration, ForceMode.Impulse);
            _jump = false;
        }

    }

    private void UpdatePassThrough()
    {
        if (_phisicObject.playerHeadInside())
        { Physics.IgnoreCollision(this.GetComponent<Collider>(), _phisicObject.GetPlatform().GetComponent<Collider>(), false); }

        if (_pass && _phisicObject.IsOnPassPlatform())
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), _phisicObject.GetPlatform().GetComponent<Collider>(), true);
            _pass = false;
        }
    }

    private void UpdatePosition()
    {
        Vector3 motion = Vector3.zero;
        motion.z = movement.x;
        _rigidbody.AddForce(motion * accelerationFactor, ForceMode.Acceleration);
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
