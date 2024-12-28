using UnityEngine;

namespace TheGame
{
    public class MM_MainGMS : GameModeStateBase
    {

        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            GameEventsView.OnPressOptions += RequestTransition<MM_OptionsGMS>;
            GameEventsView.OnPressQuitGame += () =>
            {
                GameController.Instance.QuitGame();
            };
        }
        
    }
}