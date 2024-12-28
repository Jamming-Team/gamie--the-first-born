using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class MM_HowToPlayView : ViewBase
    {
        private Button m_backButton;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_backButton = m_view.Query<Button>(GameConstants.Views.BACK_BUTTON);

            m_backButton.clicked += M_backButtonOnclicked; 
        }

        protected void OnDisable()
        {
            m_backButton.clicked -= M_backButtonOnclicked; 
        }
        
        private void M_backButtonOnclicked()
        {
            GameEventsView.OnPressBack?.Invoke();
        }
        
    }
}