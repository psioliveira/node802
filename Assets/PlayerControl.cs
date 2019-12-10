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
            ""name"": ""Gameplay"",
            ""id"": ""0b4c6b6b-8376-42da-852a-356ca7c101ee"",
            ""actions"": [
                {
                    ""name"": ""walk"",
                    ""type"": ""Button"",
                    ""id"": ""abab9b90-6c8e-4a4b-a230-c1c01675538b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5dbb3ff-3c82-4796-b062-930c576a1355"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fast falling"",
                    ""type"": ""Button"",
                    ""id"": ""15e9b881-2cc7-4770-95d9-fb11a45b5a0c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5f8c29da-5569-4233-b4e5-4dd8a079e486"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e61de8e7-ffac-4ca1-af4a-660e3a787d2b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18955933-5145-4ca3-9f40-5ba193201269"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""033d9c9b-1ed9-4a74-8a31-95c17705fd05"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fast falling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9887a51c-0990-444d-9056-0464f4cfddc7"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_walk = m_Gameplay.FindAction("walk", throwIfNotFound: true);
        m_Gameplay_jump = m_Gameplay.FindAction("jump", throwIfNotFound: true);
        m_Gameplay_fastfalling = m_Gameplay.FindAction("fast falling", throwIfNotFound: true);
        m_Gameplay_shoot = m_Gameplay.FindAction("shoot", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_walk;
    private readonly InputAction m_Gameplay_jump;
    private readonly InputAction m_Gameplay_fastfalling;
    private readonly InputAction m_Gameplay_shoot;
    public struct GameplayActions
    {
        private @PlayerControl m_Wrapper;
        public GameplayActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @walk => m_Wrapper.m_Gameplay_walk;
        public InputAction @jump => m_Wrapper.m_Gameplay_jump;
        public InputAction @fastfalling => m_Wrapper.m_Gameplay_fastfalling;
        public InputAction @shoot => m_Wrapper.m_Gameplay_shoot;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @walk.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWalk;
                @walk.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWalk;
                @walk.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWalk;
                @jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @fastfalling.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastfalling;
                @fastfalling.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastfalling;
                @fastfalling.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastfalling;
                @shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
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
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFastfalling(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
