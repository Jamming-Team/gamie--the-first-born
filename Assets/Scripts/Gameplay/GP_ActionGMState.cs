using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TheGame
{
    public class GP_ActionGMState : GameModeStateBase
    {
        [SerializeField]
        private BoxController m_BoxController;
        
        protected override void OnEnter()
        {
            base.OnEnter();
            GameController.Instance.InputController.OnPause += InputControllerOnOnPause;
            GameEventsView.OnPressPause += OnPressPause;
            GameEventsView.OnPressSendBox += OnPressSendBox;

            // GameController.Instance.InputController.OnSendBox += (sender, args) =>
            // {
            //     ((GMC_Gameplay)m_core).IncreaseScore(10);
            // };
            
            ((GMC_Gameplay)m_core).OnTimerOut += OnTimerOut;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameController.Instance.InputController.OnPause -= InputControllerOnOnPause;
            ((GMC_Gameplay)m_core).OnTimerOut -= OnTimerOut;
            GameEventsView.OnPressPause -= OnPressPause;
            ((GMC_Gameplay)m_core).StopGame();
        }
        
        private void InputControllerOnOnPause(object sender, EventArgs e)
        {
            RequestTransition<GP_PauseGMState>();
        }
        
        private void OnTimerOut()
        {
            RequestTransition<GP_PostGameGMState>();
        }
        
        private void OnPressPause()
        {
            RequestTransition<GP_PauseGMState>();
        }
        
        private void OnPressSendBox()
        {
            m_BoxController.InputControllerOnOnSendBox(this, null);
        }
    }
}
