using System;
using UnityEngine;

namespace TheGame
{
    public class MM_MainGMS : GameModeStateBase
    {
        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            GameEventsView.OnPressHowToPlay += RequestTransition<MM_HowToPlayGMS>;
            GameEventsView.OnPressPlay += OnPressPlay;
            GameEventsView.OnPressQuitGame += OnPressQuitGame;
        }

        private void OnDestroy()
        {
            GameEventsView.OnPressHowToPlay -= RequestTransition<MM_HowToPlayGMS>;
            GameEventsView.OnPressPlay -= OnPressPlay;
            GameEventsView.OnPressQuitGame -= OnPressQuitGame;
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