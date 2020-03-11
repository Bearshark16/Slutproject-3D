// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""FPS"",
            ""id"": ""e94a83a9-36c0-42f3-b750-6d2303b326b8"",
            ""actions"": [
                {
                    ""name"": ""Player Movement"",
                    ""type"": ""Button"",
                    ""id"": ""5fa74010-dacb-453b-b226-4aa6d9b59bc8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""c73142bd-6369-48a1-8ab1-97760fff82f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c83a86a3-7fc4-409c-853c-19c3c750168e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""3fa772ba-f177-4e93-a417-78c1119f40d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7bd2c13e-6b6f-41ea-9af2-41b87aa81961"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5166a52e-abd8-49b1-8195-88669b8d6d39"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa957449-394e-423d-82c8-78c5326961a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eee58568-62b0-4e22-9928-9a0d7bae5cc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0daf6ce2-9865-482b-96ca-94102566304a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37a4e764-a7d5-40d2-902a-382d28d76b1b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2164c25c-dfb4-44d6-956b-0d69cb313201"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52e3297d-467e-4c1a-ab5e-7e0bc30ca6cc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPS
        m_FPS = asset.FindActionMap("FPS", throwIfNotFound: true);
        m_FPS_PlayerMovement = m_FPS.FindAction("Player Movement", throwIfNotFound: true);
        m_FPS_Sprint = m_FPS.FindAction("Sprint", throwIfNotFound: true);
        m_FPS_Jump = m_FPS.FindAction("Jump", throwIfNotFound: true);
        m_FPS_Fire = m_FPS.FindAction("Fire", throwIfNotFound: true);
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

    // FPS
    private readonly InputActionMap m_FPS;
    private IFPSActions m_FPSActionsCallbackInterface;
    private readonly InputAction m_FPS_PlayerMovement;
    private readonly InputAction m_FPS_Sprint;
    private readonly InputAction m_FPS_Jump;
    private readonly InputAction m_FPS_Fire;
    public struct FPSActions
    {
        private @InputActions m_Wrapper;
        public FPSActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_FPS_PlayerMovement;
        public InputAction @Sprint => m_Wrapper.m_FPS_Sprint;
        public InputAction @Jump => m_Wrapper.m_FPS_Jump;
        public InputAction @Fire => m_Wrapper.m_FPS_Fire;
        public InputActionMap Get() { return m_Wrapper.m_FPS; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSActions set) { return set.Get(); }
        public void SetCallbacks(IFPSActions instance)
        {
            if (m_Wrapper.m_FPSActionsCallbackInterface != null)
            {
                @PlayerMovement.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnPlayerMovement;
                @PlayerMovement.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnPlayerMovement;
                @PlayerMovement.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnPlayerMovement;
                @Sprint.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_FPSActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayerMovement.started += instance.OnPlayerMovement;
                @PlayerMovement.performed += instance.OnPlayerMovement;
                @PlayerMovement.canceled += instance.OnPlayerMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public FPSActions @FPS => new FPSActions(this);
    public interface IFPSActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
