using System;
using UnityEngine;

namespace TheGame
{
    public class MM_MainGMS : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEventsView.OnPressHowToPlay += RequestTransition<MM_HowToPlayGMS>;
            GameEventsView.OnPressPlay += OnPressPlay;
            GameEventsView.OnPressQuitGame += OnPressQuitGame;
            GameEventsView.OnPressCredits += OnPressCredits;
        }

        private void OnPressCredits()
        {
            // Debug.Log("OnPressCredits");
            RequestTransition<MM_CreditsGMS>();
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressHowToPlay -= RequestTransition<MM_HowToPlayGMS>;
            GameEventsView.OnPressPlay -= OnPressPlay;
            GameEventsView.OnPressQuitGame -= OnPressQuitGame;
            GameEventsView.OnPressCredits -= RequestTransition<MM_CreditsGMS>;
        }
        
        private void OnPressPlay()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.GAMEPLAY);
        }
        
        private void OnPressQuitGame()
        {
            GameController.Instance.QuitGame();
        }
    }
}