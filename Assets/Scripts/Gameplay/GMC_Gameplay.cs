using System;
using UnityEngine;

namespace TheGame
{
    public class GMC_Gameplay : GameModeControllerBase
    {
        public Action OnTimerOut;
        
        [SerializeField]
        protected DragNDropHandler m_dragNDropHandler;

        [SerializeField] private float m_gameTimer = 60f;
        [SerializeField] private float m_timeLeft = -1f;
        [SerializeField] private float m_timeLeftNormalized = -1f;
        private int m_totalPoints = 0;
        public int totalPoints => m_totalPoints;
        
        // public override void Initialize(GameInputController inputManager)
        // {
        //     base.Initialize(inputManager);
        //     m_dragNDropHandler.Initialize(inputManager);
        // }

        private void Update()
        {
            if (m_timeLeft > 0f)
            {
                m_timeLeft -= Time.deltaTime;
                m_timeLeftNormalized = m_timeLeft / m_gameTimer;
            }
            else
            {
                if (m_stateMachine.currentState.GetType() == typeof(GP_ActionGMState))
                {
                    OnTimerOut?.Invoke();
                    // IncreaseScore(0);
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            m_dragNDropHandler.Init();
        }

        public void StartGame()
        {
            m_totalPoints = 0;
            StartTimer();
        }

        public void StartTimer()
        {
            m_timeLeft = m_gameTimer;
        }
        
        public void IncreaseScore(int points)
        {
            m_totalPoints += points;
            GameEventsView.OnScoreChanged?.Invoke(m_totalPoints);
        }
    }
}
