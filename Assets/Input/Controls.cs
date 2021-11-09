// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Crab"",
            ""id"": ""8885c993-40b8-40e4-8059-494efa8b03e0"",
            ""actions"": [
                {
                    ""name"": ""Click Left"",
                    ""type"": ""Button"",
                    ""id"": ""0cb487c6-ec08-46a1-9e9c-b362d3f12812"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click Right"",
                    ""type"": ""Button"",
                    ""id"": ""7c212cd7-3a62-4e8d-b3d6-0bcbdfa2265b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Leg"",
                    ""type"": ""Value"",
                    ""id"": ""f290848a-6572-42d4-af7b-6743e03b3667"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Leg"",
                    ""type"": ""Value"",
                    ""id"": ""a480f5c8-a945-4ff1-a74e-58bdcc110dc6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""9fd0257b-2f86-4122-903c-f16197712948"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f9c74e14-620c-4535-9d08-51b93c27a5e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a8687e1-fb79-4161-b85d-84327a95c135"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24e50812-2bcf-4396-a436-a8cbe37e7cb8"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06685f0f-134e-44e4-bcbe-b840d1312c49"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c865e78-1c47-475c-9f95-a4a9c2f530ed"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ede101e-1824-4312-b6f7-506c0b772d87"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b05437fb-3407-4c67-8a5e-af143bb0916d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ccd6ba0-6336-45b7-aada-028204895b6d"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LR"",
                    ""id"": ""f366b4f2-dc49-4230-a5c7-bf7e0ebaf899"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Leg"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f294e774-709c-4ea5-be03-d4bfd7d41d83"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf42dc7e-586f-4216-889e-f8462a8017fc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e06943b6-e6e8-4798-afd8-0fd2c60b1e1d"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""5aa4df5d-649e-4e96-b6f1-6e85487c8ba4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Leg"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cff743b9-3e2a-4748-8034-6137cbbe5a5a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""eef287f5-b208-470a-bd54-77bf897a5fb1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Leg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a13a2b6-0fc4-43f4-80bb-a99bb12f435c"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3e4d800-907a-411d-9685-e7c5da63e67e"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb4f60d8-69cf-4449-92bf-a0724900ff5b"",
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
                    ""id"": ""90f17fb3-4f62-4e07-a6d6-ba763e26db2e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab45efac-78e4-43ac-a02b-1eb021e172c8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4d86c30-7f5c-48b1-b00e-801f5a968a43"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ca5f023f-6a5d-495e-a17b-68ac0cec936b"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""afb461a8-3fd8-4154-aeb2-3dade21be9fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""30227beb-ce6d-40ef-8cc9-0b498bded27e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d02a3e36-d785-4abb-bab8-88ac1647fa48"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cfaee143-4c4c-4516-983f-e6b37f82edf1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c69132e-9219-4485-8842-70630deb4897"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""458f6e1b-2960-406d-af7e-6a7786f30a2a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4510375a-7554-4246-b207-484573e1894d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Vector"",
                    ""id"": ""4450e03b-5904-44f2-9708-67e94414dbff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6371079-eb17-4ede-bbb8-f45733efcbf1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4aa10913-a345-451a-84e8-cbb96b91a6fe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d535a13b-119b-46a3-9005-8ee9fafa55d5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ddb76234-4f56-4927-b977-58b21f5acff3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be2be74e-3071-49b3-bab1-f672f0ba86d0"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""65d4d289-f2fd-4da1-8576-8155a4d35040"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fa516908-dda1-4a76-ab4f-af668d681ada"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2aee6d4-7299-4abb-8b51-6338498439ef"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""46ecfd46-eae2-4eaf-a5ca-6e14ad2d16ae"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3a86d552-94a5-45e9-a291-a2c8db91af0c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4cc499a5-706b-4df1-af14-c1efd967f447"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""38639ef0-ae7c-4092-9f00-b6ae02960de4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""516532f0-25d7-4667-b0ce-959521c355e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a10b24b1-bc48-41a6-ba1a-ab188151ba9f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""feab51d1-3ea9-4389-af09-3a3fda374f64"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c27c00e2-1cbc-4a3c-a081-1e9adffcc39e"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Crab
        m_Crab = asset.FindActionMap("Crab", throwIfNotFound: true);
        m_Crab_ClickLeft = m_Crab.FindAction("Click Left", throwIfNotFound: true);
        m_Crab_ClickRight = m_Crab.FindAction("Click Right", throwIfNotFound: true);
        m_Crab_LeftLeg = m_Crab.FindAction("Left Leg", throwIfNotFound: true);
        m_Crab_RightLeg = m_Crab.FindAction("Right Leg", throwIfNotFound: true);
        m_Crab_Reset = m_Crab.FindAction("Reset", throwIfNotFound: true);
        m_Crab_Jump = m_Crab.FindAction("Jump", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Accept = m_UI.FindAction("Accept", throwIfNotFound: true);
        m_UI_Menu = m_UI.FindAction("Menu", throwIfNotFound: true);
        m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
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

    // Crab
    private readonly InputActionMap m_Crab;
    private ICrabActions m_CrabActionsCallbackInterface;
    private readonly InputAction m_Crab_ClickLeft;
    private readonly InputAction m_Crab_ClickRight;
    private readonly InputAction m_Crab_LeftLeg;
    private readonly InputAction m_Crab_RightLeg;
    private readonly InputAction m_Crab_Reset;
    private readonly InputAction m_Crab_Jump;
    public struct CrabActions
    {
        private @Controls m_Wrapper;
        public CrabActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickLeft => m_Wrapper.m_Crab_ClickLeft;
        public InputAction @ClickRight => m_Wrapper.m_Crab_ClickRight;
        public InputAction @LeftLeg => m_Wrapper.m_Crab_LeftLeg;
        public InputAction @RightLeg => m_Wrapper.m_Crab_RightLeg;
        public InputAction @Reset => m_Wrapper.m_Crab_Reset;
        public InputAction @Jump => m_Wrapper.m_Crab_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Crab; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CrabActions set) { return set.Get(); }
        public void SetCallbacks(ICrabActions instance)
        {
            if (m_Wrapper.m_CrabActionsCallbackInterface != null)
            {
                @ClickLeft.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickLeft;
                @ClickLeft.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickLeft;
                @ClickLeft.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickLeft;
                @ClickRight.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickRight;
                @ClickRight.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickRight;
                @ClickRight.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnClickRight;
                @LeftLeg.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnLeftLeg;
                @LeftLeg.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnLeftLeg;
                @LeftLeg.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnLeftLeg;
                @RightLeg.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnRightLeg;
                @RightLeg.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnRightLeg;
                @RightLeg.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnRightLeg;
                @Reset.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnReset;
                @Jump.started -= m_Wrapper.m_CrabActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CrabActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CrabActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_CrabActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickLeft.started += instance.OnClickLeft;
                @ClickLeft.performed += instance.OnClickLeft;
                @ClickLeft.canceled += instance.OnClickLeft;
                @ClickRight.started += instance.OnClickRight;
                @ClickRight.performed += instance.OnClickRight;
                @ClickRight.canceled += instance.OnClickRight;
                @LeftLeg.started += instance.OnLeftLeg;
                @LeftLeg.performed += instance.OnLeftLeg;
                @LeftLeg.canceled += instance.OnLeftLeg;
                @RightLeg.started += instance.OnRightLeg;
                @RightLeg.performed += instance.OnRightLeg;
                @RightLeg.canceled += instance.OnRightLeg;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public CrabActions @Crab => new CrabActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Accept;
    private readonly InputAction m_UI_Menu;
    private readonly InputAction m_UI_Move;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_UI_Accept;
        public InputAction @Menu => m_Wrapper.m_UI_Menu;
        public InputAction @Move => m_Wrapper.m_UI_Move;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Accept.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                @Menu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMenu;
                @Move.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface ICrabActions
    {
        void OnClickLeft(InputAction.CallbackContext context);
        void OnClickRight(InputAction.CallbackContext context);
        void OnLeftLeg(InputAction.CallbackContext context);
        void OnRightLeg(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnAccept(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
