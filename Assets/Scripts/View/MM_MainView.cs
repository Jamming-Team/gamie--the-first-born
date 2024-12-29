using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class MM_MainView : ViewBase
    {
        private Button m_playButton;
        private Button m_howToPlayButton;
        private Button m_creditsButton;


        protected override void OnEnable()
        {
            base.OnEnable();

            m_playButton = m_view.Query<Button>(GameConstants.Views.PLAY_BUTTON);
            m_howToPlayButton = m_view.Query<Button>(GameConstants.Views.HOW_TO_PLAY_BUTTON);
            m_creditsButton = m_view.Query<Button>(GameConstants.Views.CREDITS_BUTTON);
            
            m_playButton.clicked += M_playButtonOnclicked; 
            m_howToPlayButton.clicked += M_howToPlayButtonOnclicked;
            m_creditsButton.clicked += MCreditsButtonOnclicked;
        }
        
        private void OnDisable()
        {
            m_playButton.clicked -= M_playButtonOnclicked; 
            m_howToPlayButton.clicked -= M_howToPlayButtonOnclicked;
            m_creditsButton.clicked -= MCreditsButtonOnclicked;
        }

        private void M_playButtonOnclicked()
        {
            GameEventsView.OnPressPlay?.Invoke();
        }
        
        private void M_howToPlayButtonOnclicked()
        {
            // Debug.Log("CLicked");
            GameEventsView.OnPressHowToPlay?.Invoke();
        }
        
        private void MCreditsButtonOnclicked()
        {
            // Debug.Log("Credits clicked");
            GameEventsView.OnPressCredits?.Invoke();
        }
    }
}