// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""f4e6ddda-407e-4e64-9002-5797749f19cd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""92ed4008-a18b-4355-a50a-bb2c3c05afbb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeMusic"",
                    ""type"": ""Button"",
                    ""id"": ""58e96dc5-b6c1-4a00-bc3b-a5825f8db218"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SkipScene"",
                    ""type"": ""Button"",
                    ""id"": ""0e6d20a6-1838-4ff6-8903-10fa3785db9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b148ac95-b133-4d23-ba07-1e75bf3b567f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8f406750-8e98-4c87-97eb-e7414478ceeb"",
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
                    ""id"": ""f6b9edc2-f565-4303-98ca-bdf99b662b81"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""InputActions"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""56f8fb55-43ca-4af8-ba80-aeeedc596856"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""InputActions"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3e2d3e9-e8c2-4b4a-b066-4272e1585ff4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""InputActions"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee4843d0-0a8c-4b81-8c9c-7313bcec85d5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""InputActions"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0b9ea169-3ff9-4275-ba5d-143f9bf6b8a7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""180348f7-d63d-4dd4-98f7-5fff43677631"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""InputActions"",
            ""bindingGroup"": ""InputActions"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_ChangeMusic = m_Movement.FindAction("ChangeMusic", throwIfNotFound: true);
        m_Movement_SkipScene = m_Movement.FindAction("SkipScene", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_ChangeMusic;
    private readonly InputAction m_Movement_SkipScene;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @ChangeMusic => m_Wrapper.m_Movement_ChangeMusic;
        public InputAction @SkipScene => m_Wrapper.m_Movement_SkipScene;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @ChangeMusic.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnChangeMusic;
                @ChangeMusic.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnChangeMusic;
                @ChangeMusic.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnChangeMusic;
                @SkipScene.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSkipScene;
                @SkipScene.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSkipScene;
                @SkipScene.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSkipScene;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ChangeMusic.started += instance.OnChangeMusic;
                @ChangeMusic.performed += instance.OnChangeMusic;
                @ChangeMusic.canceled += instance.OnChangeMusic;
                @SkipScene.started += instance.OnSkipScene;
                @SkipScene.performed += instance.OnSkipScene;
                @SkipScene.canceled += instance.OnSkipScene;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_InputActionsSchemeIndex = -1;
    public InputControlScheme InputActionsScheme
    {
        get
        {
            if (m_InputActionsSchemeIndex == -1) m_InputActionsSchemeIndex = asset.FindControlSchemeIndex("InputActions");
            return asset.controlSchemes[m_InputActionsSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnChangeMusic(InputAction.CallbackContext context);
        void OnSkipScene(InputAction.CallbackContext context);
    }
}
