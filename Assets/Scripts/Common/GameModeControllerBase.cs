using UnityEngine;

namespace TheGame
{
    public abstract class GameModeControllerBase : MonoBehaviour
    {
        public static GameModeControllerBase Instance { get; private set; }
        
        [SerializeField]
        protected StateMachine m_stateMachine;
        public StateBase currentState => m_stateMachine.currentState;
        
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
            
#if UNITY_EDITOR
            if (GameController.Instance == null)
            {
                var assets = UnityEditor.AssetDatabase.FindAssets("GameController");
                foreach (var guid in assets)
                {
                    var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                    var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (prefab)
                    {
                        Instantiate(prefab);
                        break;
                    }
                }
            }
#endif
        }

        public virtual void Initialize()
        {
            m_stateMachine.Init(this);
            // m_gameInputManager = inputManager;
        }
        
    }
}