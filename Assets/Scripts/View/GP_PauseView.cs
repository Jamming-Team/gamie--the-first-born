using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class GP_PauseView : ViewBase
    {
        private Button m_resumeButton;
        private Button m_restartButton;
        private Button m_toMainMenuButton;


        protected override void OnEnable()
        {
            base.OnEnable();

            m_resumeButton = m_view.Query<Button>(GameConstants.Views.RESUME_BUTTON);
            m_restartButton = m_view.Query<Button>(GameConstants.Views.RESTART_BUTTON);
            m_toMainMenuButton = m_view.Query<Button>(GameConstants.Views.TO_MAIN_MENU_BUTTON);
            
            m_resumeButton.clicked += MResumeButtonOnclicked; 
            m_restartButton.clicked += MRestartButtonOnclicked;
            m_toMainMenuButton.clicked += MToMainMenuButtonOnclicked;
        }
        
        private void OnDisable()
        {
            m_resumeButton.clicked -= MResumeButtonOnclicked; 
            m_restartButton.clicked -= MRestartButtonOnclicked;
            m_toMainMenuButton.clicked -= MToMainMenuButtonOnclicked;
        }

        private void MResumeButtonOnclicked()
        {
            GameEventsView.OnPressResume?.Invoke();
        }
        
        private void MRestartButtonOnclicked()
        {
            GameEventsView.OnPressRestartGame?.Invoke();
        }
        
        private void MToMainMenuButtonOnclicked()
        {
            GameEventsView.OnPressToMainMenu?.Invoke();
        }
    }
}
