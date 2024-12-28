using System;
using UnityEngine;

namespace TheGame
{
    public class GP_CountdownGMState : GameModeStateBase
    {
        [SerializeField]
        private int m_countdownTime = 3;
        
        private float m_timeLeft;
        private int m_timeLeftSeconds;
        
        protected override void OnEnter()
        {
            base.OnEnter();
            m_timeLeft = m_countdownTime;
            m_timeLeftSeconds= m_countdownTime;
            UpdateCountdown();
        }

        private void Update()
        {
            if (m_timeLeft > 0.1f)
            {
                m_timeLeft -= Time.deltaTime;
                if (m_timeLeft <= m_timeLeftSeconds - 1)
                {
                    m_timeLeftSeconds -= 1;
                    UpdateCountdown();
                }
            }
            else
            {
                RequestTransition<GP_ActionGMState>();
            }
        }

        private void UpdateCountdown()
        {
            GameEventsView.OnTimerChanged?.Invoke(m_timeLeftSeconds);
        }

    }
}
