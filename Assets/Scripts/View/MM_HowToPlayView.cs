using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class MM_HowToPlayView : ViewBase
    {
        private Button m_backButton;
        private Button m_howToPlayNextButton;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_backButton = m_view.Query<Button>(GameConstants.Views.BACK_BUTTON);
            m_howToPlayNextButton = m_view.Query<Button>(GameConstants.Views.HOW_TO_PLAY_NEXT_BUTTON);

            m_backButton.clicked += M_backButtonOnclicked; 
            m_howToPlayNextButton.clicked += M_howToPlayNextButtonOnclicked;
        }

        protected void OnDisable()
        {
            m_backButton.clicked -= M_backButtonOnclicked; 
            m_howToPlayNextButton.clicked -= M_howToPlayNextButtonOnclicked;
        }
        
        private void M_backButtonOnclicked()
        {
            GameEventsView.OnPressBack?.Invoke();
        }
        
        private void M_howToPlayNextButtonOnclicked()
        {
            GameEventsView.OnPressHowToPlayNext?.Invoke();
        }
        
    }
}