using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame
{
    public class GameInputController : MonoBehaviour
    {
        public static GameInputController Instance { get; set; }
        
        [SerializeField] private PlayerInput m_playerInput;
        [HideInInspector]
        public Camera m_camera;
        
        private Vector3 m_mouseWorldPosition;
        public Vector3 mouseWorldPosition => m_mouseWorldPosition;
        private ActorInputManager m_player;
        public ActorInputManager player => m_player;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("instance not null");
                Destroy(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            m_player = new ActorInputManager("Player", m_playerInput.actions);
        }

        void Update()
        {
            UpdateMouseWorldPosition();
        }

        public void SetCamera(Camera camera)
        {
            m_camera = camera;
        }

        private void UpdateMouseWorldPosition()
        {
            if (!m_camera)
                return;
            
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 1000))
            {
                m_mouseWorldPosition = hitData.point;
            }
        }


        public class ActorInputManager
        {
            public event EventHandler OnInteractAction;
            public event EventHandler OnJumpAction;

            private InputActionMap m_inputActionMap;

            private InputAction m_moveAction;
            private InputAction m_interactAction;
            private InputAction m_jumpAction;

            public ActorInputManager(string mapName, InputActionAsset inputActionAsset)
            {
                m_inputActionMap = inputActionAsset.FindActionMap(mapName);
                m_moveAction = m_inputActionMap.FindAction(GameConstants.Input.Main.MOVE);
                m_interactAction = m_inputActionMap.FindAction(GameConstants.Input.Main.INTERACT);
                m_jumpAction = m_inputActionMap.FindAction(GameConstants.Input.Main.JUMP);

                Enable();
            }
            
            public void Enable()
            {
                m_interactAction.started += M_interactActionOnstarted;
                m_jumpAction.started += M_jumpActionOnstarted;
            }
            
            public void Disable()
            {
                m_interactAction.started -= M_interactActionOnstarted;
                m_jumpAction.started -= M_jumpActionOnstarted;
            }
            
            public Vector2 GetMovementVectorNormalized()
            {
                Vector2 inputVector = m_moveAction.ReadValue<Vector2>();
                inputVector = inputVector.normalized;
                return inputVector;
            }

            private void M_jumpActionOnstarted(InputAction.CallbackContext obj)
            {
                OnJumpAction?.Invoke(this, EventArgs.Empty);
            }

            private void M_interactActionOnstarted(InputAction.CallbackContext obj)
            {
                OnInteractAction?.Invoke(this, EventArgs.Empty);
            }
            
        }
        


    }
}
