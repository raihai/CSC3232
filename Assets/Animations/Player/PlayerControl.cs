// GENERATED AUTOMATICALLY FROM 'Assets/Animations/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""38661fdb-add0-45f1-b7d6-c0e702983005"",
            ""actions"": [
                {
                    ""name"": ""Moves"",
                    ""type"": ""Value"",
                    ""id"": ""79b4af4f-c469-4039-8d88-3d011c6e3487"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""489137d2-3947-4dc7-ad30-8b1433b09f89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f34c3c75-0de2-49fd-bcad-8458c4ca1b34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack "",
                    ""type"": ""Button"",
                    ""id"": ""a350e7fc-a063-4bb8-b8e7-ae1264555f5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b04445ed-3fff-4b50-b65b-635c3722dd39"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""bf6fc37d-aa91-4bb2-8955-58c7fc47c03b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Collect"",
                    ""type"": ""Button"",
                    ""id"": ""4206ad05-ee5a-4410-aead-8c37b2944b74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cac131ac-2759-4e38-bd1b-ce72e2e164a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3560866-e507-4d0a-af20-61c920e1af9c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ae7d6805-4ed9-4b5b-92a2-d4d31c1b8614"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19cbf83d-1ca8-4f5d-b010-a3a146323c0f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a02f5d60-2083-425c-9bed-14621dcd8680"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4a7f220e-8acc-4d20-a0bb-90a370c00735"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaba1647-4b7f-40f6-9b8a-90db12b02a78"",
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
                    ""id"": ""c1c9649a-0a68-4769-ab7d-2a2ad2c59a30"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e6cea40-ab57-4e99-8a41-e944501ad0d4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c2e285c-34c7-4c98-a189-0415e1b7cdd3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90f74e9f-5e20-41e0-b4b8-a07d489af205"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""OverworldControls"",
            ""id"": ""0606ba84-58c1-4236-a9ef-13c76f90ce6b"",
            ""actions"": [
                {
                    ""name"": ""Moves"",
                    ""type"": ""Value"",
                    ""id"": ""cd70525b-d40f-49a0-af38-a5f543f522e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d7e036d2-20ab-4274-86fa-2ba71e19a560"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5bb50776-b739-49e5-b446-a98cfdf7ab3e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""463c75a1-e142-4154-a7f2-7642620ca45a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10f89913-4990-491a-9aca-5be169112a0a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9ea29b69-90a3-4da5-a781-08b75a65b41a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Moves = m_CharacterControls.FindAction("Moves", throwIfNotFound: true);
        m_CharacterControls_Run = m_CharacterControls.FindAction("Run", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_Attack = m_CharacterControls.FindAction("Attack ", throwIfNotFound: true);
        m_CharacterControls_MouseLook = m_CharacterControls.FindAction("MouseLook", throwIfNotFound: true);
        m_CharacterControls_Special = m_CharacterControls.FindAction("Special", throwIfNotFound: true);
        m_CharacterControls_Collect = m_CharacterControls.FindAction("Collect", throwIfNotFound: true);
        // OverworldControls
        m_OverworldControls = asset.FindActionMap("OverworldControls", throwIfNotFound: true);
        m_OverworldControls_Moves = m_OverworldControls.FindAction("Moves", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Moves;
    private readonly InputAction m_CharacterControls_Run;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_Attack;
    private readonly InputAction m_CharacterControls_MouseLook;
    private readonly InputAction m_CharacterControls_Special;
    private readonly InputAction m_CharacterControls_Collect;
    public struct CharacterControlsActions
    {
        private @PlayerControl m_Wrapper;
        public CharacterControlsActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moves => m_Wrapper.m_CharacterControls_Moves;
        public InputAction @Run => m_Wrapper.m_CharacterControls_Run;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @Attack => m_Wrapper.m_CharacterControls_Attack;
        public InputAction @MouseLook => m_Wrapper.m_CharacterControls_MouseLook;
        public InputAction @Special => m_Wrapper.m_CharacterControls_Special;
        public InputAction @Collect => m_Wrapper.m_CharacterControls_Collect;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Moves.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoves;
                @Moves.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoves;
                @Moves.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoves;
                @Run.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                @MouseLook.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMouseLook;
                @Special.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSpecial;
                @Collect.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCollect;
                @Collect.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCollect;
                @Collect.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCollect;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moves.started += instance.OnMoves;
                @Moves.performed += instance.OnMoves;
                @Moves.canceled += instance.OnMoves;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
                @Collect.started += instance.OnCollect;
                @Collect.performed += instance.OnCollect;
                @Collect.canceled += instance.OnCollect;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

    // OverworldControls
    private readonly InputActionMap m_OverworldControls;
    private IOverworldControlsActions m_OverworldControlsActionsCallbackInterface;
    private readonly InputAction m_OverworldControls_Moves;
    public struct OverworldControlsActions
    {
        private @PlayerControl m_Wrapper;
        public OverworldControlsActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moves => m_Wrapper.m_OverworldControls_Moves;
        public InputActionMap Get() { return m_Wrapper.m_OverworldControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OverworldControlsActions set) { return set.Get(); }
        public void SetCallbacks(IOverworldControlsActions instance)
        {
            if (m_Wrapper.m_OverworldControlsActionsCallbackInterface != null)
            {
                @Moves.started -= m_Wrapper.m_OverworldControlsActionsCallbackInterface.OnMoves;
                @Moves.performed -= m_Wrapper.m_OverworldControlsActionsCallbackInterface.OnMoves;
                @Moves.canceled -= m_Wrapper.m_OverworldControlsActionsCallbackInterface.OnMoves;
            }
            m_Wrapper.m_OverworldControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moves.started += instance.OnMoves;
                @Moves.performed += instance.OnMoves;
                @Moves.canceled += instance.OnMoves;
            }
        }
    }
    public OverworldControlsActions @OverworldControls => new OverworldControlsActions(this);
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    public interface ICharacterControlsActions
    {
        void OnMoves(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnCollect(InputAction.CallbackContext context);
    }
    public interface IOverworldControlsActions
    {
        void OnMoves(InputAction.CallbackContext context);
    }
}
