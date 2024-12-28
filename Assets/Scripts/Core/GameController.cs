using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        [SerializeField] private GameInputController m_inputController;
        public GameInputController InputController => m_inputController;
        
        private Camera m_currentCamera;
        public Camera currentCamera => m_currentCamera;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("instance not null");
                Destroy(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (GameModeControllerBase.Instance != null)
            {
                SceneSetup();
            }
            
            m_inputController.Init();
        }

        private void Update()
        {
            // Debug.Log(m_inputController.mouseWorldPosition);
        }

        public void SetGameTimeScale(float scale)
        {
            Time.timeScale = scale;
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
        
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(GameConstants.SceneNames.EMPTY);
            System.GC.Collect();
            Resources.UnloadUnusedAssets();
            
            yield return SceneManager.LoadSceneAsync(sceneName);

            SceneSetup();
        }

        public void SceneSetup()
        {
            var gameModeController = GameModeControllerBase.Instance;
            m_currentCamera = gameModeController.m_camera;
            gameModeController.Initialize();
        }
        
        
    }
}