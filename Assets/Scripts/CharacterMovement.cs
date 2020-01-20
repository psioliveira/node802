using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerControl playerControl;

    [SerializeField]
    private UI_Player_Manager ui;

    [SerializeField]
    private float jumpAcceleration = 25.0f;

    [SerializeField]
    private PhysicObject _physicObject;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private GameObject shoot;

    [SerializeField]
    private float accelerationFactor = 1f;

    [SerializeField]
    private Transform aim;

    [SerializeField]
    private GameObject[] OtherPlayer;

    internal Vector2 movement;
    internal Vector3 motion = Vector3.zero;

    private bool _jump = false;
    private bool _fastfall = false;
    private bool _shoot = false;

    [SerializeField]
    private float knockbackForce;
    [SerializeField]
    private float heightModifier;

    [SerializeField]
    private float cooldownTimer = 0.1f;

    private float cooldownCurrent = 0;
    private bool cooldownReached = false;
    private bool lastDirection = true;
    private int shootCount = 0;

    private bool reloading = false;
    [SerializeField]
    private float reloadColdownTimer = 1;
    private float reloadCooldownCurrent = 0;
    private void Awake()
    {
        shoot.SetActive(false);
        playerControl = new PlayerControl();
    }
    private void Start()
    {
        _physicObject = GetComponent<PhysicObject>();
        _rigidbody = GetComponent<Rigidbody>();
        OtherPlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in OtherPlayer)
        {
            Physics.IgnoreCollision(g.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
    private void OnWalk(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = _physicObject.IsOnGround();
    }

    private void OnShoot()
    {
        _shoot = true;
    }

    private void OnFastfalling()
    {
        _fastfall = (!_physicObject.IsOnGround() || !_physicObject.IsOnPassPlatform());
    }

    private void OnReaload()
    {
        shootCount = 3;
    }

    private void OnCrouch()
    {

    }

    private void OnPassthrough()
    {

    }



    private void Update()
    {
        if (!cooldownReached)
        {
            cooldownCurrent += Time.deltaTime;
            if (cooldownCurrent >= cooldownTimer)
            {
                cooldownReached = true;
                shoot.SetActive(false);
            }
        }

        if (reloading == true)
        {
            reloadCooldownCurrent += Time.deltaTime;
            if (reloadCooldownCurrent >= reloadColdownTimer)
            {
                reloading = false;

            }
        }

        if (shootCount >= 3)
        {
            shootCount = 0;
            reloading = true;
            reloadCooldownCurrent = 0;
            ui.ReloadShell(reloadColdownTimer);
        }

    }




    void FixedUpdate()
    {
        UpdateKnockback();
        UpdateAcceleration();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        if (_jump)
        {
            _rigidbody.AddForce(Vector3.up * jumpAcceleration, ForceMode.Impulse);
            _jump = false;
        }

        if (!_physicObject.IsOnGround())
        {
            if (_fastfall)
            {
                _rigidbody.AddForce(Vector3.up * -jumpAcceleration * 20f, ForceMode.Impulse);
                _fastfall = false;
            }
        }

    }
    private void UpdateKnockback()
    {
        if (cooldownReached && !reloading)
        {
            if (_shoot)
            {
                //  ui.UseShell();
                _shoot = false;
                shootCount += 1;
                cooldownReached = false;
                cooldownCurrent = 0f;
                Vector3 velocity = _rigidbody.velocity;
                velocity.z = 0;

                Vector3 _knockbackDirection = (transform.position - aim.position).normalized;
                Debug.Log("explosion");
                _rigidbody.AddForce(_knockbackDirection * 100f * knockbackForce, ForceMode.Impulse);

                shoot.SetActive(true);

            }
        }
        else
        {
            _shoot = false;
        }

    }
    private void UpdatePosition()
    {
        bool direction = (motion.z + movement.x < motion.z ? true : false);

        motion.z = movement.x;

        if (direction != lastDirection)
        {
            lastDirection = direction;

            Vector3 velocity = _rigidbody.velocity;
            velocity.z = 0;
            _rigidbody.velocity = velocity;

        }
        if (movement == Vector2.zero)
        {
            Vector3 velocity = _rigidbody.velocity;
            velocity.z = 0;
            _rigidbody.velocity = velocity;
        }

        _rigidbody.AddForce(motion * accelerationFactor, ForceMode.Acceleration);

        if (_physicObject.IsOnGround())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, Mathf.Clamp(_rigidbody.velocity.z, -65f, 65f));
        }
        else
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, Mathf.Clamp(_rigidbody.velocity.z, -100f, 100f));
        }
    }




}
