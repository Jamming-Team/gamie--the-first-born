using System.Collections.Generic;
using UnityEngine;

namespace TheGame
{
    public abstract class GameModeStateBase : StateBase
    {

        [SerializeField] protected List<GameObject> m_views;
        public IReadOnlyList<GameObject> views => m_views;

        public override void Init(MonoBehaviour core)
        {
            base.Init(core);
            Exit();
        }

        protected override void OnEnter()
        {
            SetViewsVisibility(true);
        }

        protected override void OnExit()
        {
            SetViewsVisibility(false);
        }

        protected void SetViewsVisibility(bool visibility)
        {
            m_views?.ForEach(x =>
            {
                if (x)
                    x.SetActive(visibility);
            });
        }
    }
}