using UnityEngine;

namespace TheGame
{
    public class MM_HowToPlayDetailsGMS : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEventsView.OnPressHowToPlayNext += RequestTransition<MM_HowToPlayGMS>;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressHowToPlayNext -= RequestTransition<MM_HowToPlayGMS>;
        }
    }
}
