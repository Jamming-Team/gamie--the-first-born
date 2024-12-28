using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame
{
    public class GameInputController : MonoBehaviour
    {
        public event EventHandler<bool> OnLMC;
        public event EventHandler<bool> OnRMC;
        public event EventHandler OnSendBox;
        public event EventHandler OnPause;

        public static GameInputController Instance { get; set; }
        
        [SerializeField] private PlayerInput m_playerInput;
        [SerializeField] private float m_scrollWheelSpeed = 10f;
        
        private InputActionMap m_inputActionMap;

        private InputAction m_LMCAction;
        private InputAction m_RMCAction;
        private InputAction m_sendBoxAction;
        private InputAction m_pauseAction;
        
        // private Vector3 m_mouseWorldPosition;
        public Vector3 mouseWorldPosition => GetMouseWorldPosition();
        public float mouseWheelScroll => GetMouseWheel();

        // private void Awake()
        // {
        //     if (Instance != null)
        //     {
        //         Debug.LogWarning("instance not null");
        //         Destroy(gameObject);
        //     }
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        //
        //     m_inputActionMap = m_playerInput.actions.FindActionMap("DragNDrop");
        //     m_LMCAction = m_inputActionMap.FindAction(GameConstants.Input.Main.RMC);
        //     m_RMCAction = m_inputActionMap.FindAction(GameConstants.Input.Main.LMC);
        //     m_sendBoxAction = m_inputActionMap.FindAction(GameConstants.Input.Main.SEND_BOX);
        //
        //     Enable();
        // }

        public void Init()
        {
            if (Instance != null)
            {
                Debug.LogWarning("instance not null");
                Destroy(gameObject);
            }
            Instance = this;
            // DontDestroyOnLoad(gameObject);
            
            m_inputActionMap = m_playerInput.actions.FindActionMap("DragNDrop");
            m_LMCAction = m_inputActionMap.FindAction(GameConstants.Input.Main.RMC);
            m_RMCAction = m_inputActionMap.FindAction(GameConstants.Input.Main.LMC);
            m_sendBoxAction = m_inputActionMap.FindAction(GameConstants.Input.Main.SEND_BOX);
            m_pauseAction = m_inputActionMap.FindAction(GameConstants.Input.Main.PAUSE);

            Enable();
        }

        public void Enable()
        {
            // Debug.Log($"Enable");

            m_LMCAction.started += M_LMCActionOnstarted;
            m_RMCAction.started += M_RMCActionOnstarted;
            m_LMCAction.canceled += M_LMCActionOncanceled;
            m_RMCAction.canceled += M_RMCActionOncanceled;
            m_sendBoxAction.started += M_sendBoxActionOnstarted;
            m_pauseAction.started += M_pauseActionOnstarted;
        }

        public void Disable()
        {
            m_LMCAction.started -= M_LMCActionOnstarted;
            m_RMCAction.started -= M_RMCActionOnstarted;
            m_LMCAction.canceled -= M_LMCActionOncanceled;
            m_RMCAction.canceled -= M_RMCActionOncanceled;
            m_sendBoxAction.started -= M_sendBoxActionOnstarted;
            m_pauseAction.started -= M_pauseActionOnstarted;
        }

        private void M_LMCActionOnstarted(InputAction.CallbackContext obj)
        {
            OnLMC?.Invoke(this, true);
        }

        private void M_RMCActionOnstarted(InputAction.CallbackContext obj)
        {
            OnRMC?.Invoke(this, true);
        }

        private void M_RMCActionOncanceled(InputAction.CallbackContext obj)
        {
            OnRMC?.Invoke(this, false);
        }

        private void M_LMCActionOncanceled(InputAction.CallbackContext obj)
        {
            OnLMC?.Invoke(this, false);
        }

        private void M_sendBoxActionOnstarted(InputAction.CallbackContext obj)
        {
            OnSendBox?.Invoke(this, EventArgs.Empty);
        }
        
        private void M_pauseActionOnstarted(InputAction.CallbackContext obj)
        {
            OnPause?.Invoke(this, EventArgs.Empty);
        }

        void Update()
        {
            // UpdateMouseWorldPosition();
        }

        private Vector3 GetMouseWorldPosition()
        {
            var camera = GameController.Instance.currentCamera;
            if (!camera)
                return Vector3.zero;
            
            var mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = camera.WorldToScreenPoint(mouseScreenPosition).z;
            return camera.ScreenToWorldPoint(mouseScreenPosition);
            // Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            // RaycastHit hitData;
            // if (Physics.Raycast(ray, out hitData, 1000))
            // {
            //     m_mouseWorldPosition = hitData.point;
            // }
        }

        private float GetMouseWheel()
        {
            return Input.GetAxis("Mouse ScrollWheel") * m_scrollWheelSpeed;
        }

    }
}
