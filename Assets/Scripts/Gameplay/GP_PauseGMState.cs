using System;
using UnityEngine;

namespace TheGame
{
    public class GP_PauseGMState : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEventsView.OnPressResume += OnPressResume;
            GameEventsView.OnPressRestartGame += OnPressRestart;
            GameEventsView.OnPressToMainMenu += OnPressToMainMenu;
            GameController.Instance.InputController.OnPause += InputControllerOnOnPause;
            GameController.Instance.SetGameTimeScale(0f);
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressResume -= OnPressResume;
            GameEventsView.OnPressRestartGame -= OnPressRestart;
            GameEventsView.OnPressToMainMenu -= OnPressToMainMenu;
            GameController.Instance.InputController.OnPause -= InputControllerOnOnPause;
            GameController.Instance.SetGameTimeScale(1f);
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
        
        private void InputControllerOnOnPause(object sender, EventArgs e)
        {
            RequestTransition<GP_ActionGMState>();
        }
    }
}
