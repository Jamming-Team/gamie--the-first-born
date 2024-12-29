using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TheGame
{
    public class GP_ActionGMState : GameModeStateBase
    {
        public float remainingTimeRefined
        {
            get
            {
                return ((GMC_Gameplay)m_core).timeLeft;
            }
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameController.Instance.InputController.OnPause += InputControllerOnOnPause;
        }

        protected override void OnExit()
        {
            base.OnExit();
            GameController.Instance.InputController.OnPause -= InputControllerOnOnPause;
        }
        
        private void InputControllerOnOnPause(object sender, EventArgs e)
        {
            RequestTransition<GP_PauseGMState>();
        }
    }
}
