using UnityEngine;

namespace TheGame
{
    public class MM_OptionsGMS : GameModeStateBase
    {
        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            GameEventsView.OnPressBack += RequestTransition<MM_MainGMS>;
        }
    }
}