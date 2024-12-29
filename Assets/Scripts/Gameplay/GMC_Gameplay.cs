using System;
using System.Collections.Generic;
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
        [SerializeField] private BoxController m_boxController;
        [SerializeField] private PresentGenerator m_presentGenerator;
        
        private float m_totalPoints = 0;
        public float totalPoints => m_totalPoints;
        
        
        
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
            m_boxController.OnCalculateBoxScore += OnCalculateBoxScore;
        }

        private void OnCalculateBoxScore(List<Present> arg1, bool arg2)
        {
            float final_box_score = 0f;
            arg1.ForEach(x =>
            {
                Debug.Log(x);
                final_box_score += x.presentValue;
            });
            final_box_score *= .5f * arg1.Count * (arg2 ? .5f : 1f);
            IncreaseScore(Mathf.Floor(final_box_score));
        }

        public void StartGame()
        {
            m_totalPoints = 0;
            StartTimer();
            m_boxController.PrepareBox();
            m_presentGenerator.StartGeneration();
        }

        public void StopGame()
        {
            Debug.Log("Stop Game");
            if (m_timeLeft != -1f && m_timeLeft <= 0f)
            {
                m_presentGenerator.StopGeneration();
                m_boxController.SendBox(overlapped: false, shouldReturn: false);
            }
        }

        public void StartTimer()
        {
            m_timeLeft = m_gameTimer;
        }
        
        public void IncreaseScore(float points)
        {
            m_totalPoints += points;
            GameEventsView.OnScoreChanged?.Invoke(m_totalPoints);
        }
    }
}
