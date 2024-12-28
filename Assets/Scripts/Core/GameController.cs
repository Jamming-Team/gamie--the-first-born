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
        }

        private void Update()
        {
            Debug.Log(m_inputController.mouseWorldPosition);
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
            m_inputController.SetCamera(gameModeController.m_camera);
            gameModeController.Initialize();
        }
        
    }
}