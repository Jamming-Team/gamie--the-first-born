using UnityEngine;

namespace TheGame
{
    public class MM_CreditsGMS : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameEventsView.OnPressBack += RequestTransition<MM_MainGMS>;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameEventsView.OnPressBack -= RequestTransition<MM_MainGMS>;
        }
    }
}
