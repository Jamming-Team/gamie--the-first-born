using UnityEngine;

namespace TheGame
{
    public class GP_PauseGMState : GameModeStateBase
    {
        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            GameEventsView.OnPressResume += OnPressResume;
            GameEventsView.OnPressRestartGame += OnPressRestart;
            GameEventsView.OnPressToMainMenu += OnPressToMainMenu;
        }

        private void OnDestroy()
        {
            GameEventsView.OnPressResume -= OnPressResume;
            GameEventsView.OnPressRestartGame -= OnPressRestart;
            GameEventsView.OnPressToMainMenu -= OnPressToMainMenu;
        }
        
        private void OnPressResume()
        {
            RequestTransition<GP_ActionGMState>();
        }
        
        private void OnPressRestart()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.GAMEPLAY);
        }
        
        private void OnPressToMainMenu()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.MAIN_MENU);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameController.Instance.SetGameTimeScale(0f);
        }
        
        protected override void OnExit()
        {
            base.OnExit();
            GameController.Instance.SetGameTimeScale(1f);
        }
    }
}
