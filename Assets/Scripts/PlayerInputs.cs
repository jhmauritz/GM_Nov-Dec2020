// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""04fec60e-5da6-4cf6-961b-96f84d72dfd4"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a96d5542-0716-4783-9991-284edefb2d11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch/Use"",
                    ""type"": ""PassThrough"",
                    ""id"": ""42a10f86-806f-4115-a27a-2f81fa6b1b20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PickUpItem"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cb218871-ff38-4cd7-94f6-e2384f6ffafb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4349d915-6591-43d3-9ea2-0019fcfd6b3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""2a8df229-903d-4ed1-96e4-aee70b2414f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03ae8dbc-5afb-4aad-bd95-8d2c8328e7b1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""Punch/Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc32c74-1d5b-4c38-b3fa-a1db93b1d556"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Punch/Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a59d9630-5114-4c51-b409-3d28487c7438"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""Punch/Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4add88a0-16d1-400d-b10e-82d8aebca820"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd8702fb-91f0-430c-81eb-f749d9c955a5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9d1e73a-7282-4c95-8b28-790eab31fe6b"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d3c896-8a8e-4187-85d8-924278836197"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ba28873-d911-4979-bae4-8db796eccbc8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8dd45b1-226a-4ced-99a9-330334e8590e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5986354-0831-49e2-91ab-9112d34006a5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95dd8a1e-ccd8-473e-a825-ea0ef63063aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0671988b-ea58-45ac-88b9-897e2d2504d4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""keyboard1"",
                    ""id"": ""758d25b5-0f19-44ed-9754-4ad3ccd0968e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8a24c658-2f8f-4389-84ba-cee1fe498466"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0be0a247-bd42-4d5b-8030-fbb781b2c035"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 1"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboard2"",
                    ""id"": ""46b45a49-f472-41aa-86e0-cd6d9f1dd53e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""68025bb6-9c07-4422-b3e0-0c955c15e824"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7f640b44-1012-4e8b-9f60-9faf21f09c42"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard - 2"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6d5c6676-66ba-4ec1-9865-04a9c160d14c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard - 1"",
            ""bindingGroup"": ""KeyBoard - 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyBoard - 2"",
            ""bindingGroup"": ""KeyBoard - 2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveForward = m_Player.FindAction("MoveForward", throwIfNotFound: true);
        m_Player_PunchUse = m_Player.FindAction("Punch/Use", throwIfNotFound: true);
        m_Player_PickUpItem = m_Player.FindAction("PickUpItem", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Duck = m_Player.FindAction("Duck", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveForward;
    private readonly InputAction m_Player_PunchUse;
    private readonly InputAction m_Player_PickUpItem;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Duck;
    public struct PlayerActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Player_MoveForward;
        public InputAction @PunchUse => m_Wrapper.m_Player_PunchUse;
        public InputAction @PickUpItem => m_Wrapper.m_Player_PickUpItem;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Duck => m_Wrapper.m_Player_Duck;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @PunchUse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunchUse;
                @PunchUse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunchUse;
                @PunchUse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunchUse;
                @PickUpItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpItem;
                @PickUpItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpItem;
                @PickUpItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpItem;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Duck.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @PunchUse.started += instance.OnPunchUse;
                @PunchUse.performed += instance.OnPunchUse;
                @PunchUse.canceled += instance.OnPunchUse;
                @PickUpItem.started += instance.OnPickUpItem;
                @PickUpItem.performed += instance.OnPickUpItem;
                @PickUpItem.canceled += instance.OnPickUpItem;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyBoard1SchemeIndex = -1;
    public InputControlScheme KeyBoard1Scheme
    {
        get
        {
            if (m_KeyBoard1SchemeIndex == -1) m_KeyBoard1SchemeIndex = asset.FindControlSchemeIndex("KeyBoard - 1");
            return asset.controlSchemes[m_KeyBoard1SchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyBoard2SchemeIndex = -1;
    public InputControlScheme KeyBoard2Scheme
    {
        get
        {
            if (m_KeyBoard2SchemeIndex == -1) m_KeyBoard2SchemeIndex = asset.FindControlSchemeIndex("KeyBoard - 2");
            return asset.controlSchemes[m_KeyBoard2SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnPunchUse(InputAction.CallbackContext context);
        void OnPickUpItem(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
    }
}
