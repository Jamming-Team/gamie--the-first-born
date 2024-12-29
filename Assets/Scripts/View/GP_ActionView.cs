using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class GP_ActionView : ViewBase
    {
        [SerializeField] private GMC_Gameplay m_GMC_Gameplay;
        
        private ProgressBar m_progressBar;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_progressBar = m_view.Query<ProgressBar>("ProgressBarForeground");
            m_progressBar.dataSource = m_GMC_Gameplay;
        }

        private void OnDisable()
        {
            // GameEventsView.OnTimerChanged += OnTimerChanged;
        }
    }
}
