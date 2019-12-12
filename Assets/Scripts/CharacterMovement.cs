using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private UI_Player_Manager ui;
    [SerializeField]
    private float jumpAcceleration = 25.0f;
    internal Vector2 movement;
    [SerializeField]
    internal PlayerControl pc;
    [SerializeField]
    private PhysicObject _physicObject;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private GameObject shoot;
    [SerializeField]
    private float accelerationFactor = 1f;

    private bool _jump = false;
    private bool _fastfall = false;
    private bool _shoot = false;


    [SerializeField]
    private Transform explosionPosition;
    [SerializeField]
    private float knockbackForce;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float heightModifier;

    private float cooldownTimer = 0.3f;
    private float cooldownCurrent = 0;
    private bool cooldownReached = false;
    private int shootCount = 0;

    private bool reloading = false;
    private float reloadColdownTimer = 2;
    private float reloadCooldownCurrent = 0;


    private void Awake()
    {
        shoot.SetActive(false);
        pc = new PlayerControl();
        pc.Gameplay.walk.performed += ctx => movement = ctx.ReadValue<Vector2>();
        pc.Gameplay.walk.canceled += ctx => movement = Vector2.zero;

        pc.Gameplay.jump.performed += ctx => _jump = _physicObject.IsOnGround();
        pc.Gameplay.jump.canceled += ctx => _jump = false;

        pc.Gameplay.fastfalling.performed += ctx => _fastfall = (!_physicObject.IsOnGround() || !_physicObject.IsOnPassPlatform());
        pc.Gameplay.fastfalling.canceled += ctx => _fastfall = false;

        pc.Gameplay.reload.performed += ctx => shootCount = 3;

        pc.Gameplay.shoot.performed += ctx => _shoot = true;
        pc.Gameplay.shoot.canceled += ctx => _shoot = false;


    }

    private void Start()
    {
        _physicObject = GetComponent<PhysicObject>();
        _rigidbody = GetComponent<Rigidbody>();
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
                _rigidbody.AddForce(Vector3.up * -jumpAcceleration*20f, ForceMode.Impulse);
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
                shoot.SetActive(true);
                ui.UseShell();
                shootCount += 1;
                cooldownReached = false;
                cooldownCurrent = 0f;
                Vector3 _explosionPosition = this.explosionPosition.position;
                Debug.Log("explosion");
                _rigidbody.AddExplosionForce(knockbackForce * 10000, _explosionPosition, explosionRadius, heightModifier);
                _shoot = false;

            }
        }

    }



    private void UpdatePosition()
    {
        Vector3 motion = Vector3.zero;
        motion.z = movement.x;
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

    private void OnEnable()
    {
        pc.Gameplay.Enable();
    }

    private void OnDisable()
    {
        pc.Gameplay.Disable();
    }

}
