// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Gameplay1"",
            ""id"": ""4bcede47-ac67-4a47-915b-094e63c410aa"",
            ""actions"": [
                {
                    ""name"": ""aim"",
                    ""type"": ""Button"",
                    ""id"": ""74f36cd6-7bcb-45b0-99ca-7a2cda4d95c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""walk"",
                    ""type"": ""Button"",
                    ""id"": ""801f4216-e6a6-4c27-9283-c5b4534c1ff6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""0b889051-a027-45ef-9e27-2230c7761492"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fast falling"",
                    ""type"": ""Button"",
                    ""id"": ""6f3feec0-8650-41a4-806c-31ceb997b217"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""be58f14d-0d83-44f6-80e0-824e070898c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pass through"",
                    ""type"": ""Button"",
                    ""id"": ""694d2f52-0721-46f4-a3a6-4198a119cb0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""reload"",
                    ""type"": ""Button"",
                    ""id"": ""38a5a327-dee2-4ab1-9839-45d14997ac0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""crouch"",
                    ""type"": ""Button"",
                    ""id"": ""e98568cd-d133-439a-8748-e19ebe0dda89"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f35366c7-df97-4237-8625-d565cb86771b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48c3cd66-fab7-467a-99d0-b536ca6f3006"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f04d1ec1-31ff-426e-ba34-207c9f22cf0b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fast falling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b5e2ea6-eb01-4bae-9263-32935cbb34ad"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00141b9b-fd37-4c2f-bdab-47236cc02ec6"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pass through"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fd23501-be94-4083-a953-15d740485d8a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ec8eee-12f2-48c4-bcb5-7f1f764ff705"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""374ee93c-0e00-49ce-8e7d-39d37306b191"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay1
        m_Gameplay1 = asset.FindActionMap("Gameplay1", throwIfNotFound: true);
        m_Gameplay1_aim = m_Gameplay1.FindAction("aim", throwIfNotFound: true);
        m_Gameplay1_walk = m_Gameplay1.FindAction("walk", throwIfNotFound: true);
        m_Gameplay1_jump = m_Gameplay1.FindAction("jump", throwIfNotFound: true);
        m_Gameplay1_fastfalling = m_Gameplay1.FindAction("fast falling", throwIfNotFound: true);
        m_Gameplay1_shoot = m_Gameplay1.FindAction("shoot", throwIfNotFound: true);
        m_Gameplay1_passthrough = m_Gameplay1.FindAction("pass through", throwIfNotFound: true);
        m_Gameplay1_reload = m_Gameplay1.FindAction("reload", throwIfNotFound: true);
        m_Gameplay1_crouch = m_Gameplay1.FindAction("crouch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay1
    private readonly InputActionMap m_Gameplay1;
    private IGameplay1Actions m_Gameplay1ActionsCallbackInterface;
    private readonly InputAction m_Gameplay1_aim;
    private readonly InputAction m_Gameplay1_walk;
    private readonly InputAction m_Gameplay1_jump;
    private readonly InputAction m_Gameplay1_fastfalling;
    private readonly InputAction m_Gameplay1_shoot;
    private readonly InputAction m_Gameplay1_passthrough;
    private readonly InputAction m_Gameplay1_reload;
    private readonly InputAction m_Gameplay1_crouch;
    public struct Gameplay1Actions
    {
        private @PlayerControl m_Wrapper;
        public Gameplay1Actions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @aim => m_Wrapper.m_Gameplay1_aim;
        public InputAction @walk => m_Wrapper.m_Gameplay1_walk;
        public InputAction @jump => m_Wrapper.m_Gameplay1_jump;
        public InputAction @fastfalling => m_Wrapper.m_Gameplay1_fastfalling;
        public InputAction @shoot => m_Wrapper.m_Gameplay1_shoot;
        public InputAction @passthrough => m_Wrapper.m_Gameplay1_passthrough;
        public InputAction @reload => m_Wrapper.m_Gameplay1_reload;
        public InputAction @crouch => m_Wrapper.m_Gameplay1_crouch;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay1Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay1Actions instance)
        {
            if (m_Wrapper.m_Gameplay1ActionsCallbackInterface != null)
            {
                @aim.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAim;
                @aim.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAim;
                @aim.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnAim;
                @walk.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnWalk;
                @walk.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnWalk;
                @walk.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnWalk;
                @jump.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnJump;
                @fastfalling.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnFastfalling;
                @fastfalling.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnFastfalling;
                @fastfalling.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnFastfalling;
                @shoot.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnShoot;
                @passthrough.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnPassthrough;
                @passthrough.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnPassthrough;
                @passthrough.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnPassthrough;
                @reload.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReload;
                @reload.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReload;
                @reload.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReload;
                @crouch.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnCrouch;
                @crouch.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnCrouch;
                @crouch.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_Gameplay1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @aim.started += instance.OnAim;
                @aim.performed += instance.OnAim;
                @aim.canceled += instance.OnAim;
                @walk.started += instance.OnWalk;
                @walk.performed += instance.OnWalk;
                @walk.canceled += instance.OnWalk;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @fastfalling.started += instance.OnFastfalling;
                @fastfalling.performed += instance.OnFastfalling;
                @fastfalling.canceled += instance.OnFastfalling;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
                @passthrough.started += instance.OnPassthrough;
                @passthrough.performed += instance.OnPassthrough;
                @passthrough.canceled += instance.OnPassthrough;
                @reload.started += instance.OnReload;
                @reload.performed += instance.OnReload;
                @reload.canceled += instance.OnReload;
                @crouch.started += instance.OnCrouch;
                @crouch.performed += instance.OnCrouch;
                @crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public Gameplay1Actions @Gameplay1 => new Gameplay1Actions(this);
    public interface IGameplay1Actions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFastfalling(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnPassthrough(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
