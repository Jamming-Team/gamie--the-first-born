using UnityEngine;

namespace TheGame
{
    public class MM_HowToPlayGMS : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEventsView.OnPressBack += RequestTransition<MM_MainGMS>;
            GameEventsView.OnPressHowToPlayNext += RequestTransition<MM_HowToPlayDetailsGMS>;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressBack -= RequestTransition<MM_MainGMS>;
            GameEventsView.OnPressHowToPlayNext -= RequestTransition<MM_HowToPlayDetailsGMS>;
        }
    }
}