// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/InputPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayer"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""e6a1622f-366e-4225-8052-486b6c96f08f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""069970b5-ac1d-444c-847f-e1d2979a039e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""f61e2d36-6be0-4395-91dc-db8e2db38078"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""85d04d25-7e36-47f1-b0f3-faee5ab38767"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""94917408-7889-48e1-92e5-196db2964b82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5bf30b2c-92d1-484f-9852-ec7bca1050ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=1)""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""76c2356e-d1bf-4507-b6ee-e344825a9f91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""188d9d12-d293-47e7-b48d-65d9a37851d9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b435cd99-1925-4fe6-bb76-0763641585a4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ba21b98e-c3fa-4fe2-8a21-f8a75fa31db9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f5660520-d012-4fa8-8a6d-87fb5131b4a4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be0c93a5-8be7-463a-bdde-3fc4542eea14"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""7f44f005-802f-4b0e-858d-06425e84c876"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4d3bc0b3-53cd-4513-a4f0-b2f7647fe532"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""671ba616-4963-438e-b7f5-d5a09a6ea09d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c74205b1-65d7-497c-a607-0b6a8373ef4f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""463b09d9-15e3-46e0-b359-25dbc4431e98"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""becb8041-7bd6-49c5-a44d-bc4f2de5e78d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcc786c9-a050-4a50-8ce9-1637e54665ff"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83f5a5fc-7d46-4b46-ae61-4dbdefa2ae94"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17e03b27-259a-4ac3-a947-16f39572b247"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e913d89-b2b8-4dba-b8ed-9adfb75760f5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96f39206-d0c7-425a-b6bc-4ad8f7b01378"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c826bf6-679d-40b4-b3bc-41cf68cea7a6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMovementTouch"",
            ""id"": ""caba91e4-fa62-4b53-a933-88c0e97a615b"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0ebccb81-fac7-44a7-bb5c-761ed063422f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6662feaf-d726-44c8-820f-4097f465b6ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""81489641-94f8-46ce-a323-021aa50bd031"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cce602c9-ab0a-403a-9f75-6568cd95a5ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""276f3ea7-1aed-4884-881f-1519a7670ba5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2933f839-32cc-40b4-9d4c-95019b0a0411"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryTouchContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""070c0a0f-afd4-41a9-bfc6-adfa69d8162e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryTouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3ebf30f2-e53b-4912-8ee7-7cd1ed9c12a9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff4b9df6-c8c2-4b2a-9e10-ba06c11ce2ba"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aac434d-9d0e-4779-b5ec-24fb558dfa08"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16821d19-e3c9-4a7d-bde9-7d2a84230c83"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e23a70-4169-4c06-aaca-1bcff61be7b7"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee87174a-c1ae-4206-9b38-3e5a85154a85"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""GamePad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a8bdd66-e38d-4c84-ae25-4ef7efdaf351"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0dbaa24-5a9d-4f6e-9b63-457a64600745"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee54954c-cfc2-4f7b-a5e0-7ae47c4cb9d8"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_Look = m_PlayerMovement.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Action = m_PlayerMovement.FindAction("Action", throwIfNotFound: true);
        m_PlayerMovement_Pause = m_PlayerMovement.FindAction("Pause", throwIfNotFound: true);
        m_PlayerMovement_Aim = m_PlayerMovement.FindAction("Aim", throwIfNotFound: true);
        // PlayerMovementTouch
        m_PlayerMovementTouch = asset.FindActionMap("PlayerMovementTouch", throwIfNotFound: true);
        m_PlayerMovementTouch_Aim = m_PlayerMovementTouch.FindAction("Aim", throwIfNotFound: true);
        m_PlayerMovementTouch_Move = m_PlayerMovementTouch.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovementTouch_Look = m_PlayerMovementTouch.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovementTouch_Jump = m_PlayerMovementTouch.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovementTouch_Action = m_PlayerMovementTouch.FindAction("Action", throwIfNotFound: true);
        m_PlayerMovementTouch_Pause = m_PlayerMovementTouch.FindAction("Pause", throwIfNotFound: true);
        m_PlayerMovementTouch_PrimaryTouchContact = m_PlayerMovementTouch.FindAction("PrimaryTouchContact", throwIfNotFound: true);
        m_PlayerMovementTouch_PrimaryTouchPosition = m_PlayerMovementTouch.FindAction("PrimaryTouchPosition", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_Look;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Action;
    private readonly InputAction m_PlayerMovement_Pause;
    private readonly InputAction m_PlayerMovement_Aim;
    public struct PlayerMovementActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerMovementActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerMovement_Action;
        public InputAction @Pause => m_Wrapper.m_PlayerMovement_Pause;
        public InputAction @Aim => m_Wrapper.m_PlayerMovement_Aim;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction;
                @Pause.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPause;
                @Aim.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerMovementTouch
    private readonly InputActionMap m_PlayerMovementTouch;
    private IPlayerMovementTouchActions m_PlayerMovementTouchActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementTouch_Aim;
    private readonly InputAction m_PlayerMovementTouch_Move;
    private readonly InputAction m_PlayerMovementTouch_Look;
    private readonly InputAction m_PlayerMovementTouch_Jump;
    private readonly InputAction m_PlayerMovementTouch_Action;
    private readonly InputAction m_PlayerMovementTouch_Pause;
    private readonly InputAction m_PlayerMovementTouch_PrimaryTouchContact;
    private readonly InputAction m_PlayerMovementTouch_PrimaryTouchPosition;
    public struct PlayerMovementTouchActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerMovementTouchActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_PlayerMovementTouch_Aim;
        public InputAction @Move => m_Wrapper.m_PlayerMovementTouch_Move;
        public InputAction @Look => m_Wrapper.m_PlayerMovementTouch_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementTouch_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerMovementTouch_Action;
        public InputAction @Pause => m_Wrapper.m_PlayerMovementTouch_Pause;
        public InputAction @PrimaryTouchContact => m_Wrapper.m_PlayerMovementTouch_PrimaryTouchContact;
        public InputAction @PrimaryTouchPosition => m_Wrapper.m_PlayerMovementTouch_PrimaryTouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementTouch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementTouchActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementTouchActions instance)
        {
            if (m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAim;
                @Move.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnAction;
                @Pause.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPause;
                @PrimaryTouchContact.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchContact;
                @PrimaryTouchContact.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchContact;
                @PrimaryTouchContact.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchContact;
                @PrimaryTouchPosition.started -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.performed -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.canceled -= m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface.OnPrimaryTouchPosition;
            }
            m_Wrapper.m_PlayerMovementTouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @PrimaryTouchContact.started += instance.OnPrimaryTouchContact;
                @PrimaryTouchContact.performed += instance.OnPrimaryTouchContact;
                @PrimaryTouchContact.canceled += instance.OnPrimaryTouchContact;
                @PrimaryTouchPosition.started += instance.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.performed += instance.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.canceled += instance.OnPrimaryTouchPosition;
            }
        }
    }
    public PlayerMovementTouchActions @PlayerMovementTouch => new PlayerMovementTouchActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementTouchActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnPrimaryTouchContact(InputAction.CallbackContext context);
        void OnPrimaryTouchPosition(InputAction.CallbackContext context);
    }
}
