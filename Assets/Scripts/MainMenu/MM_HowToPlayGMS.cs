using UnityEngine;

namespace TheGame
{
    public class MM_HowToPlayGMS : GameModeStateBase
    {
        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            GameEventsView.OnPressBack += RequestTransition<MM_MainGMS>;
        }
        
        public void OnDestroy()
        {
            GameEventsView.OnPressBack -= RequestTransition<MM_MainGMS>;
        }
    }
}