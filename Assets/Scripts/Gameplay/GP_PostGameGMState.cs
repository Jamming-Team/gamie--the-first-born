using UnityEngine;

namespace TheGame
{
    public class GP_PostGameGMState : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            ((GMC_Gameplay)m_core).IncreaseScore(0);
            
            GameEventsView.OnPressRestartGame += OnPressRestart;
            GameEventsView.OnPressToMainMenu += OnPressToMainMenu;
        }
        
        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressRestartGame -= OnPressRestart;
            GameEventsView.OnPressToMainMenu -= OnPressToMainMenu;
        }
        
        private void OnPressRestart()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.GAMEPLAY);
        }
        
        private void OnPressToMainMenu()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.MAIN_MENU);
        }
    }
}
