using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    public class GP_ActionView : ViewBase
    {
        [SerializeField] private GMC_Gameplay m_GMC_Gameplay;
        
        private ProgressBar m_progressBar;
        private Label m_scoreLabel;
        private Button m_pauseButton;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            m_progressBar = m_view.Query<ProgressBar>("ProgressBarForeground");
            m_progressBar.dataSource = m_GMC_Gameplay;
            m_pauseButton = m_view.Query<Button>(GameConstants.Views.PAUSE_BUTTON);

            m_scoreLabel = m_view.Query<Label>(GameConstants.Views.SCORE_LABEL);
            GameEventsView.OnScoreChanged += OnScoreChanged;
            m_pauseButton.clicked += M_pauseButtonOnclicked; 
        }

        private void OnDisable()
        {
            GameEventsView.OnScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(float obj)
        {
            m_scoreLabel.text = obj.ToString();
        }
        
        private void M_pauseButtonOnclicked()
        {
            GameEventsView.OnPressPause?.Invoke();
        }
    }
}
