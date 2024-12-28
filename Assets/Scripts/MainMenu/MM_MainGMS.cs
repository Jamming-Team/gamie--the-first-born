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
            GameEventsView.OnPressQuitGame += () =>
            {
                GameController.Instance.QuitGame();
            };
        }

        public void OnDestroy()
        {
            GameEventsView.OnPressHowToPlay -= RequestTransition<MM_HowToPlayGMS>;
            GameEventsView.OnPressQuitGame -= () =>
            {
                GameController.Instance.QuitGame();
            };
        }
    }
}