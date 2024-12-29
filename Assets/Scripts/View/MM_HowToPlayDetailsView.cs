using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class MM_HowToPlayDetailsView : ViewBase
    {
        private Button m_howToPlayNextButton;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_howToPlayNextButton = m_view.Query<Button>(GameConstants.Views.HOW_TO_PLAY_NEXT_BUTTON);

            m_howToPlayNextButton.clicked += M_howToPlayNextButtonOnclicked;
        }

        protected void OnDisable()
        {
            m_howToPlayNextButton.clicked -= M_howToPlayNextButtonOnclicked;
        }

        private void M_howToPlayNextButtonOnclicked()
        {
            GameEventsView.OnPressHowToPlayNext?.Invoke();
        }
    }
}
