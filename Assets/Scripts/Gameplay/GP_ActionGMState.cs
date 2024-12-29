using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TheGame
{
    public class GP_ActionGMState : GameModeStateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            GameController.Instance.InputController.OnPause += InputControllerOnOnPause;

            GameController.Instance.InputController.OnSendBox += (sender, args) =>
            {
                ((GMC_Gameplay)m_core).IncreaseScore(10);
            };
            
            ((GMC_Gameplay)m_core).OnTimerOut += OnTimerOut;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameController.Instance.InputController.OnPause -= InputControllerOnOnPause;
            ((GMC_Gameplay)m_core).OnTimerOut -= OnTimerOut;
        }
        
        private void InputControllerOnOnPause(object sender, EventArgs e)
        {
            RequestTransition<GP_PauseGMState>();
        }
        
        private void OnTimerOut()
        {
            RequestTransition<GP_PostGameGMState>();
        }
    }
}
