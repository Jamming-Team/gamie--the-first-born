using System;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using VectorVisualizer;

namespace TheGame
{
    public class BoxController : MonoBehaviour
    {
        public Action<List<Present>, bool> OnCalculateBoxScore;
        
        [SerializeField] private Vector2 m_initialPosition;
        // [VisualizableVector]
        [SerializeField] private Vector2 m_standPosition;
        [SerializeField] private Vector2 m_outPosition;
        
        [SerializeField] private GameObject m_contentsRoot;
        [SerializeField] private Transform m_lidTransform;
        [SerializeField] private float m_lidOffset;
        [SerializeField] private PolygonCollider2D m_collider;

        private List<Present> m_presentsList = new();
        private bool m_boxIsAvaliable = false;

        private Sequence m_sequencePrepareBox;
        private Sequence m_sequenceSendBox;
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_initialPosition = transform.position;

            // OnBoxChangeAvaliability += b => Debug.Log(b);

            m_collider.enabled = false;
            
            // Sequence.Create(1)
            //     .ChainCallback(() => OnBoxChangeAvaliability?.Invoke(false))
            //     .Chain(Tween.Position(transform, endValue: m_standPosition, duration: 1f, ease: Ease.InOutSine))
            //     .ChainDelay(0.1f)
            //     .ChainCallback(() => Debug.Log(m_lidTransform.position.y))
            //     .Chain(Tween.PositionY(m_lidTransform,  endValue: m_lidOffset, duration: 0.5f, ease: Ease.InOutSine))
            //     .ChainDelay(2f)
            //     .Chain(Tween.PositionY(m_lidTransform,  endValue: 0f, duration: 0.5f, ease: Ease.InOutSine))
            //     .Chain(Tween.Position(transform, endValue: m_outPosition, duration: 1f, ease: Ease.InOutSine))
            //     .ChainCallback(() => OnBoxChangeAvaliability?.Invoke(true));


            // Tween.Position(transform, endValue: m_standPosition, duration: 0.5f, ease: Ease.InBounce);
            
            GameController.Instance.InputController.OnSendBox += InputControllerOnOnSendBox;
            
        }

        private void InputControllerOnOnSendBox(object sender, EventArgs e)
        {
            if (m_boxIsAvaliable)
            {
                SendBox();
            }
        }

        public void PrepareBox()
        {
            m_sequencePrepareBox = Sequence.Create(1)
                // .ChainCallback(() => transform.position = m_initialPosition)
                .Chain(Tween.Position(transform, startValue: m_initialPosition,  endValue: m_standPosition, duration: 1f, ease: Ease.InOutSine))
                .ChainDelay(0.1f)
                .ChainCallback(() => Debug.Log(m_lidTransform.position.y))
                .Chain(Tween.PositionY(m_lidTransform, endValue: m_lidOffset, duration: 0.5f, ease: Ease.InOutSine))
                .ChainCallback(() =>
                {
                    m_collider.enabled = true;
                    m_boxIsAvaliable = true;
                });
            
        }

        public void SendBox(bool overlapped = false, bool shouldReturn = true)
        {
            m_sequenceSendBox = Sequence.Create(1)
                .ChainCallback(() =>
                {
                    m_collider.enabled = false;
                    m_boxIsAvaliable = false;
                })
                .Chain(Tween.PositionY(m_lidTransform, endValue: 0f, duration: 0.5f, ease: Ease.InOutSine))
                .Chain(Tween.Position(transform, endValue: m_outPosition, duration: 1f, ease: Ease.InOutSine))
                .ChainCallback(() =>
                {
                    OnCalculateBoxScore?.Invoke(m_presentsList, overlapped);
                    ClearContents();
                })
                .ChainDelay(1f)
                .ChainCallback(() =>
                {
                    if (shouldReturn)
                        PrepareBox();
                });
        }

        public void AddPresent(Present present, bool overlapped = false)
        {
            present.transform.SetParent(m_contentsRoot.transform);
            m_presentsList.Add(present);
            if (overlapped)
                SendBox(true);
        }

        
        
        private void OnDestroy()
        {
            GameController.Instance.InputController.OnSendBox -= InputControllerOnOnSendBox;

            Debug.Log("Box Destroyed");
            m_sequencePrepareBox.Complete();
            m_sequenceSendBox.Complete();
            Tween.StopAll();
        }


        private void ClearContents()
        {
            m_presentsList.ForEach(Destroy);
        }
        
    }
}
