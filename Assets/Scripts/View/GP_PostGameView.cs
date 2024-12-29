using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class GP_PostGameView : ViewBase
    {
        private Label m_scoreLabel;
        private Button m_restartButton;
        private Button m_toMainMenuButton;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_scoreLabel = m_view.Query<Label>(GameConstants.Views.FINAL_SCORE_LABEL);
            GameEventsView.OnScoreChanged += OnScoreChanged;
            Debug.Log("Enabled");
            
            m_restartButton = m_view.Query<Button>(GameConstants.Views.RESTART_BUTTON);
            m_toMainMenuButton = m_view.Query<Button>(GameConstants.Views.TO_MAIN_MENU_BUTTON);
            
            m_restartButton.clicked += M_restartButtonOnclicked;
            m_toMainMenuButton.clicked += M_toMainMenuButtonOnclicked;
        }

        private void OnDisable()
        {
            GameEventsView.OnScoreChanged -= OnScoreChanged;
            
            m_restartButton.clicked -= M_restartButtonOnclicked;
            m_toMainMenuButton.clicked -= M_toMainMenuButtonOnclicked;
        }

        private void OnScoreChanged(int obj)
        {
            Debug.Log("OnScoreChanged");
            m_scoreLabel.text = obj.ToString();
        }
        
        private void M_restartButtonOnclicked()
        {
            GameEventsView.OnPressRestartGame?.Invoke();
        }
        
        private void M_toMainMenuButtonOnclicked()
        {
            GameEventsView.OnPressToMainMenu?.Invoke();
        }
    }
}
