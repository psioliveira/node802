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

    [SerializeField]
    internal PlayerControl playerControl;

    [SerializeField]
    private PhysicObject _physicObject;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private GameObject shoot;

    [SerializeField]
    private float accelerationFactor = 1f;


    internal Vector2 movement;
    internal Vector3 motion = Vector3.zero;

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


    private float cooldownTimer = 0.1f;
    private float cooldownCurrent = 0;
    private bool cooldownReached = false;
    private bool lastDirection = true;
    private int shootCount = 0;

    private bool reloading = false;
    private float reloadColdownTimer = 1;
    private float reloadCooldownCurrent = 0;


    private void Awake()
    {
        shoot.SetActive(false);
        playerControl = new PlayerControl();
        playerControl.Gameplay.walk.performed += ctx => movement = ctx.ReadValue<Vector2>();
        playerControl.Gameplay.walk.canceled += ctx => movement = Vector2.zero;

        playerControl.Gameplay.jump.performed += ctx => _jump = _physicObject.IsOnGround();
        playerControl.Gameplay.jump.canceled += ctx => _jump = false;

        playerControl.Gameplay.fastfalling.performed += ctx => _fastfall = (!_physicObject.IsOnGround() || !_physicObject.IsOnPassPlatform());
        playerControl.Gameplay.fastfalling.canceled += ctx => _fastfall = false;

        playerControl.Gameplay.reload.performed += ctx => shootCount = 3;

        playerControl.Gameplay.shoot.performed += ctx => _shoot = true;
        playerControl.Gameplay.shoot.canceled += ctx => _shoot = false;


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
                ui.UseShell();
                shootCount += 1;
                cooldownReached = false;
                cooldownCurrent = 0f;
                Vector3 _explosionPosition = this.explosionPosition.position;
                Debug.Log("explosion");
                _rigidbody.AddExplosionForce(knockbackForce * 10000, _explosionPosition, explosionRadius, heightModifier);
                _shoot = false;
                shoot.SetActive(true);

            }
        }

    }



    private void UpdatePosition()
    {
        //left direction --> direction equals true || right direction --> direction equals false
        bool direction = (motion.z + movement.x < motion.z ? true : false);

        motion.z = movement.x;

        if (direction != lastDirection)
        {
            lastDirection = direction;

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

    private void OnEnable()
    {
        playerControl.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControl.Gameplay.Disable();
    }

}
