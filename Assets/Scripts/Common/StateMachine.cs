using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private  List<StateBase> m_states = new();
        [SerializeField]
        private StateBase m_currentState;
        
        
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
                x.Init(this);
                x.OnTransitionRequired += ChangeState;
                Debug.Log(x.GetType());
            });
            m_currentState = m_states[0];
        }

        public void ChangeState(System.Type nextStateType)
        {
            var nextState = m_states.Find(x =>
            {
                return x.GetType() == nextStateType;
            });
            
            if (nextState != null && !Equals(m_currentState, nextState))
            {
                if (m_currentState != null)
                {
                    m_currentState.Exit();
                }
                nextState.Enter();
                m_currentState = nextState;
                Debug.Log(m_currentState);
            }
        }
    }
}