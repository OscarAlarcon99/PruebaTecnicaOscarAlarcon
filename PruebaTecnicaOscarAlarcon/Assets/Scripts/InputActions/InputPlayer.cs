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
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""5bf30b2c-92d1-484f-9852-ec7bca1050ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=1)""
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
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMovementAndroid"",
            ""id"": ""caba91e4-fa62-4b53-a933-88c0e97a615b"",
            ""actions"": [
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""276f3ea7-1aed-4884-881f-1519a7670ba5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
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
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""070c0a0f-afd4-41a9-bfc6-adfa69d8162e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""bfacfe58-8c2d-4b88-a5ce-99a2ef18d848"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=1)""
                }
            ],
            ""bindings"": [
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
                    ""id"": ""61e8d380-cf03-4c3a-a605-db457e0ad6f3"",
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
                    ""id"": ""0a8bdd66-e38d-4c84-ae25-4ef7efdaf351"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Action"",
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
        m_PlayerMovement_Test = m_PlayerMovement.FindAction("Test", throwIfNotFound: true);
        // PlayerMovementAndroid
        m_PlayerMovementAndroid = asset.FindActionMap("PlayerMovementAndroid", throwIfNotFound: true);
        m_PlayerMovementAndroid_Action = m_PlayerMovementAndroid.FindAction("Action", throwIfNotFound: true);
        m_PlayerMovementAndroid_Jump = m_PlayerMovementAndroid.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovementAndroid_Look = m_PlayerMovementAndroid.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovementAndroid_Move = m_PlayerMovementAndroid.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovementAndroid_Test = m_PlayerMovementAndroid.FindAction("Test", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMovement_Test;
    public struct PlayerMovementActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerMovementActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerMovement_Action;
        public InputAction @Test => m_Wrapper.m_PlayerMovement_Test;
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
                @Test.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTest;
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
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerMovementAndroid
    private readonly InputActionMap m_PlayerMovementAndroid;
    private IPlayerMovementAndroidActions m_PlayerMovementAndroidActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementAndroid_Action;
    private readonly InputAction m_PlayerMovementAndroid_Jump;
    private readonly InputAction m_PlayerMovementAndroid_Look;
    private readonly InputAction m_PlayerMovementAndroid_Move;
    private readonly InputAction m_PlayerMovementAndroid_Test;
    public struct PlayerMovementAndroidActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerMovementAndroidActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_PlayerMovementAndroid_Action;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementAndroid_Jump;
        public InputAction @Look => m_Wrapper.m_PlayerMovementAndroid_Look;
        public InputAction @Move => m_Wrapper.m_PlayerMovementAndroid_Move;
        public InputAction @Test => m_Wrapper.m_PlayerMovementAndroid_Test;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementAndroid; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementAndroidActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementAndroidActions instance)
        {
            if (m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface != null)
            {
                @Action.started -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnAction;
                @Jump.started -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnLook;
                @Move.started -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnMove;
                @Test.started -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_PlayerMovementAndroidActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public PlayerMovementAndroidActions @PlayerMovementAndroid => new PlayerMovementAndroidActions(this);
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
        void OnTest(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementAndroidActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnTest(InputAction.CallbackContext context);
    }
}
