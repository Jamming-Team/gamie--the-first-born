using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private  List<StateBase> m_states = new();
        private StateBase m_currentState;
        public StateBase currentState => m_currentState;
        
        
        // protected StateMachine()
        // {
        //     GetComponentsInChildren(m_states);
        //     m_states.ForEach(x =>
        //     {
        //         x.Init(this);
        //         x.OnTransitionRequired += ChangeState;
        //     });
        // }

        public void Init(MonoBehaviour core)
        {
            GetComponentsInChildren(m_states);
            m_states.ForEach(x =>
            {
                x.Init(core);
                x.OnTransitionRequired += ChangeState;
                // Debug.Log(x.GetType());
            });
            // m_currentState = m_states[0];
            ChangeState(m_states[0].GetType());
        }

        public void OnDestroy()
        {
            m_states.ForEach(x =>
            {
                x.OnTransitionRequired -= ChangeState;
            });
        }

        public void ChangeState(System.Type nextStateType)
        {
            var nextState = m_states.Find(x =>
            {
                return x.GetType() == nextStateType;
            });
            
            // Debug.Log(nextState);
            
            // Debug.Log(!Equals(m_currentState, nextState));
            
            
            if (nextState != null && !Equals(m_currentState, nextState))
            {
                if (m_currentState != null)
                {
                    m_currentState.Exit();
                }
                nextState.Enter();
                m_currentState = nextState;
                // Debug.Log(m_currentState);
            }
        }
    }
}