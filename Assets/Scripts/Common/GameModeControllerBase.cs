using UnityEngine;

namespace TheGame
{
    public abstract class GameModeControllerBase : MonoBehaviour
    {
        public static GameModeControllerBase Instance { get; private set; }
        
        [SerializeField]
        protected StateMachine m_stateMachine;
        
        [SerializeField] 
        public Camera m_camera;
        
        [SerializeField]
        public GameInputController m_gameInputManager;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("instance not null");
                Destroy(gameObject);
            }
            Instance = this;
        }

        public virtual void Initialize(GameInputController inputManager)
        {
            m_stateMachine.Init(this);
            m_gameInputManager = inputManager;
        }
        
    }
}