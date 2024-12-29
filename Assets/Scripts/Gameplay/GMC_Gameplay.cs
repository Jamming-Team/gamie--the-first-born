using System;
using UnityEngine;

namespace TheGame
{
    public class GMC_Gameplay : GameModeControllerBase
    {
        [SerializeField]
        protected DragNDropHandler m_dragNDropHandler;

        [SerializeField] private float m_gameTimer = 60f;
        [SerializeField] private float m_timeLeft = -1f;
        [SerializeField] private float m_timeLeftNormalized = -1f;
        public float timeLeft => m_timeLeft;
        
        // public override void Initialize(GameInputController inputManager)
        // {
        //     base.Initialize(inputManager);
        //     m_dragNDropHandler.Initialize(inputManager);
        // }

        private void Update()
        {
            if (m_timeLeft != 1f && m_timeLeft > 0f)
            {
                m_timeLeft -= Time.deltaTime;
                m_timeLeftNormalized = m_timeLeft / m_gameTimer;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            m_dragNDropHandler.Init();
        }

        public void StartTimer()
        {
            m_timeLeft = m_gameTimer;
        }
        
        
        
    }
}
