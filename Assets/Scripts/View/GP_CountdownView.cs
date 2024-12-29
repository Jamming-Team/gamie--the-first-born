using UnityEngine;
using UnityEngine.UIElements;


namespace TheGame
{
    public class GP_CountdownView : ViewBase
    {
        private Label countdownLabel;
        
        protected override void OnEnable()
        {
            base.OnEnable();

            countdownLabel = m_view.Query<Label>(GameConstants.Views.COUNTDOWN_LABEL);
            GameEventsView.OnTimerChanged += OnTimerChanged;
        }

        private void OnDisable()
        {
            GameEventsView.OnTimerChanged -= OnTimerChanged;
        }
        
        private void OnTimerChanged(int obj)
        {
            countdownLabel.text = obj.ToString();
        }
    }
}
