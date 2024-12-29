using System;
using UnityEngine;

namespace TheGame
{
    public abstract class StateBase : MonoBehaviour
    {
        public event Action<System.Type> OnTransitionRequired;

        protected MonoBehaviour m_core;
        
        public virtual void Init(MonoBehaviour core)
        {
            m_core = core;
        }

        public virtual void Enter()
        {
            gameObject.SetActive(true);
            OnEnter();
        }

        public virtual void Exit()
        {
            OnExit();
            gameObject.SetActive(false);
        }

        protected abstract void OnEnter();

        protected abstract void OnExit();

        public void RequestTransition<T>() where T : StateBase
        {
            // Debug.Log(typeof(T).Name);
            OnTransitionRequired?.Invoke(typeof(T));
        }

        private void OnDestroy()
        {
            // OnExit();
        }
    }
}